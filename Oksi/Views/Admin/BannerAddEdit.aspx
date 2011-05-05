<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Oksi.Models.Banner>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AddBanner
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Добавить/редактировать баннер</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm("BannerAddEdit", "Admin", FormMethod.Post, new { enctype = "multipart/form-data" }))
       {%>
    <%= Html.Hidden("id") %>
        <fieldset>
            <p>
                <label for="ImageSource">Позиция:</label>
                <%=Html.DropDownList("Position", new List<SelectListItem>
                                                        {
                                                            new SelectListItem { Text = "Неактивный", Value = "0", Selected = Model != null && Model.Position == 0 }, 
                                                            new SelectListItem { Text = "Слева", Value = "1", Selected = Model != null && Model.Position == 1 }, 
                                                            new SelectListItem { Text = "Справа", Value = "2", Selected = Model != null && Model.Position == 2 }
                                                        })%>
            </p>
            <p>
                <label for="ImageSource">Баннер:</label>
                <input type="file" name="logo" />
            </p>
            <p>
                <input type="submit" value="Сохранить" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Назад к списку", "Banners") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
</asp:Content>

