<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Review.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.ReviewContent>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="reviewDetails">
        <div class="title">
            <%=Model.Title %>
        </div>
        <div class="description">
            <%=Model.Description %>
        </div>
        <div class="pattern1">
        </div>
        <%
            foreach (var item in Model.ReviewContentItems.OrderBy(c => c.SortOrder))
            {
                Html.RenderPartial("CustomBlock",item);
            }
        %>
        <div class="pattern1">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>
