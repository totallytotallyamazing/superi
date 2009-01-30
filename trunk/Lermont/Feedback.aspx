<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Feedback" %>
<%@ Register TagPrefix="superi" Assembly="Superi" Namespace="Superi.CustomControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater runat="server" ID="rComments" 
    onitemdatabound="rComments_ItemDataBound">
        <ItemTemplate>
            <div class="commentsSection">
                <superi:ResourceLabel ID="rlName" ResourceName="name" runat="server"/>
                <asp:Label ID="lName" runat="server"></asp:Label><br />
                <asp:Label runat="server" ID="lEmail" Text="Email: "></asp:Label>
                <asp:HyperLink runat="server" ID="hlEmail"></asp:HyperLink>
                <superi:ResourceLabel ID="rlComment" ResourceName="comment" runat="server" /><br />
                <asp:Literal runat="server" ID="lComment"></asp:Literal>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div>
        <div class="commentsSection">
            <superi:ResourceLabel ID="rlName" ResourceName="name" runat="server" AssociatedControlID="tbName" /><br />
            <asp:TextBox runat="server" ID="tbName" CssClass="commentsBox"></asp:TextBox><br />
            <asp:Label runat="server" ID="lEmail" Text="Email" AssociatedControlID="tbEmail"></asp:Label><br />
            <asp:TextBox runat="server" ID="tbEmail" CssClass="commentsBox"></asp:TextBox><br />
            <superi:ResourceLabel ID="rlComment" ResourceName="comment" runat="server" AssociatedControlID="tbComment" /><br />
            <asp:TextBox runat="server" ID="tbComment" CssClass="commentsBox"></asp:TextBox><br />
            <superi:ResourceButton runat="server" ResourceName="send" ID="rbPostComment" OnClick="rbPostComment_Click" />
        </div>
    </div>
</asp:Content>

