<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MonthList.ascx.cs" Inherits="Controls_MonthList" %>
<asp:Repeater runat="server" ID="rMonthList" 
    onitemcommand="rMonthList_ItemCommand" 
    onitemdatabound="rMonthList_ItemDataBound">
    <ItemTemplate>
        <div id="divMonth" runat="server" class="monthListItemContainer">
            <asp:LinkButton runat="server" ID="lbMonth" CssClass="monthListItem"></asp:LinkButton>
        </div>
    </ItemTemplate>
</asp:Repeater>