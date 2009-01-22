<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Galleries.aspx.cs" Inherits="Galleries" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="galleryContainer">
        <asp:PlaceHolder runat="server" ID="phGalleries">
            <asp:Repeater ID="rGalleries" runat="server" OnItemDataBound="rGalleries_ItemDataBound">
                <ItemTemplate>
                    <div class="oddGalleryItem">
                        <asp:HyperLink runat="server" ID="hlImage" BorderWidth="1" BorderColor="black"></asp:HyperLink><br />
                        <asp:HyperLink runat="server" ID="hlTitle"></asp:HyperLink>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="evenGalleryItem">
                        <asp:HyperLink runat="server" ID="hlImage" BorderWidth="1" BorderColor="black"></asp:HyperLink><br />
                        <asp:HyperLink runat="server" ID="hlTitle"></asp:HyperLink>
                    </div>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phGallery">
            <asp:Repeater ID="rItems" runat="server" OnItemDataBound="rItems_ItemDataBound">
                <ItemTemplate>
                    <asp:Panel runat="server" ID="pImageHolder">
                        <asp:HyperLink runat="server" ID="hlImage" BorderColor="black" BorderWidth="1"></asp:HyperLink><br />
                    </asp:Panel>
                </ItemTemplate>
            </asp:Repeater>
        </asp:PlaceHolder>
    </div>
</asp:Content>

