<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TradeMarksFrame.ascx.cs" Inherits="Administration_Controls_TradeMarksFrame" %>
<asp:DataList runat="server" ID="dlTradeMark" RepeatColumns="5" 
    onitemcommand="dlTradeMark_ItemCommand" 
    onitemdatabound="dlTradeMark_ItemDataBound" CellSpacing="2" 
    GridLines="Both" >
    <ItemStyle HorizontalAlign="Center" />
    <ItemTemplate>
        <div style="width:60px; height:60px;">
            <asp:HyperLink runat="server" ID="hlTradeMark"/>
        </div>
        <asp:LinkButton runat="server" ID="lbDelete" CommandName="Delete" Text="X"></asp:LinkButton>
    </ItemTemplate>
</asp:DataList>