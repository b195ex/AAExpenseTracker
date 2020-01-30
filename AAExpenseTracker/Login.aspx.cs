using AAExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AAExpenseTracker
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ClearAlerts()
        {
            if (!LoginException.Attributes["class"].Contains("collapse"))
                LoginException.Attributes["class"] += "collapse";
            if (!SignInFailed.Attributes["class"].Contains("collapse"))
                SignInFailed.Attributes["class"] += "collapse";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClearAlerts();
            try
            {
                using (var ctx = new BudgetContext())
                {
                    var user = ctx.Users.Where(u => u.UserID == inputEmail.Text).FirstOrDefault();
                    if(user == null)
                    {
                        user = new User();
                        user.UserID = inputEmail.Text;
                        ctx.AddUser(user, inputPassword.Text);

                    }
                    if(ctx.Authenticate(inputEmail.Text, inputPassword.Text))
                    {
                        ctx.Entry(user).State = System.Data.Entity.EntityState.Detached;
                        Session.Add("LoggedInUser", user);
                        Response.Redirect("~/Dashboard.aspx");
                    }
                    else
                    {
                        SignInFailed.Attributes["class"] = SignInFailed.Attributes["class"].Replace("collapse", "");
                    }
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;
                ErrorLabel.Text = ex.Message;
                LoginException.Attributes["class"] = LoginException.Attributes["class"].Replace("collapse", "");
            }
        }
    }
}