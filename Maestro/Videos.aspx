<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Videos.aspx.cs" Inherits="Videos" %>
<%@ Register Assembly="Superi" Namespace="Superi.CustomControls" TagPrefix="cc1" %>
<%@ Register TagName="MediaMenu" TagPrefix="maestro" Src="~/Controls/MediaMenu.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div class="mediaMenu">
        <maestro:MediaMenu CurrentIndex="2" runat="server" />
    </div>
    <center>
        <asp:Repeater runat="server" ID="rVideos">
            <ItemTemplate>
                <asp:Literal ID="lEmbed" runat="server" Text='<%# Bind("Embed") %>'></asp:Literal><br />
                <cc1:ResourceWritter ID="rwTitle" ResourceId='<%# Bind("TitleTextId") %>' runat="server" />
            </ItemTemplate>
            <SeparatorTemplate>
                <hr style="margin:10px 0; width:430px;" />
            </SeparatorTemplate>
        </asp:Repeater>
        <div class="pagerContainer">
            <cc1:Pager CurrentPageCssClass="currentPage" PageCssClass="page" ID="pPages" runat="server" />
        </div>
    </center>
<div class="mediaMenu">
    <maestro:MediaMenu ID="MediaMenu1" CurrentIndex="2" runat="server" />
</div>
</asp:Content>

