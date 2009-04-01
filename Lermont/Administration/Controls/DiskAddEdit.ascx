﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DiskAddEdit.ascx.cs" Inherits="Administration_Controls_DiskAddEdit" %>
<%@ Register TagPrefix="Controls" Namespace="Superi.CustomControls" Assembly="Superi" %>
    <script type="text/javascript">
        function deleteClicked()
        {
            return confirm('Вы точно хотите удалить изображение?');
        }
    </script>

    Заголовок:
    <Controls:ResourceEditor Type="SingleLine" runat="server" ID="reTitle"></Controls:ResourceEditor>
    Подзаголовок:
    <Controls:ResourceEditor Type="SingleLine" runat="server" ID="reSubTitle"></Controls:ResourceEditor>
    Обложка:
    <asp:ImageButton runat="server" AlternateText="Удалить" ID="ibPicture" OnClick="ibPicture_Click" />
    <br />
    <asp:FileUpload runat="server" ID="fuPicture" />
    Описание:
    <Controls:ResourceEditor Type="RichText" runat="server" ID="reShortDescription"></Controls:ResourceEditor>
    Издатель:
    <Controls:ResourceEditor Type="SingleLine" runat="server" ID="rePublisher"></Controls:ResourceEditor>
    Сайт издателя:
    <br />
    <asp:TextBox runat="server" ID="tbPublisherUrl"></asp:TextBox>
    <br />
    Цена:<asp:TextBox runat="server" ID="tbPrice"></asp:TextBox>
    <br />
    <asp:CheckBox runat="server" ID="cbNewBook" />
    <br />
    <asp:Button runat="server" ID="btnUpdate" OnClick="btnUpdate_Click" Text="Сохранить" />
