<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Самая Главная страница
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="textUnderLine">
        <p>
            которая помогает простыми словами сориентироваться в категориях товаров. Просто
            выберите близкий Вам по теме пункт, и все товары, имеющие к нему отношение, появятся
            перед вами.</p>
    </div>
    <div id="linksBox">
        <div class="linksBoxString">
            <p>
                <% Html.RenderPartial("Tags"); %>
            </p>
        </div>
    </div>
    <div id="textUnderLinks">
        <p>
            Так же, можно воспользоваться поиском (вверху справа), или традиционным каталогом
            слева.
        </p>
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentTitle">
    Самая Главная страница,
</asp:Content>
