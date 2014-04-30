using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityModel;
using BusinessLogicLayer;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Web.Services;

namespace MessageExpress
{
    public partial class MessageExpress : System.Web.UI.Page
    {


        WebService webService = new WebService();

        protected void Page_Load(object sender, EventArgs e)
        {    
            if (!Page.IsPostBack)
            {
                if ((Session["user"]).ToString() != string.Empty )
                {
                    refreshMessage();
                    Account userlogged = (EntityModel.Account)Session["user"];  
                }
                else
                { 
                     Response.Redirect("~/Login.aspx");
                }
            }
            else 
            {
                refreshMessage();
            }              
        }

        protected void addNewMessage_Click(object sender, EventArgs e)
        {
            if (Texto.Value != string.Empty)
            {
                EntityModel.Account userloged = (EntityModel.Account)Session["user"];
                Message newMessage = new Message();
                newMessage.Text = Texto.Value;
                newMessage.Account = userloged;
                webService.Message_newMessage(newMessage);
                Texto.Value = string.Empty;
                refreshMessage();
            }
            else
            {
                lblError.Text = "Please, enter your message.";
            }
        }   

        public void refreshMessage() 
        
        {           
            List<EntityModel.Message> list = webService.Message_getAllMessage();
            if (list.Count > 0)
            {
                foreach (Message item in list)
                {
                   item.Gravatar = GetGravatarUrl(item.Email);                   
                }
            }
            Idlistview.DataSource = list;
            Idlistview.DataBind();                       
        }

        protected string GetGravatarUrl(string emailgrav)
        {
            string email = emailgrav;
            string hash = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(email.Trim(), "MD5");
            hash = hash.Trim().ToLower();
            string gravatarUrl = string.Format("http://www.gravatar.com/avatar.php?gravatar_id={0}&rating=G&size=60", hash);
            return gravatarUrl;
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            Session["user"] = string.Empty;
            Response.Redirect("~/Login.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            refreshMessage();
           
        }

        protected void DataPagerMessage_PreRender(object sender, EventArgs e)
        {
            refreshMessage();
        }
   
    }
}
