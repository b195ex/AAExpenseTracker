using AAExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AAExpenseTracker
{
    public partial class AddIncome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usr = (User)Session["LoggedInUser"];
            if (usr == null)
                Response.Redirect("~/Login.aspx");
            else if (!IsPostBack)
                GridView1.DataBind();
        }

        protected void Grid_PreRender(object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            if (grid.HeaderRow != null)
                grid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            var usr = (User)Session["LoggedInUser"];
            using (var ctx = new BudgetContext())
            {
                ctx.Users.Attach(usr);
                var incom = new Income
                {
                    Amount = float.Parse(AmntTxt.Text),
                    Date = DateTime.Parse(DateTxt.Text),
                    Concept = ConceptTxt.Text,
                    Tags = new List<IncomeTag>()
                };
                string[] tags = TagTxt.Text.Split(',');
                foreach (var item in tags)
                {
                    var temp = ctx.IncomeTags.Find(item.Trim());
                    if (temp == null)
                    {
                        temp = new IncomeTag { ID = item.Trim() };
                        ctx.IncomeTags.Add(temp);
                    }
                    incom.Tags.Add(temp);
                }
                usr.Incomes.Add(incom);
                ctx.SaveChanges();
                ctx.Entry(usr).State = System.Data.Entity.EntityState.Detached;
                ConceptTxt.Text = "";
                AmntTxt.Text = "";
                DateTxt.Text = "";
                TagTxt.Text = "";
            }
            GridView1.DataBind();
        }

        protected void GridView1_DataBinding(object sender, EventArgs e)
        {
            var usr = (User)Session["LoggedInUser"];
            using (var ctx = new BudgetContext())
            {
                ctx.Users.Attach(usr);
                GridView1.DataSource = usr.Incomes.ToList();
                ctx.Entry(usr).State = System.Data.Entity.EntityState.Detached;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)e.Keys[0];
            using (var ctx = new BudgetContext())
            {
                var inc = ctx.Incomes.Find(id);
                ctx.Incomes.Remove(inc);
                ctx.SaveChanges();
            }
            GridView1.DataBind();
        }
    }
}