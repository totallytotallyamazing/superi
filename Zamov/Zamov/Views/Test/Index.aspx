<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zamov.Controllers"%>
<%@ Import Namespace="Zamov.Helpers"%>
<%@ Import Namespace="Zamov.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
    
    <br />
    <br />
    
    <%

        bool captchaValid = Convert.ToBoolean(ViewData["captchaValid"]);

        Response.Write(captchaValid.ToString());
        
            %>
<%
    using (Html.BeginForm("DoSomething", "Test", FormMethod.Post))
    {%>
        <label for="captcha">Enter <%= Html.CaptchaImage(50, 180)%> Below</label><br />
        <%= Html.TextBox("captcha") %>
        <input type="submit" value="aaa" />
      <%
        
    }%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>
