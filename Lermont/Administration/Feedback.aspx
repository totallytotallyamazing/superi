<%@ Page Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Administration_Feedback" Title="Untitled Page" %>
<%@ Register TagPrefix="admin" TagName="CommentEditor" Src="~/Administration/Controls/FAQEditor.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <admin:CommentEditor runat="server" />
</asp:Content>

