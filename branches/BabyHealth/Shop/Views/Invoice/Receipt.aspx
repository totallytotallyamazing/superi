<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Helpers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Квитанция</title>
    <style type="text/css">
        *{font-family:Times New Roman; font-size:8pt;}
        .title{font-weight:bold; text-align:center;}
        p{padding-left:10px;}
        p span{text-decoration:underline; padding-left:10px;}
        table.orderContents{width:100%; margin-top:5px;}
        table.orderContents, 
        table.orderContents tr,
        table.orderContents td
        {
            border-collapse:collapse;    
        }
        
        table.orderContents td,
        table.orderContents th
        {
            border: 1px solid black;
            padding:0 5px;
        }
    </style>
</head>
<body>
    <div id="main">
        <div class="title">
            Заява на переказ готівки №
        </div>
        <div >
            Дата здійснення операції _____________________ 
        </div>
        <table class="orderContents" cellpadding="0" cellspacing="0">
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
                <td>&nbsp;</td>
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
            Код платника ** ________________________
        </p>    
        <p>
            Банк платника * ________________________
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
        <p>
            Загальна сума  <span><%= Html.SpellPrice(WebSession.OrderItems.Sum(oi => oi.Value.Price * oi.Value.Quantity))%></span>
        </p>
        <p>
            Призначення платежу  <span>За товар Інтернет-магазину згідно замовлення №<%= WebSession.Order.Id %></span>
        </p>
        <p>
            Додаткові реквізити      <span>тел. 3603263</span>
        </p>
        <p>
            Підпис платника _____________________ Підписи банку ________________________________________
        </p>
        <p>
            ______________________________________________________________________________________________________________________
        </p>
        
        
        
        
        <div  class="title">
            Квитанція  №
        </div>
        <div class="operationDate">
            Дата здійснення операції _____________________ 
        </div>
        <table class="orderContents" cellpadding="0" cellspacing="0">
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
                <td>&nbsp;</td>
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
            Код платника ** ________________________
        </p>    
        <p>
            Банк платника * ________________________
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
        <p>
            Загальна сума  <span><%= Html.SpellPrice(WebSession.OrderItems.Sum(oi => oi.Value.Price * oi.Value.Quantity))%></span>
        </p>
        <p>
            Призначення платежу  <span>За товар Інтернет-магазину згідно замовлення №<%= WebSession.Order.Id %></span>
        </p>
        <p>
            Додаткові реквізити      <span>тел. 3603263</span>
        </p>
        <p>
            Підпис платника _____________________ Підписи банку ________________________________________
        </p>
    </div>
</body>
</html>
<script type="text/javascript">
    window.print();
</script>