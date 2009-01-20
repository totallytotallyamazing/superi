<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" %>
<%@ Register TagPrefix="od" TagName="Vouchers" Src="~/Controls/Vouchers.ascx" %>

<asp:Content ID="titleContent" ContentPlaceHolderID="titlePlaceHolder" runat="server">
    <link rel="Stylesheet" href="css/productDescription.css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="detailsContainer">
        <div id="tradeMarkPropertues">
            <div id="commentsAndLogo">
                <div id="logo">
                    <asp:Image runat="server" ID="iLogo" />
                </div>
                <div id="comments" class="fixPng">
                    
                </div>
            </div>
            <div id="description">
                <asp:Literal runat="server" ID="lDescription"></asp:Literal>
            </div>
        </div>
        <div id="vouchers">
            <od:Vouchers runat="server" ID="vVouchers" />
        </div>
        <div id="customDescription">
            <asp:Literal runat="server" ID="lShortDescription"></asp:Literal>
        </div>
        <div id="additionalProperties">
            <div>
                <strong>Кому подарть:</strong>&nbsp;
                <asp:Literal runat="server" ID="lRecipient"></asp:Literal>                
            </div>
            <div>
                <strong>Когда подарить:</strong>&nbsp;
                <asp:Literal runat="server" ID="lOccasion"></asp:Literal>                
            </div>
            <div>
                <strong>Что вы получите</strong>&nbsp;
                <asp:Literal runat="server" ID="lEventSuggestion"></asp:Literal>                
            </div>
        </div>
    </div>
</asp:Content>

