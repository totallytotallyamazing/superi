<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Vouchers.ascx.cs" Inherits="Controls_Vouchers" %>
<asp:Repeater runat="server" ID="rVouchers" 
    onitemdatabound="rVouchers_ItemDataBound">
    <ItemTemplate>
        <div class="voucher" id="divVoucher" runat="server">
            <asp:ImageButton runat="server" ID="ibOrder" CssClass="orderButton" />
        </div>
    </ItemTemplate>
    <SeparatorTemplate>
        <asp:PlaceHolder runat="server" ID="phSeparator">
            <div class="voucherSeparator"></div>    
        </asp:PlaceHolder>
    </SeparatorTemplate>
</asp:Repeater>
