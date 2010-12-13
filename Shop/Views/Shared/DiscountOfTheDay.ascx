<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Shop.Models" %>
<% 
    using(ShopStorage context =  new ShopStorage()){
        var items = context.Products.Include("ProductAttributeValues").Where(p => p.IsSpecialOffer).Select(p => new 
        { 
            Name = p.Name, 
            Price = p.Price,
            Sizes = p.ProductAttributeValues.Where(pav=>pav.Id == 1)
        });
%>

<% if(items.Count()>0){ %>
    <div id="skidki">
        <h2>СКИДКА ДНЯ</h2>
        <div class="skidkiBox">
            <div class="imgBox">
                <img src="/Content/img/cheshki.jpg" alt="cheshki" />
            </div>
            <p>
                <a href="#">Чешки “Ed Hardy”</a>
            </p>
            <p>
                Размер: <strong>35</strong>
            </p>
            <p>
                Цвет: <strong>Разноцветные</strong>
            </p>
            <h4>
                1350 грн</h4>
        </div>
    </div>
<%}} %>