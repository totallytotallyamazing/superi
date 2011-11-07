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

        <%if (Roles.IsUserInRole("Administrators")) { 
              %>
              <%=Html.ActionLink("Добавить текстовый блок", "AddReviewConentItem", "Review", new { Area = "Admin", id = Model.Id }, new { @class="adminLink"})%>
              <%=Html.ActionLink("Добавить блок изображений", "AddReviewContentItemImage", "Review", new { Area = "Admin", reviewContentId = Model.Id }, new { @class = "adminLink" })%>
              
              <%
          } %>

        <%
            foreach (var item in Model.ReviewContentItems.OrderBy(c => c.SortOrder))
            {
                %>
                <div class="contentBlock">
                <%Html.RenderPartial("CustomBlock", item);%>
                </div>
                <%
            }
        %>
        <div class="pattern2">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">

<script type="text/javascript">
    $(function () {
        $(".fancy").fancybox({ showCloseButton: true, cyclic: true, showNavArrows: true, padding: 0, margin: 0, centerOnScroll: true });
        $("#reviewMenu").scrollFollow({
        offset:500
        });
    });
</script>

</asp:Content>
