<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Vouchers.ascx.cs" Inherits="Controls_Vouchers" %>
<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(VouchersEndRequest);

    function VouchersEndRequest(sender, args) {
        var bw = $("#main").innerWidth();
        var bh = visibleAreaSize().h;
        var panel;
        if (sender._postBackSettings.panelID.indexOf("ibOrder")>-1) {
            panel = $("#<%= pOrderForm.ClientID %>");
            panel.css("display", "block");
            panel.css("left", bw / 2 - panel.width() / 2);
            panel.css("top", bh / 2 - panel.height() / 2 + $("html").scrollTop());
        }
        if (sender._postBackSettings.panelID.indexOf("ibSendOrder")>-1) {
            panel = $("#<%= pThankYou.ClientID %>");
            panel.css("display", "block");
            panel.css("left", bw / 2 - panel.width() / 2);
            panel.css("top", bh / 2 - panel.height() / 2 + $("html").scrollTop());
        }
    }
</script>

<asp:Repeater runat="server" ID="rVouchers" 
    onitemdatabound="rVouchers_ItemDataBound" onitemcommand="rVouchers_ItemCommand">
    <ItemTemplate>
        <div class="voucher" id="divVoucher" runat="server">
            <asp:ImageButton runat="server" ID="ibOrder" CommandName="Order" ImageUrl="~/Images/orderButton.jpg" CssClass="orderButton" />
        </div>
    </ItemTemplate>
    <SeparatorTemplate>
        <asp:PlaceHolder runat="server" ID="phSeparator">
            <div class="voucherSeparator"></div>    
        </asp:PlaceHolder>
    </SeparatorTemplate>
</asp:Repeater>
<asp:UpdatePanel runat="server" ID="upOrder">
    <ContentTemplate>
        <asp:HiddenField runat="server" ID="hfVoucheId" ></asp:HiddenField>
        <asp:Panel ID="pOrderForm" runat="server" CssClass="orderForm">
            <div id="orderTop">
               <asp:Image runat="server" ImageUrl="~/Images/baloonClose.JPG" ToolTip="x" ID="iCloseOrder" />
            </div>
            <div id="orderTitle">
                Заказать сертификат
            </div>
            <div id="orderText">
                Вы выбрали сертификат <asp:Label Font-Bold="true" runat="server" ID="lTradeMark"></asp:Label>                 на <asp:Label runat="server" ID="lPrice" Font-Bold="true"></asp:Label> грн.,                 пожалуйста укажите Ваши данныйе и мы свяжимся с Вами в течени                 часа.
            </div>
            <div id="divOrderForm">
                <asp:RequiredFieldValidator ValidationGroup="1" Display="Dynamic" SetFocusOnError="true" 
                    ControlToValidate="tbName" ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Введите имя<br/>"></asp:RequiredFieldValidator>
                <asp:Label ID="l1333" runat="server" Text="Ваше имя: " AssociatedControlID="tbName">
                    <asp:TextBox EnableViewState="false" runat="server" ID="tbName" CssClass="textBox"></asp:TextBox>
                </asp:Label>
                <br />
                <asp:Label ID="l211" runat="server" Text="E-mail: " AssociatedControlID="tbEmail">
                    <asp:TextBox EnableViewState="false" runat="server" ID="tbEmail" CssClass="textBox"></asp:TextBox>
                </asp:Label>
                <br />
                <asp:RequiredFieldValidator ValidationGroup="1" Display="Dynamic" SetFocusOnError="true" 
                    ControlToValidate="tbPhone" ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Введите телефон<br/>"></asp:RequiredFieldValidator>
                <asp:Label ID="l355" runat="server" Text="Тел.: " AssociatedControlID="tbPhone">
                    <asp:TextBox EnableViewState="false" runat="server" ID="tbPhone" CssClass="textBox"></asp:TextBox>
                </asp:Label>
            </div>
            <div id="orderSend">
                <asp:ImageButton ValidationGroup="1" CausesValidation="true" runat="server" ID="ibSendOrder" ImageUrl="~/Images/sendButton.jpg" onclick="ibSendOrder_Click" /> 
            </div>
        </asp:Panel>    
        <asp:Panel runat="server" ID="pThankYou" CssClass="thankYou" Visible="false">
            <div id="thankYouTop">
                <asp:Image runat="server" ImageUrl="~/Images/baloonClose.JPG" ToolTip="x" ID="iCloseTanks" /> 
            </div>
            <div id="thankYouMessage">
                Спасибо за покупку
            </div>
            <div id="thankYouClose">
                <asp:Image runat="server" ImageUrl="~/Images/closeButton.jpg" ToolTip="Закрыть" ID="iCloseThanksButton" />
            </div>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="rVouchers" EventName="ItemCommand" />
    </Triggers>
</asp:UpdatePanel>

