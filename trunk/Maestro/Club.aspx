﻿<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Club.aspx.cs" Inherits="Club" %>
<%@ Register TagPrefix="m" TagName="Articles" Src="~/Controls/Articles.ascx" %>
<%@ Register TagPrefix="m" TagName="Players" Src="~/Controls/Players.ascx" %>
<%@ Import Namespace="Superi.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<%--    <m:Articles ID="Articles1" runat="server" 
        ArticleScopeId="2" 
        BodyAsDescription="false" 
        DefaultImageUrl="~/Images/DefaultArticle.jpg" 
        ZoomImage="true"
        DisplayDate="false" MaxPictureDimension="96" />--%>
    <m:Players runat="server" />
</asp:Content>

