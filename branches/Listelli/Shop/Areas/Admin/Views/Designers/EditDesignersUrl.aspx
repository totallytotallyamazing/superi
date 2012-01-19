<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Designers.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <% using (Html.BeginForm())
       {
           %>
           <br/>
           Введите новый адрес дизайнера:
           <br/>
           <%=Html.Hidden("email") %>
           <%=Html.TextBox("url") %>
           
           <br/>
           <br/>
           <input type="submit" value="Сохранить"/>

           <% if (Roles.IsUserInRole(User.Identity.Name, "Administrators"))
           { %>
        <%:Html.ActionLink("отмена", "Index")%>
        <% }else
           {
               %>
               <%:Html.ActionLink("отмена", "UserCabinet")%>
               <%
               
           } %>

           <%
       } %>

    

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentHeader" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
