<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MainMenu.ascx.cs" Inherits="Controls_MainMenu" %>

<div id="mainMenuContainer">
    <asp:Repeater runat="server" ID="rItems" OnItemDataBound="rItems_ItemDataBound">
        <ItemTemplate>
            <asp:Panel CssClass="mainMenuItem" runat="server" ID="pItem">
                <asp:HyperLink runat="server" ID="hlItem"></asp:HyperLink>
                <asp:Literal runat="server" ID="lItem"></asp:Literal>
            </asp:Panel>
        </ItemTemplate>
    </asp:Repeater>
</div>