<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" Title="Untitled Page" %>
<%@ Register TagPrefix="Controls" Namespace="CustomControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <div id="booksHolder">
            <asp:Repeater ID="rBooks" runat="server" OnItemDataBound="rBooks_ItemDataBound">
                <ItemTemplate>
                    <div class="book">
                        <div class="bookCover">
                            <asp:Hyperlink CssClass="bookImageLink" BorderColor="white" BorderWidth="1" runat="server" ID="hlCover"></asp:Hyperlink>
                        </div>
                        <div class="bookInfo">
                            <div class="bookTitle">
                                <asp:Hyperlink runat="server" ID="hlTitle" CssClass="bookTitleLink"></asp:Hyperlink>
                                &nbsp;
                                <asp:HyperLink runat="server" ID="hlNewBook" CssClass="bookNewBookLink">
                                    <Controls:TextWriter TextName="newBook" runat="server"></Controls:TextWriter>
                                </asp:HyperLink>
                            </div>
                            <div class="bookSubTitle">
                                <asp:Literal runat="server" ID="lSubTitle"></asp:Literal>
                            </div>
                            <div class="bookPublisher">
                                <asp:HyperLink CssClass="bookPublisherLink" runat="server" ID="hlPublisher"></asp:HyperLink>
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

