<%@ Page Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="UploadPdf.aspx.cs" Inherits="Administration_UploadPdf" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:FileUpload runat="server" ID="fuPdf" /><br />
    <asp:Button runat="server" Text="Сохранить" ID="btnSave" OnClick="btnSave_Click" />
</asp:Content>

