<%@ Page EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Texts.aspx.cs" Inherits="Texts" Title="Untitled Page" %>
<%@ Register TagPrefix="Controls" Namespace="CustomControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="textDiv">
        <Controls:TextWriter ID="twText" runat="server"></Controls:TextWriter>
    </div>
</asp:Content>

