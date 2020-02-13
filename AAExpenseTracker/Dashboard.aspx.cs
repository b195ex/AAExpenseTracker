using AAExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace AAExpenseTracker
{
    
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usr = (User)Session["LoggedInUser"];
            if (usr == null)
                Response.Redirect("~/Login.aspx");
            else if (!IsPostBack)
            {
                Populate_remaining_chart(usr.UserID);
                Repeater1.DataBind();
            }
        }

        protected void Populate_remaining_chart(string UserID)
        {
            try
            {
                using (var ctx = new BudgetContext())
                {
                    ctx.Database.Connection.Open();
                    SqlCommand cmd = new SqlCommand(ctx.Queries.Find(1).Statement, (SqlConnection)ctx.Database.Connection);
                    cmd.Parameters.AddWithValue("User", UserID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Chart1.Series[0].Points.AddXY(rdr.GetString(0), rdr.GetDouble(1));
                    }
                }
            }
            catch (Exception)
            {

                return;
            }
            
        }

        protected void Repeater1_DataBinding(object sender, EventArgs e)
        {
            var usr = (User)Session["LoggedInUser"];
            try
            {
                using (var ctx = new BudgetContext())
                {
                    ctx.Users.Attach(usr);
                    float bar = 0;
                    float fi = usr.FixIncoms.Sum(x => x.Amount);
                    List<Alarm> triggered = new List<Alarm>();
                    foreach (var item in usr.Alarms)
                    {
                        if (item.Active)
                        {
                            bar = usr.Expenses.Where(x => x.Tags.Contains(item.Tag)).Sum(x => x.Amount);
                            switch (item.AlarmType)
                            {
                                case AlarmType.Percentage:
                                    if (bar >= fi * (item.Amount / 100))
                                        triggered.Add(item);
                                    break;
                                case AlarmType.Amount:
                                    if (bar >= item.Amount)
                                        triggered.Add(item);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    ctx.Entry(usr).State = System.Data.Entity.EntityState.Detached;
                    Repeater1.DataSource = triggered;
                }
            }
            catch (Exception)
            {

                return;
            }
            
        }
    }
}