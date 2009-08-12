<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Order>>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Controllers" %>
<%@ Import Namespace="AjaxControlToolkitMvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    MakeOrder
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="subHeader" style="text-align:center">
    <center>
        <% Html.RenderPartial("Cart");  %>
    </center>
</div>
<%
    string pickerLocale = (SystemSettings.CurrentLanguage == "uk-UA") ? "uk" : "ru";
%>
    <script type="text/javascript">
        var settings = {};

        $(function() {
            $.datepicker.setDefaults($.extend({ showMonthAfterYear: false }, $.datepicker.regional['']));
            applyDropShadows(".orderDetails .logo img", "shadow3");
            $("#deliveryDate").datepicker($.datepicker.regional["<%= pickerLocale %>"]);
            $("#deliveryDate").datepicker("setDate", new Date());
        })

        function setOrderTime() {
            var date = $("#deliveryDate").datepicker("getDate");
            $get("deliveryDateTime").value = date.getDate() + "." + (1 * date.getMonth() + 1) + "." + date.getYear() + " " + $get("deliveryTime").value;
        }
    </script>

    <% foreach (var order in Model)
       {%>
       
    <div class="orderDetails">
        <div class="logo">
            <%= Html.Image("~/Image/ShowLogo/" + order.DealerReference.EntityKey.EntityKeyValues[0].Value) %>
        </div>
        
          <%{%>
        <div class="discount">
            <%= Html.ResourceString("InputVoucher") %>
            <%= Html.TextBox("voucherCode_" + order.GetHashCode()) %>
            <div class="respectDiscount">
                <%= Html.ResourceString("DiscountWillBeRespected") %>
            </div>
        </div>
        <div class="paymentTypesHeader">
            <%= Html.ResourceString("SelectPaymentType") %>
        </div>
        <div class="paymentTypes">
            <center>
                <table>
                <% 
                    List<SelectListItem> paymentTypes = new List<SelectListItem>();
                    paymentTypes.Add(new SelectListItem { Text = Html.ResourceString("Encash"), Value = ((int)PaymentTypes.Encash).ToString(), Selected = true });
                    paymentTypes.Add(new SelectListItem { Text = Html.ResourceString("Card"), Value = ((int)PaymentTypes.Card).ToString() });
                    paymentTypes.Add(new SelectListItem { Text = Html.ResourceString("Noncash"), Value = ((int)PaymentTypes.Noncash).ToString() });
                    string[] options = Html.RadioButtonList("paymentType_" + order.GetHashCode(), paymentTypes, new { onblur = "tableChanged(settings, this)" });
                    for (int i = 0; i<options.Length; i++)
                    {%>
                    <tr>
                        <td><%= paymentTypes[i].Text %></td>
                        <td><%= options[i] %></td>
                    </tr>    
                  <%}
                %>
                </table>
            </center>
        </div>
        <%} %>
        <%} %>
    </div>
    <div style="text-align:center; margin-top:50px;">
        <%= Html.CheckBox("agreed", false) %>
        <%= Html.ResourceString("Agreed") %>
    </div>
    <div class="orderDone">
        <center>
            <table>
                <tr>
                    <td valign="middle"><%= Html.ResourceString("Done") %>!</td>
                    <td><%= Html.SubmitImage("", "~/Content/img/tickMark.jpg", new { onclick = "collectChanges(settings, 'orderSettings'); setOrderTime(); $get('makeOrder').submit();" })%></td>
                </tr>
            </table>
        </center>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Html.RegisterCss("~/Content/Cart.css") %>
    <%= Html.RegisterCss("~/Content/shadows.css")%>
    <%= Html.RegisterJS("dropshadow.js")%>
    <%= Html.RegisterJS("ui.datepicker-ru.js")%>
    <%= Html.RegisterJS("ui.datepicker-uk.js")%>
    <%= Html.RegisterCss("~/Content/redmond/jquery.ui.css")%>
    <%= Html.RegisterJS("jquery.ui.js")%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">

    <% using (Html.BeginForm("MakeOrder", "Cart", FormMethod.Post, new { id = "makeOrder"})){ %>
        <%= Html.Hidden("orderSettings")%>
        <div class="yourDetails">
            <div class="menuHeader centered">
                <%= Html.ResourceString("YourDetails") %>
            </div>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="parameterName"><%= Html.ResourceString("FirstName") %></td>
                    <td class="parameterValue">
                        <%= Html.TextBox("firstName") %>
                    </td>
                </tr>
                <tr>
                    <td class="parameterName"><%= Html.ResourceString("LastName")%></td>
                    <td class="parameterValue"><%= Html.TextBox("lastName") %></td>
                </tr>
                <tr>
                    <td class="parameterName"><%= Html.ResourceString("City") %></td>
                    <td class="parameterValue">
                        <%= Html.Hidden("city", "ส่ๅโ") %>
                    </td>
                </tr>
                <tr>
                    <td class="parameterName"><%= Html.ResourceString("DeliveryAddress")%></td>
                    <td class="parameterValue"><%= Html.TextArea("deliveryAddress")%></td>
                </tr>
                <tr>
                    <td class="parameterName"><%= Html.ResourceString("ContactPhone") %></td>
                    <td class="parameterValue"><%= Html.TextBox("contactPhone")%></td>
                </tr>
                <tr>
                    <td class="parameterName"><nowrap>E-mail</nowrap></td>
                    <td class="parameterValue"><%= Html.TextBox("email")%></td>
                </tr>
                <tr>
                    <td class="parameterName"><%= Html.ResourceString("Comments") %></td>
                    <td class="parameterValue"><%= Html.TextArea("comments")%></td>
                </tr>
            </table>
            <div class="menuFooter"></div>
        </div>
        <%= Html.Hidden("deliveryDateTime", DateTime.Now)%>
        <%} %>
        
        <div class="deliveryDate">
            <div class="menuHeader centered">
                <%= Html.ResourceString("DeliveryDateTime") %>
            </div>
            <div class="datePicker">
                <%= Html.TextBox("deliveryDate") %><br />
                <%= Html.TextBox("deliveryTime", DateTime.Now.AddHours(1).ToString("HH:mm")) %>
                <%= Html.Hidden("deliveryTimeClientState") %>
                <%= Ajax.MaskEdit("deliveryTimeClientState", MaskTypes.Time, "99:99", false, false, "deliveryTime")%>
            </div>
            <div class="menuFooter"></div>
        </div>
    

</asp:Content>
