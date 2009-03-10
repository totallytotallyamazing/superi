<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Videos.aspx.cs" Inherits="Videos" %>

<%@ Register Assembly="Superi" Namespace="Superi.CustomControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <center>
        <asp:LinqDataSource ID="ldsVideos" runat="server" 
            ContextTypeName="VideosDataContext" Select="new (TitleTextID, Embed)" 
            TableName="Videos">
        </asp:LinqDataSource>
        
    <asp:Repeater runat="server" ID="rVideos" DataSourceID="ldsVideos">
        <ItemTemplate>
            <asp:Literal ID="lEmbed" runat="server" Text='<%# Bind("Embed") %>'></asp:Literal><br />
            <cc1:ResourceWritter ID="rwTitle" ResourceId='<%# Bind("TitleTextId") %>' runat="server" />
        </ItemTemplate>
        <SeparatorTemplate>
            <hr style="margin:10px 0; width:430px;" />
        </SeparatorTemplate>
    </asp:Repeater>
    </center>
</asp:Content>

