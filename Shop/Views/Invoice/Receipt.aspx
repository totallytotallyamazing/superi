<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Helpers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Квитанция</title>
</head>
<body>
    <div id="main">
        <div id="title">
            Заява на переказ готівки №
        </div>
        <div id="operationDate">
            Дата здійснення операції _____________________ 
        </div>
        <table border="1" id="orderContents">
            <tr>
                <th>
                    Назва валюти
                </th>
                <th>&nbsp;</th>
                <th>
                    № рахунку
                </th>
                <th>
                    Сума
                </th>
                <th>
                    Еквівалент у гривнях
                </th>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    Дебет
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    Гривня
                </td>
                <td>
                    Кредит
                </td>
                <td>
                    26006000451971
                </td>
                <td>
                    <%= WebSession.OrderItems.Sum(oi=>oi.Value.Quantity * oi.Value.Price).ToString("0.00")  %>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    Загальна сума (цифрами)
                </td>
                <td>
                    <%= WebSession.OrderItems.Sum(oi=>oi.Value.Quantity * oi.Value.Price).ToString("0.00")  %>
                </td>
            </tr>
        </table>
        <p>
            Платник <span><%= WebSession.Order.BillingName %></span>
        </p>  
        <p>
            Код платника ** __________________
        </p>    
        <p>
            Банк платника * _________ 
        </p>  
        <p>
            Отримувач     <span>ФОП Морозова Валентина Петрівна</span>
        </p>
        <p>
            Код отримувача * <span>2168600067</span>
        </p>
        <p>
            Банк отримувача <span>ПАТ "Універсал Банк"</span>
        </p>
        <p>
            Код банку отримувача    <span>322001</span>
        </p>
    </div>
</body>
</html>
