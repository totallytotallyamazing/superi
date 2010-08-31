<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Shop.Models" %>
<%@ Import Namespace="System.Globalization" %>

<% 
    Order order = (Order)ViewData["Order"];
    IEnumerable<OrderItem> orderItems = (IEnumerable<OrderItem>)ViewData["OrderItems"];
    
    string[] months = {"", "січня", "лютого", "березня", "квітня", "травня", "червня", "липня", "серпня", "вересня", "жовтня", "листопада", "грудня"};
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Счет</title>
    <style type="text/css">
        *{font-size: 8pt; font-family: Arial; }
        .invoiceHeader{border:1px solid black; float:left; padding:3px 40px 10px 5px; clear:both;}
        .invoiceHeader div{float: left; white-space: nowrap;}
        .invoiceHeader p span{display: inline-block;}
        .invoiceHeader p span.label, .codeLabel{width: 100px;font-family: Times New Roman;font-size: 9pt;}
        .receiver, .bankName{font-weight: bold; font-size:9pt;}
        .codeLabel{line-height: 40px;}
        .code{width: 200px;height: 40px;border: 2px solid black;text-align: center;padding-top: 10px;font-size: 9pt;font-weight: bold;}
        .bankName{font-weight: bold;}
        .invoiceHeader .header{font-size: 10pt;font-weight: bold;text-align: center;}
        .attention{text-align: center;padding: 10px;width:647px;margin-bottom:20px}
        
        div.bankCode{ text-align:center; padding:85px 5px 0;}
        .label.bankCodeLabel{font-family:Times New Roman; font-size:9pt; padding:0; margin:0;}
        p.bankCode{border:2px solid black; padding:10px; font-weight:bold; font-size:9pt; margin:0;}
        
        div.creditData{text-align:center; padding-top:50px; padding-left:15px;}
        .label.creditLabel{font-family:Times New Roman; font-size:9pt; margin:0;}
        p.creditNumber, p.creditNumberFooter{border:2px solid black; margin:0;}
        p.creditNumber{padding:10px 40px;}
        p.creditNumberFooter{border-top:0; height:35px;}
        
        .invoiceTitle{width:647px; clear:both; font-size:14pt; padding:20px 5px 0px; border-bottom:2px solid black;}
        .invoiceDetails{width:647px;}
        .invoiceDetails table td{font-size:10pt;}
        
        table.orderItems,
        table.orderItems tr,
        table.orderItems th,
        table.orderItems td{border-collapse:collapse;}
        table.orderItems th,
        table.orderItems td{border: 1px solid black}
        
        table.orderItems{width:647px;}
        table.orderItems tbody{border:2px solid black;}
        .orderItems th{ background:#eee; font-weight:bold; font-size:10pt; padding:10px; white-space:nowrap}
        table.orderItems td{font-size:8pt;}
        
        tfoot td{font-size:10pt; font-weight:bold; border:0 !important}
        th.product{width:400px}
        
        .invoiceFooter{margin-top:20px; font-size:8pt;}
        .invoiceFooter p{font-size:10pt; font-weight:bold;}
    </style>
</head>
<body>
    <div id="main">
        <div class="attention">
            Увага! Оплата цього рахунку означає погодження з умовами поставки товарів. Товар
            відпускається за фактом надходження коштів на р/р Постачальника.
        </div>
        <div class="invoiceHeader">
            <p class="header">
                Платiжне доручення
            </p>
            <div>
                <p>
                    <span class="label">Одержувач</span> <span class="receiver">ФОП Морозова Валентина Петрівна</span>
                </p>
                <p>
                    <span class="codeLabel">Код</span> <span class="code">2168600067</span>
                </p>
                <p>
                    <span class="label">Банк одержувача</span><br />
                    <br />
                    <span class="bankName">ВАТ Київська філія №2 ВАТ "Універсал Банк" </span>
                </p>
            </div>
            <div class="bankCode">
                <p class="label bankCodeLabel">
                    Код банку
                </p>
                <p class="bankCode">
                    322001
                </p>
            </div>
            <div class="creditData">
                <p class="label creditLabel">
                    КРЕДИТ рах. №
                </p>
                <p class="creditNumber">
                    26006000451971
                </p>
                <p class="creditNumberFooter">
                
                </p>
            </div>

        </div>
        
        <div class="invoiceTitle">
            <% 
            DateTime orderDate = DateTime.Now;
            if (order.OrderDate.HasValue)
                orderDate = order.OrderDate.Value;
            string dateString = string.Empty;
            dateString += orderDate.Day.ToString("00");
            dateString += " " + months[orderDate.Month] + " ";
            dateString += orderDate.Year;
            dateString += " p.";
            
            %>
            Рахунок на оплату №__ від  <%= dateString %>
        </div>
        <div class="invoiceDetails">
            <table>
                <tr>
                    <td>
                        Постачальник:
                    </td>
                    <td style="font-weight:bold;">
                         ФОП Морозова Валентина Петрівна																										
                    </td>
                </tr>
                <tr>
                    <td>
                      
                    </td>
                    <td style="font-size:9pt;">
                        Р/с 26006000451971, Банк ВАТ Київська філія №2 ВАТ "Універсал Банк", МФО 322001   <br />
                         код за ДРФО 2168600067,<br />
                         Не є платником податку на прибуток на загальних підставах
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Покупець:
                    </td>
                    <td valign="top">
                        <% 
                            string name = WebSession.Order.GetPaymentProperty("OrgName");
                            if (string.IsNullOrEmpty(name))
                                name = "___________________________________";
                        %>
                        <%= name %><br />
                        Замовлення №<%= WebSession.Order.Id %>
                    </td>
                </tr>
            </table>
            <table class="orderItems">
                <tr>
                    <th class="number" valign="middle" align="center">№</th>
                    <th class="product" valign="middle" align="center">Товар</th>
                    <th class="quantity" valign="middle" align="center">Кіл-сть</th>
                    <th class="measure" valign="middle" align="center">Од.</th>
                    <th class="price" valign="middle" align="center">Ціна</th>
                    <th class="total" valign="middle" align="center">Сума</th>
                </tr>
                <tbody>
                <%int i = 1; %>
                <% foreach (OrderItem item in orderItems){ %>
                <tr>
                    <td>
                        <%= i %>
                    </td>                
                    <td>
                        <%= item.Name %>
                    </td>
                    <td>
                        <%= item.Quantity %>
                    </td>
                    <td>
                        шт.
                    </td>
                    <td>
                        <%= item.Price.ToString("0.00", CultureInfo.CurrentUICulture)  %>
                    </td>
                    <td>
                        <%= (item.Price * item.Quantity).ToString("0.00", CultureInfo.CurrentUICulture)%>
                    </td>
                </tr>
                <% i++; %>
                <% } %>
                </tbody>
                <tfoot>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td align="left">
                            Всього:
                        </td>
                        <td align="left">
                            <%= orderItems.GetTotalAmount() %>
                        </td>
                    </tr>
                </tfoot>
            </table>
            
            <div class="invoiceFooter">
                Всього найменувань <%= orderItems.Count() %>, на суму <%= Html.RenderPrice(orderItems.GetTotalAmount(), Currencies.Hrivna, 2, " ") %>.
                <p>
                    <%= Html.SpellPrice(orderItems.GetTotalAmount()) %>
                </p>
            </div>
        </div>
    </div>
</body>
</html>
<script type="text/javascript">
    window.print();
</script>