<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	О брендах
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% if(Roles.IsUserInRole("Administrators")){ %>
    <p class="adminLink">
        <%= Html.ActionLink("адмнистрирование брендов", "Index", new {conteoller="Brands", area="admin"}) %>
    </p>
<%} %>
                    <div id="contentItem">
                    <div id="contentItemFoto">
                        <img src="/Content/img/foto1.jpg" alt="jeans">
                    </div>
                    <div id="contentItemText">
                        <p>
                            Одна из самых известных немецких марок в мире одежды. представленная широким ассортиментом
                            товаров, отвечающих индивидуальным потребностям, гарантирует высокое качество продукции
                            с характерным и узнаваемым дизайном. Лидирующий бренд итальянской группы Forall.
                            Для тех, кто одинаково влюблены и в классический костюм и в ультрасовременные вещи.</p>
                    </div>
                </div>
                <div id="contentItem">
                    <div id="contentItemFoto">
                        <img src="/Content/img/foto2.jpg" alt="jeans">
                    </div>
                    <div id="contentItemText">
                        <p>
                            Немецкая марка одежды. Ассоциируется с классическими костюмами идеального кроя.
                            Бренд высококлассной одежды, в котором гармонично со-существуют традиционная классика,
                            одежда для отдыха и светских приемов. А также привлекательным соотношением цена-качество.</p>
                    </div>
                </div>
                <div id="contentItem">
                    <div id="contentItemFoto">
                        <img src="/Content/img/foto3.jpg" alt="jeans">
                    </div>
                    <div id="contentItemText">
                        <p>
                            Итальянская марка женской одежды высочайшего качества и дизайна. Неповторимость
                            фасонов, новаторство и творчество – движущие элементы фирмы. Итальянская марка,
                            специализирующаяся на выпуске нарядного трикотажа. В последние годы коллекция трикотажа
                            дополняется брюками, джинсами, куртками, аксессуарами. Широкая гамма оригинальных
                            фасонов из высококлассных материалов.</p>
                    </div>
                </div>
                <div id="contentItem">
                    <div id="contentItemFoto">
                        <img src="/Content/img/foto1.jpg" alt="jeans">
                    </div>
                    <div id="contentItemText">
                        <p>
                            Одна из самых известных немецких марок в мире одежды. представленная широким ассортиментом
                            товаров, отвечающих индивидуальным потребностям, гарантирует высокое качество продукции
                            с характерным и узнаваемым дизайном. Лидирующий бренд итальянской группы Forall.
                            Для тех, кто одинаково влюблены и в классический костюм и в ультрасовременные вещи.</p>
                    </div>
                </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    О брендах
</asp:Content>
