<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MainMenu.ascx.cs" Inherits="Controls_MainMenu" %>
<asp:Repeater runat="server" ID="rItems" onitemdatabound="rItems_ItemDataBound">
    <ItemTemplate>
        <asp:HyperLink runat="server" ID="hlItem" CssClass="menuLink"></asp:HyperLink>
    </ItemTemplate>
    <SeparatorTemplate>&nbsp;</SeparatorTemplate>
</asp:Repeater>