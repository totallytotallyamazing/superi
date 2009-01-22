<%@ Import Namespace="Superi.Features"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SubMenu.ascx.cs" Inherits="Controls_SubMenu" %>
    <ul>
        <asp:Repeater runat="server" ID="rItems" OnItemDataBound="rItems_ItemDataBound">
            <ItemTemplate>
                <li class="subMenuItem" id="liSubMenuItem" runat="server" onmouseover="switchClass(this, 'subMenuItemActive')" onmouseout="switchClass(this, 'subMenuItem')">
                    <%--<a href="<%# WebSession.BaseUrl+Eval("Path") %>"><%# ((Navigation)Container.DataItem).Texts[WebSession.Language] %></a>--%>
                    <asp:HyperLink ID="hlSubMenuItem" runat="server"></asp:HyperLink>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>