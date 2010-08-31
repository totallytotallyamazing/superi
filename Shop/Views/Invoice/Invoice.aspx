<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Счет</title>
    <style type="text/css">
        .invoiceHeader div{float:left;}
        .invoiceHeader p span{display:inline-block;}
        .invoiceHeader p span.label, .codeLabel{width:100px;}
        .receiver{font-weight:bold;}
        .codeLabel{line-height:40px;}
        .code{width:200px; height:30px; border:2px solid black; text-align:center; padding-top:10px;}
        .bankName{font-weight:bold;}
    </style>
</head>
<body>
    <div id="main">
        <div class="attention">
            Увага! Оплата цього рахунку означає погодження з умовами поставки товарів. Товар
            відпускається за фактом надходження коштів на р/р Постачальника.
        </div>
        <div class="invoiceHeader">
            <div class="header">
                Платiжне доручення
            </div>
            <p>
                <span class="label">Одержувач</span> <span class="receiver">ФОП Морозова Валентина Петрівна</span>
            </p>
            <p>
                <span class="codeLabel">Код</span> <span class="code">2168600067</span>
            </p>
            <p>
                Банк одержувача<br /><br />
                <span class="bankName">
                    ВАТ Київська філія №2 ВАТ "Універсал Банк"
                </span>
            </p>
            <div>
            </div>
            <div>
            </div>
            <div>
            </div>
        </div>
    </div>
</body>
</html>
