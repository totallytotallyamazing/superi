<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.Designer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<%=Html.ActionLink("Жилые помещения", "Details", "Designers", new { id = Model.Url, appartaments ="living"}, null)%>

<%=Html.ActionLink("Нежилые помещения", "Details", "Designers", new { id = Model.Url, appartaments = "notliving" }, null)%>



    <h2><%=Model.Name%></h2>

    <%
    
       
        
        foreach (var dc in Model.DesignerContent)
        {

            
            
            %>
            
            <div>
            
            <%=dc.DesignerRoom.Name%>
            
            </div>

            <%
        }
            
    %>

    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
