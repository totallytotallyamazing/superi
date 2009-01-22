<%@ Import Namespace="Superi.Features"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RandomImages.ascx.cs" Inherits="Controls_RandomImages" %>
<asp:Repeater runat="server" ID="rImages" OnItemDataBound="rImages_ItemDataBound">
    <ItemTemplate>
        <div class="randomImageHolder">
            <asp:HyperLink runat="server" ID="hlRandomImage"></asp:HyperLink>
        </div>
    </ItemTemplate>
</asp:Repeater>