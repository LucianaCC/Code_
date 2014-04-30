<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MessageExpress.Login" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<script runat="server">
bool IsValidEmail(string strIn)
{
     return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); 
}

void OnLoggingIn(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
{
    if (!IsValidEmail(login_.UserName))
    {
        login_.InstructionText = "Enter a valid e-mail address.";
 
        e.Cancel = true;
    }
    else
    {
        login_.InstructionText = "";
    }
}

void OnLoginError(object sender, EventArgs e)
{
    login_.FailureText = "Invalid e-mail or password";
   
}
    

</script>
    <div class="login-centered" >         
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

    <asp:Login ID="login_" runat="server" onauthenticate="Authenticate"
        CssClass="label" UserNameLabelText="E-mail:"  OnLoggingIn="OnLoggingIn" 
        onloginerror="OnLoginError" DisplayRememberMe="False" RememberMeText="" 
        LoginButtonText="Enter" PasswordLabelText="Password:" TitleText="Log In"   >
    </asp:Login>
  
</ContentTemplate>
</asp:UpdatePanel>
    </div>    
</asp:Content>

   
