<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Controllers" %>
<%
    Cart cart = SystemSettings.Cart;
    decimal totalPrice = cart.Orders.Sum(o => o.OrderItems.Sum(oi => oi.Price));
    int orderItemsCount = cart.Orders.Sum(o => o.OrderItems.Count);
%>
