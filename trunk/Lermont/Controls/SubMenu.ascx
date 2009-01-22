<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SubMenu.ascx.cs" Inherits="Controls_SubMenu" %>
<%@ Import Namespace="Superi.Features" %>
<div id="subMenuDiv">
    <asp:Repeater runat="server" ID="rItems">
        <ItemTemplate>
            <div class="subMenuItem" onmouseover="setBackgroundImage(this, 'subMenuDotHover.jpg')" onmouseout="setBackgroundImage(this, 'subMenuDot.jpg')">
                <asp:HyperLink runat="server" ID="hlItem"></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>