<%@ Import namespace="Superi.Features"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExtraLeftMenu.ascx.cs" Inherits="Controls_ExtraLeftMenu" %>
<div id="extraLeftMenu">
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