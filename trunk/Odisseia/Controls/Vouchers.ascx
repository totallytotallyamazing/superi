<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Vouchers.ascx.cs" Inherits="Controls_Vouchers" %>
<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(VouchersEndRequest);


    function VouchersEndRequest(sender, args) {
        var bw = $("#main").innerWidth();
        var bh = visibleAreaSize().h;
        var panel = $("#<%= pOrderForm.ClientID %>");
        panel.css("display", "block");
        panel.css("left", bw / 2 - panel.width() / 2);
        panel.css("top", bh / 2 - panel.height() / 2 + $("html").scrollTop());
    }
</script>

<asp:Repeater runat="server" ID="rVouchers" 
    onitemdatabound="rVouchers_ItemDataBound" onitemcommand="rVouchers_ItemCommand">
    <ItemTemplate>
        <div class="voucher" id="divVoucher" runat="server">
            <asp:ImageButton runat="server" ID="ibOrder" CommandName="Order" CssClass="orderButton" />
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
                Вы выбрали сертификат ресторана Da Vinci - Fish club на 1000 грн.,                 пожалуйста укажите Ваши данныйе и мы свяжимся с Вами в течени                 часа.
            </div>
            <div id="divOrderForm">
                <asp:Label ID="l1" runat="server" Text="Ваше имя: " AssociatedControlID="tbName">
                    <asp:TextBox runat="server" ID="tbName" CssClass="textBox"></asp:TextBox>
                </asp:Label>
                <br />
                <asp:Label ID="l2" runat="server" Text="E-mail: " AssociatedControlID="tbEmail">
                    <asp:TextBox runat="server" ID="tbEmail" CssClass="textBox"></asp:TextBox>
                </asp:Label>
                <br />
                <asp:Label ID="l3" runat="server" Text="Тел.: " AssociatedControlID="tbPhone">
                    <asp:TextBox runat="server" ID="tbPhone" CssClass="textBox"></asp:TextBox>
                </asp:Label>
            </div>
            <div id="orderSend">
                <asp:ImageButton runat="server" ID="ibSendOrder" ImageUrl="~/Images/sendButton.jpg" onclick="ibSendOrder_Click" /> 
            </div>
        </asp:Panel>    
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="rVouchers" EventName="ItemCommand" />
    </Triggers>
</asp:UpdatePanel>

