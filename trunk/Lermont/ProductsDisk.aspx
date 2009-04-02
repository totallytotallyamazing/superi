<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductsDisk.aspx.cs" Inherits="ProductsDisk" Title="Untitled Page"  %>
<%@ Register TagPrefix="Controls" Assembly="Superi" Namespace="Superi.CustomControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <div id="booksHolder">
            <asp:Repeater ID="rBooks" runat="server" OnItemDataBound="rBooks_ItemDataBound">
                <ItemTemplate>
                    <div class="book">
                        <div class="bookCover">
                            <asp:Hyperlink CssClass="bookImageLink" Target="_blank" BorderColor="white" BorderWidth="1" runat="server" ID="hlCover"></asp:Hyperlink>
                        </div>
                        <div class="bookInfo">
                            <div class="bookTitle">
                                <asp:Hyperlink runat="server" Target="_blank" ID="hlTitle" CssClass="bookTitleLink"></asp:Hyperlink>
                                &nbsp;
                                <asp:HyperLink runat="server" ID="hlNewBook" Target="_blank" CssClass="bookNewBookLink">
                                    <Controls:TextWriter ID="TextWriter1" TextName="newBook" runat="server"></Controls:TextWriter>
                                </asp:HyperLink>
                            </div>
                            <div class="bookSubTitle">
                                <asp:Literal runat="server" ID="lSubTitle"></asp:Literal>
                            </div>
                            <div class="bookPublisher">
                                <asp:HyperLink Target="_blank" CssClass="bookPublisherLink" runat="server" ID="hlPublisher"></asp:HyperLink>
                            </div>
                            <div>
                                <Controls:ResourceLabel ID="rlPrice" runat="server" ResourceName="price"></Controls:ResourceLabel>     
                                &nbsp;
                                <asp:Label ID="tbPrice" runat="server"/>
                                <Controls:ResourceLabel ID="lCurrency" runat="server" ResourceName="currency"/>
                                <br /><br />
                                <asp:CheckBox ID="cbBuy" runat="server" />&nbsp;
                                <Controls:ResourceLabel ID="rlBuy" runat="server" ResourceName="buy"/>
                            </div>
                            <div class="bookShortDescription">
                              
                                <asp:Literal runat="server" ID="lDescription"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <SeparatorTemplate>
                    <div class="bookSeparator"></div>
                </SeparatorTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

