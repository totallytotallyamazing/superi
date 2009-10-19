<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Вітаємо!</h2>
    Реєстрація майже завершена.<br />
    Будь ласка, перевірте Вашу поштову скриньку <%= ViewData["email"] %> і пройдіть по лінку, який вказаний в листі. <br />
    В більшості випадків листи приходять протягом однієї хвилини, але інколи для цього потрібно до 10 хвилин.
</asp:Content>