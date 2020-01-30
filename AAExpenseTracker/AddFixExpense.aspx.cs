using AAExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AAExpenseTracker
{
    public partial class AddFixExpense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usr = (User)Session["LoggedInUser"];
            if (usr == null)
                Response.Redirect("~/Login.aspx");
            else
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
            try
            {
                using (var ctx = new BudgetContext())
                {
                    ctx.Users.Attach(usr);
                    var exp = new FixExpen
                    {
                        Amount = float.Parse(AmntTxt.Text),
                        Concept = ConceptTxt.Text
                    };
                    usr.FixExpens.Add(exp);
                    ctx.SaveChanges();
                    ctx.Entry(usr).State = System.Data.Entity.EntityState.Detached;
                    ConceptTxt.Text = "";
                    AmntTxt.Text = "";
                }
                GridView1.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)e.Keys[0];
            using (var ctx = new BudgetContext())
            {
                var exp = ctx.FixExpens.Find(id);
                ctx.FixExpens.Remove(exp);
                ctx.SaveChanges();
            }
            GridView1.DataBind();
        }

        protected void GridView1_DataBinding(object sender, EventArgs e)
        {
            var usr = (User)Session["LoggedInUser"];
            using (var ctx = new BudgetContext())
            {
                ctx.Users.Attach(usr);
                GridView1.DataSource = usr.FixExpens.ToList();
                ctx.Entry(usr).State = System.Data.Entity.EntityState.Detached;
            }
        }
    }
}