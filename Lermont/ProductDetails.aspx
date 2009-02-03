<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" Title="Untitled Page" %>
<%@ Register TagPrefix="Controls" Assembly="Superi" Namespace="Superi.CustomControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:PlaceHolder runat="server" ID="phStyles"></asp:PlaceHolder>
    <div id="productDetailsContainer">
        <div class="productImage">
            <asp:Image runat="server" ID="iPicture" BorderColor="white" BorderWidth="1" />
        </div>
        <div class="productInfo">
            <div class="productTitle">
                <Controls:ResourceLabel ID="twTitle" runat="server"></Controls:ResourceLabel>
            </div>
            <div class="productSubTitle">
                <Controls:ResourceLabel ID="twSubTitle" runat="server"></Controls:ResourceLabel>
            </div>
            <div class="productAdditionalInfo">
                <Controls:ResourceLabel ID="twAdditionalInfo" runat="server"></Controls:ResourceLabel>
            </div>
            <div class="productDescription">
                <Controls:ResourceLabel ID="twDescription" runat="server"></Controls:ResourceLabel>
            </div>
            <div class="bookPublisher">
                <asp:HyperLink runat="server" ID="hlPublisher"></asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>