<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%=Html.ResourceString("ThankYou")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%=Html.ResourceString("ThankYou")%></h2>
    <center>
    
    
    <%
        if (!Request.IsAuthenticated)
        {%>
     <table>
     <tr>
        <td colspan="2">
            <%=Html.ResourceString("WouldRegister")%>   
        </td>
     </tr>
     <tr>
        <td align="right">
        <%using(Html.BeginForm("Register", "Account", FormMethod.Get))
        {%>
            <input style="width:50px;" type="submit" value="<%=Html.ResourceString("Yes")%>" />
        <%}%>
     
        </td>
        <td align="left">
        <%using (Html.BeginForm("ClearCart", "Cart", FormMethod.Get))
          {%>
            <input style="width:50px;" type="submit" value="<%=Html.ResourceString("No")%>" />
        <%}%>
        </td>
     </tr>
     </table>
     <%
    
        }
        else
        {%>

        
        <%using(Html.BeginForm("Index", "Home", FormMethod.Get))
        {%>
            <input type="submit" value="<%=Html.ResourceString("ToMainPage")%>" />
        <%}
        }
        
        %>
    </center>
    

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>
