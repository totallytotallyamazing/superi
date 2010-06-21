<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Shop.Models.Article>>" %>

<div id="babySay">
    <div id="sayText">
        <h3>
            14 апреля</h3>
        <h4>
            <a href="#">Завезли новые ползунки и свитерки.</a></h4>
        <p>
            <%=Html.ActionLink("Все новости »","Index","Articles")%>
        </p>
    </div>
</div>