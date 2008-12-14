<%@ Page Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="UploadFiles.aspx.cs" Inherits="Administration_UploadFiles" Title="Untitled Page" %>
<%@ Register Src="~/Administration/Controls/AttachableFilesUploader.ascx" TagPrefix="Controls" TagName="FilesUploader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" cellpadding="10">
        <tr>
            <td>Меню ПДФ</td>
            <td>
                <Controls:FilesUploader runat="server" ID="fuPdf" ItemType="1" ItemId="32">
                </Controls:FilesUploader>
            </td>
        </tr>
        <tr>
            <td>Франчайзинг предложение</td>
            <td>
                <Controls:FilesUploader runat="server" ID="fuOffer" ItemType="1" ItemId="4">
                </Controls:FilesUploader>
            </td>
        </tr>
        <tr>
            <td>Франчайзинг анкета</td>
            <td>
                <Controls:FilesUploader runat="server" ID="fuAnketa" ItemType="1" ItemId="4">
                </Controls:FilesUploader>
            </td>
        </tr>
    </table>
</asp:Content>

