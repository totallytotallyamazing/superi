<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Comments.aspx.cs" Inherits="Administration_Comments" %>
<%@ Register TagPrefix="admin" TagName="CommentsEditor" Src="~/Administration/Controls/FAQEditor.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <admin:CommentsEditor runat="server" />
</asp:Content>

