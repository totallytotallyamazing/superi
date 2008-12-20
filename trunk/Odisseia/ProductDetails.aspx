<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" %>


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
                <div id="comments">
                    
                </div>
            </div>
            <div id="description">
                <asp:Literal runat="server" ID="lDescription"></asp:Literal>
            </div>
        </div>
        <div id="vouchers">
        
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

