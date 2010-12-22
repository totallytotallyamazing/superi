<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.ExtendedSearchModel>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Расширенный поиск
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm()) {%>

    <div id="basketBox">

    <div class="extendedSearchField">
        <%= Html.TextBoxFor(m=>m.Phrase) %>
    </div>

    <table class="userInfo extSearch" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td class="searchCell">
                    Категория товара:
                </td>
                <td class="searchCellField">
                    <%= Html.DropDownList("CategoryId") %>
                </td>
                <td class="validationError">
                </td>
            </tr>
            <tr>
                <td class="searchCell">
                    Размер:
                </td>
                <td class="searchCellField">
                    <%= Html.DropDownList("SizeId") %>
                </td>
                <td class="validationError">
                </td>
            </tr>
            <tr>
                <td class="searchCell">
                    Цена:
                </td>
                <td class="searchCellField">
                    <div class="priceRange">
                        от <%= Html.TextBoxFor(m=>m.PriceFrom) %> до <%= Html.TextBoxFor(m=>m.PriceTo) %>
                    </div>
                </td>
                <td class="validationError">
                    <span class="currency">грн.</span>
                </td>
            </tr>
            <tr>
                <td class="searchCell">
                    Состав:
                </td>
                <td class="searchCellField">
                    <%= Html.DropDownList("ContentId") %>
                </td>
                <td class="validationError">
                </td>
            </tr>
            <tr>
                <td class="searchCell">
                    Бренд:
                </td>
                <td class="searchCellField">
                    <%= Html.DropDownList("BrandId") %>
                </td>
                <td class="validationError">
                </td>
            </tr>
        </table>
        </div>
        <div class="extendedSearchButton">
            <input type="image" src="/Content/img/searchButton.jpg" />
        </div>
        <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    Расширенный поиск
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.DynamicCssInclude("/Content/Cart.css") %>
    <script type="text/javascript">
        $(function () {
            $("#Phrase").watermark({ html: "Что ищем?", cls: "extSearchWatermark" });
        });
    </script>
</asp:Content>

