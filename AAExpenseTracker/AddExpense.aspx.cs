using AAExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AAExpenseTracker
{
    public partial class AddExpense : System.Web.UI.Page
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
                var exp = new Expense
                {
                    Amount = float.Parse(AmntTxt.Text),
                    Date = DateTime.Parse(DateTxt.Text),
                    Concept = ConceptTxt.Text,
                    Tags = new List<ExpenseTag>()
                };
                string[] tags = TagTxt.Text.Split(',');
                foreach (var item in tags)
                {
                    var temp = ctx.ExpenseTags.Find(item.Trim());
                    if (temp == null)
                    {
                        temp = new ExpenseTag { ID = item.Trim() };
                        ctx.ExpenseTags.Add(temp);
                    }
                    exp.Tags.Add(temp);
                }
                usr.Expenses.Add(exp);
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
                GridView1.DataSource = usr.Expenses.ToList();
                ctx.Entry(usr).State = System.Data.Entity.EntityState.Detached;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)e.Keys[0];
            using (var ctx = new BudgetContext())
            {
                var exp = ctx.Expenses.Find(id);
                ctx.Expenses.Remove(exp);
                ctx.SaveChanges();
            }
            GridView1.DataBind();
        }
    }
}