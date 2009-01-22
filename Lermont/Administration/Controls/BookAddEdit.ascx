<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BookAddEdit.ascx.cs" Inherits="Administration_Controls_BookAddEdit" %>
<%@ Register TagPrefix="Controls" Namespace="Superi.CustomControls" Assembly="Superi" %>
    <script type="text/javascript">
        function deleteClicked()
        {
            return confirm('�� ����� ������ ������� �����������?');
        }
    </script>

    ���������:
    <Controls:ResourceEditor Type="SingleLine" runat="server" ID="reTitle"></Controls:ResourceEditor>
    ������������:
    <Controls:ResourceEditor Type="SingleLine" runat="server" ID="reSubTitle"></Controls:ResourceEditor>
    �������:
    <asp:ImageButton runat="server" AlternateText="�������" ID="ibPicture" OnClick="ibPicture_Click" />
    <br />
    <asp:FileUpload runat="server" ID="fuPicture" />
    ��������:
    <Controls:ResourceEditor Type="RichText" runat="server" ID="reShortDescription"></Controls:ResourceEditor>
    ��������:
    <Controls:ResourceEditor Type="SingleLine" runat="server" ID="rePublisher"></Controls:ResourceEditor>
    ���� ��������:
    <br />
    <asp:TextBox runat="server" ID="tbPublisherUrl"></asp:TextBox>
    <br />
    <asp:CheckBox runat="server" ID="cbNewBook" />
    <br />
    <asp:Button runat="server" ID="btnUpdate" OnClick="btnUpdate_Click" Text="���������" />
