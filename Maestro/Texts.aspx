<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Texts.aspx.cs" Inherits="Texts" %>
<%@ Register TagPrefix="Superi" Assembly="Superi" Namespace="Superi.CustomControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <Superi:TextWriter runat="server" ID="twContent" />
</asp:Content>

