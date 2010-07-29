<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.Product>>" %>
<% if(Model.Count()>0){ %>
    <div id="skidki">
        <h2>СКИДКА ДНЯ</h2>
        <div id="skidkiBox">
            <div id="imgBox">
                <img src="/Content/img/cheshki.jpg" alt="cheshki">
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
<%} %>