<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Navigation.ascx.cs" Inherits="Controls_Navigation" %>
<asp:Repeater runat="server" ID="rItems" OnItemDataBound="rItems_ItemDataBound">
    <ItemTemplate>
        <asp:HyperLink runat="server" ID="hlNavigationItem"> </asp:HyperLink>
    </ItemTemplate>
    <SeparatorTemplate>
        <span>&gt;</span>
    </SeparatorTemplate>
</asp:Repeater>
