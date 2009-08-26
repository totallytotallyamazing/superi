<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Contacts
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<script type="text/javascript">
    function checkEmail() {

        var email = $get('email').value;
        
        //return false;
    }
</script>

    <h2><%=Html.ResourceString("Contacts")%></h2>
    


<br />    
    <%=Html.Encode(ApplicationData.ContactsHeader)%>
<br />
<br />    
<hr />
<br />
<h3><%=Html.ResourceString("ContactPhone") %></h3>

<br />
<br />    
<hr />
<br />
    <h3><%=Html.ResourceString("Feedback2") %></h3>
    <br />
    
    <% using (Html.BeginForm("SendMessage", "Home", FormMethod.Post))
       { %>
    <table>
    <tr>
        <td><%=Html.ResourceString("YourName") %>:</td>
        <td><%=Html.TextBox("userName")%></td>
    </tr>
    <tr>
        <td><%=Html.ResourceString("MessageSubj") %>:</td>
        <td><%=Html.TextBox("messageSubj")%></td>
    </tr>
    <tr>
        <td><%=Html.ResourceString("MessageBody")%>:</td>
        <td><%=Html.TextArea("messageBody", new { cols = "17", rows = "5" })%></td>
    </tr>
    <tr>
        <td>Email:</td>
        <td>
        <%=Html.TextBox("email")%>
        <%= Html.ValidationMessage("email", "*", new { @class="validationError" })%>
        </td>
    </tr>
    <tr>
        <td><%=Html.ResourceString("Phone")%>:</td>
        <td><%=Html.TextBox("phone")%></td>
    </tr>
    </table>
    <input type="submit" onclick="return checkEmail()" value="<%=Html.ResourceString("Send")%>" />
<%} %>

<table></table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>
