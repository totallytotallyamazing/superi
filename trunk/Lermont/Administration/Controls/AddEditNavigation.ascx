<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddEditNavigation.ascx.cs" Inherits="Administration_Controls_AddEditNavigation" %>
<%@ Register TagPrefix="superi" Namespace="Superi.CustomControls" Assembly="Superi" %>
<div id="commonProperties">
    <div style="float:left">
        Адресная строка: <br />
        <asp:TextBox runat="server" ID="tbName"></asp:TextBox>
    </div>
    <div style="float:left;">
        Заголовок:
        <superi:ResourceEditor runat="server" ID="reTitle"></superi:ResourceEditor>
    </div>
</div>