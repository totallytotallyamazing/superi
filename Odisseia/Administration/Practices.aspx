<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="false" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Practices.aspx.cs" Inherits="Administration_Practices" Title="Untitled Page" %>
<%@ Register TagPrefix="Controls" Namespace="Superi.CustomControls" %>

<%@ Register TagName="ArticlesEditor" TagPrefix="Admin" Src="~/Administration/Controls/ArticlesEditor.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <Admin:ArticlesEditor runat="server" ScopeId="1" ArticleEditorMode="Practice"></Admin:ArticlesEditor>
</asp:Content>

