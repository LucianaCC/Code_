<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageExpress.aspx.cs" MasterPageFile="~/MasterPage.Master" Inherits="MessageExpress.MessageExpress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server"   UpdateMode = "Conditional">
<ContentTemplate>
<asp:ScriptManager ID="ScriptManager1" runat="server">
              <Services>
                  <asp:ServiceReference Path="~/WebService.svc" />
              </Services>
          </asp:ScriptManager>
      <div class="pagination-left"> 
      <ContentTemplate>     
      <asp:LinkButton ID="LogOut" runat="server" OnClick = "LogOut_Click">Log Out</asp:LinkButton>
     </ContentTemplate>
      </div>
    
     <div class="pagination-centered" >
     <asp:RequiredFieldValidator id="RequiredFieldValidator2"  ErrorMessage="Please, enter your message."
                    runat="server" ControlToValidate="Texto"/>
     <asp:Label ID="lblError" runat="server" AssociatedControlID="Texto" Text="Please, enter your message." Visible="false" />
    <br>
     <textarea ID="Texto" runat="server" cols="20" name="S1" rows="2"  MaxLength="150" TextMode="MultiLine"></textarea>
     <br>
     <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-large"   onclick="addNewMessage_Click" OnClientClick="addNewMessage_Click"  Text="Post New Message" />
        
    </div>
    <asp:Timer ID="Timer1" runat="server" Interval="10000" ontick="Timer1_Tick">
    </asp:Timer>
    <div class="table">
    <br>
    <asp:ListView ID="Idlistview" runat="server"  >
        <LayoutTemplate>
            <table ID="table1" runat="server"  class="table" >
                <tr ID="itemPlaceholder" runat="server">
                </tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr ID="Tr1" runat="server" class="table-hover">
          
                <td ID="Td1" runat="server" >
                    <%-- Data-bound content. --%>
                    <asp:Image runat ="server" ImageUrl='<%#Eval("Gravatar") %>'  />
                     <h>Message:</h>
                    <asp:Label ID="Text" runat="server" class="label" Text=  '<%#Eval("Text") %>'  />
                    <br ></br>
                    <asp:Label ID="Date" runat="server" Text='<%#Eval("DateFromNow") %>'/>  <h>By</h>   <asp:Label ID="Autor" runat="server" Text=  '<%#Eval("Autor") %>' />
                    <a href="mailto: <%#Eval("Email") %>"  >  <%#Eval("Email") %>  </a>                    
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    </div>
    <div class="pagination-centered">
    <asp:DataPager ID="DataPagerMessage" runat="server" PagedControlID="Idlistview"
    PageSize="4" OnPreRender="DataPagerMessage_PreRender" EnableViewState="False"   >
    <Fields  >
        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" PreviousPageText=" Previous"  FirstPageText=" First "  LastPageText=" Last " NextPageText=" Next "/>
        <asp:NumericPagerField />
        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False" PreviousPageText=" Previous "  FirstPageText=" First "  LastPageText=" Last " NextPageText=" Next "/>
    </Fields>
</asp:DataPager>
</div>
   
</ContentTemplate>
</asp:UpdatePanel>
    
</asp:Content>

