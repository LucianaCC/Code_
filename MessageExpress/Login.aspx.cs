using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityModel;
using BusinessLogicLayer;
using System.Web.Security;

namespace MessageExpress
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            login_.UserName = string.Empty;
            Session["User"] = string.Empty;
        }

       
        protected void Authenticate(object sender, AuthenticateEventArgs e)
        {
            string password = login_.Password;
            string email = login_.UserName;
            
            bool Validated = BusinessLogicLayer.AccountBL.Check(password, email);
           if (Validated)
            {
                login_.Visible = true;
                Session["User"] = BusinessLogicLayer.AccountBL.getUser(password, email);
                Response.Redirect("~/MessageExpress.aspx");
                               
            }
           else
           {
              // Response.Write("Invalid Login");
           }

        }

        
    }
}