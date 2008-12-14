<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SubMenu.ascx.cs" Inherits="Controls_SubMenu" %>
<%@ Import Namespace="Superi.Features" %>
<div id="subMenuDiv">
    <asp:Repeater runat="server" ID="rItems">
        <ItemTemplate>
            <a class="subMenuLink" href="<%# DefaultValues.BaseUrl+Eval("Name") %>"><%# (Container.DataItem as Navigation).Texts[WebSession.Language] %></a><br />
            <asp:Repeater ID="rSubItems" runat="server">
                <ItemTemplate>
                    &nbsp;&nbsp;&nbsp;&nbsp;<a class="subMenuLink" href="<%# DefaultValues.BaseUrl+Eval("Name") %>"><%# (Container.DataItem as Navigation).Texts[WebSession.Language] %></a><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:Repeater>
</div>