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
            }
        }

        protected void Populate_remaining_chart(string UserID)
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
    }
}