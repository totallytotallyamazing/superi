<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Videos.aspx.cs" Inherits="Videos" %>
<%@ Register Assembly="Superi" Namespace="Superi.CustomControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
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
</asp:Content>

