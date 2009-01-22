<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditBokDescription.ascx.cs" Inherits="Administration_Controls_EditBokDescription" %>
<%@ Register TagPrefix="Controls" Namespace="Superi.CustomControls" Assembly="Superi" %>

Дополнительная информация:
<Controls:ResourceEditor Type="MultiLine" runat="server" ID="reAdditionalInfo"></Controls:ResourceEditor>
Описание:
<Controls:ResourceEditor RichHeight="350" Type="RichText" runat="server" ID="reDescription"></Controls:ResourceEditor>
<asp:Button runat="server" ID="btnUpdate" Text="Сохранить" OnClick="btnUpdate_Click" />