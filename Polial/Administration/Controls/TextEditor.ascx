<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TextEditor.ascx.cs" Inherits="Administration_Controls_TextEditor" %>
<%@ Register TagPrefix="Controls" Namespace="Superi.CustomControls" Assembly="Superi" %>
<div id="divTitle" runat="server">
    Заглавие:
    <Controls:ResourceEditor Type="SingleLine" ID="reName" runat="server"></Controls:ResourceEditor>
</div>
<div style="height:600px;">
    <Controls:ResourceEditor Type="RichText" ID="reText" runat="server" RichHeight="550"></Controls:ResourceEditor>
</div>
