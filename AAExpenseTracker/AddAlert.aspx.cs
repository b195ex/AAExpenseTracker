using AAExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AAExpenseTracker
{
    public partial class AddAlert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usr = (User)Session["LoggedInUser"];
            if (usr == null)
                Response.Redirect("~/Login.aspx");
            else if (!IsPostBack)
            {
                TypeDropDn.DataBind();
                TagDropDn.DataBind();
                TypeDropDn_SelectedIndexChanged(TypeDropDn, e);
                GridView1.DataBind();
            }
        }

        protected void Grid_PreRender(object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            if (grid.HeaderRow != null)
                grid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void TypeDropDn_SelectedIndexChanged(object sender, EventArgs e)
        {
            var res = Enum.Parse(typeof(AlarmType), ((DropDownList)sender).SelectedValue);
            switch (res)
            {
                case AlarmType.Percentage:
                    RangeValidator1.MinimumValue = "1";
                    RangeValidator1.MaximumValue = "100";
                    RangeValidator1.Type = ValidationDataType.Integer;
                    RangeValidator1.Text = "*Please input a percentage.";
                    break;
                case AlarmType.Amount:
                    RangeValidator1.MinimumValue = "1";
                    RangeValidator1.MaximumValue = int.MaxValue.ToString();
                    RangeValidator1.Type = ValidationDataType.Currency;
                    RangeValidator1.Text = "*Please input a valid amount.";
                    break;
                default:
                    break;
            }
        }

        protected void TypeDropDn_DataBinding(object sender, EventArgs e)
        {
            foreach (int item in Enum.GetValues(typeof(AlarmType)))
            {
                ListItem li = new ListItem(Enum.GetName(typeof(AlarmType), item), item.ToString());
                TypeDropDn.Items.Add(li);
            }
        }

        protected void TagDropDn_DataBinding(object sender, EventArgs e)
        {
            using (var ctx=new BudgetContext())
            {
                var usr = (User)Session["LoggedInUser"];
                ctx.Users.Attach(usr);
                TagDropDn.Items.Add("Select");
                foreach (var Expense in usr.Expenses)
                {
                    foreach (var tag in Expense.Tags)
                    {
                        ListItem li = new ListItem(tag.ID);
                        if (!TagDropDn.Items.Contains(li))
                            TagDropDn.Items.Add(li);
                    }
                }
                ctx.Entry(usr).State = System.Data.Entity.EntityState.Detached;
            }
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            var usr = (User)Session["LoggedInUser"];
            using (var ctx = new BudgetContext())
            {
                ctx.Users.Attach(usr);
                Alarm neo = new Alarm
                {
                    Active = true,
                    AlarmType = (AlarmType)Enum.Parse(typeof(AlarmType), TypeDropDn.Text),
                    Amount = float.Parse(AmntTxt.Text),
                    Message = MsgTxt.Text,
                    Tag = ctx.ExpenseTags.Find(TagDropDn.Text)
                };
                usr.Alarms.Add(neo);
                ctx.SaveChanges();
                ctx.Entry(usr).State = System.Data.Entity.EntityState.Detached;
            }
            AmntTxt.Text = MsgTxt.Text = "";
            TagDropDn.SelectedIndex = 0;
        }

        protected void GridView1_DataBinding(object sender, EventArgs e)
        {
            var usr = (User)Session["LoggedInUser"];
            using (var ctx=new BudgetContext())
            {
                ctx.Users.Attach(usr);
                GridView1.DataSource = usr.Alarms.ToList();
                ctx.Entry(usr).State = System.Data.Entity.EntityState.Detached;
            }
        }

        protected void CheckBox1_PreRender(object sender, EventArgs e)
        {
            var check = (CheckBox)sender;
            check.InputAttributes.Add("class", "custom-control-input");
            check.LabelAttributes.Add("class", "custom-control-label");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            var check = (CheckBox)sender;
            var fld=(HiddenField)check.NamingContainer.FindControl("Field1");
            using (var ctx=new BudgetContext())
            {
                ctx.Alarms.Find(int.Parse(fld.Value)).Active = check.Checked;
                ctx.SaveChanges();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)e.Keys[0];
            using (var ctx = new BudgetContext())
            {
                var al = ctx.Alarms.Find(id);
                ctx.Alarms.Remove(al);
                ctx.SaveChanges();
            }
            GridView1.DataBind();
        }
    }
}