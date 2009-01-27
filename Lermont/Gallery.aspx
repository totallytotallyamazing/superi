<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Gallery" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Repeater ID="rItems" runat="server" OnItemDataBound="rGalleries_ItemDataBound">
        <ItemTemplate>
            <asp:Panel runat="server" ID="pImageHolder">
                <asp:HyperLink runat="server" ID="hlImage"></asp:HyperLink><br />
            </asp:Panel>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>


