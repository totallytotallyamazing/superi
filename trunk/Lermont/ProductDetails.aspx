<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" Title="Untitled Page" %>
<%@ Register TagPrefix="Controls" Namespace="CustomControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:PlaceHolder runat="server" ID="phStyles"></asp:PlaceHolder>
    <div id="productDetailsContainer">
        <div class="productImage">
            <asp:Image runat="server" ID="iPicture" BorderColor="white" BorderWidth="1" />
        </div>
        <div class="productInfo">
            <div class="productTitle">
                <Controls:ResourceWriter ID="twTitle" runat="server"></Controls:ResourceWriter>
            </div>
            <div class="productSubTitle">
                <Controls:ResourceWriter ID="twSubTitle" runat="server"></Controls:ResourceWriter>
            </div>
            <div class="productAdditionalInfo">
                <Controls:ResourceWriter ID="twAdditionalInfo" runat="server"></Controls:ResourceWriter>
            </div>
            <div class="productDescription">
                <Controls:ResourceWriter ID="twDescription" runat="server"></Controls:ResourceWriter>
            </div>
            <div class="bookPublisher">
                <asp:HyperLink runat="server" ID="hlPublisher"></asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>