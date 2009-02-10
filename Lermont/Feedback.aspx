<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Feedback" %>
<%@ Register TagPrefix="superi" Assembly="Superi" Namespace="Superi.CustomControls" %>
<%@ Import Namespace="Superi.Common" %>
<asp:Content ContentPlaceHolderID="cphTitle" runat="server">
    <link rel="Stylesheet" href="<%= WebSession.BaseUrl + "css/feedback.css" %>" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="textDiv">
        <asp:Repeater runat="server" ID="rComments" 
        onitemdatabound="rComments_ItemDataBound">
            <ItemTemplate>
                <div class="commentsSection">
                    <superi:ResourceLabel ID="rlName" ResourceName="name" runat="server"/>
                    <asp:Label ID="lName" runat="server"></asp:Label><br />
                    <asp:Label runat="server" ID="lEmail" Text="Email: "></asp:Label>
                    <asp:HyperLink runat="server" ID="hlEmail"></asp:HyperLink>
                    <br />
                    <superi:ResourceLabel ID="rlComment" ResourceName="comment" runat="server" /><br />
                    <asp:Literal runat="server" ID="lComment"></asp:Literal>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div>
            <div class="commentsSection">
                <superi:ResourceLabel ID="rlName" ResourceName="name" runat="server" AssociatedControlID="tbName" /><br />
                <asp:TextBox runat="server" ID="tbName" CssClass="commentsBox"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" EnableClientScript="true" 
                    ControlToValidate="tbName" Display="Dynamic" ErrorMessage="*" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                <br />
                <asp:Label runat="server" ID="lEmail" Text="Email:" AssociatedControlID="tbEmail"></asp:Label><br />
                <asp:TextBox runat="server" ID="tbEmail" CssClass="commentsBox"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" Display="Dynamic"
                    SetFocusOnError="true" ID="revEmail" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="tbEmail"></asp:RegularExpressionValidator>
                <br />
                <superi:ResourceLabel ID="rlComment" ResourceName="comment" runat="server" AssociatedControlID="tbComment" /><br />
                <asp:TextBox runat="server" ID="tbComment" TextMode="MultiLine" CssClass="commentsBox commentsArea"></asp:TextBox><br /><br />
                <superi:ResourceButton CssClass="loginButton" runat="server" ResourceName="send" ID="rbPostComment" OnClick="rbPostComment_Click" />
            </div>
        </div>
    </div>
</asp:Content>

