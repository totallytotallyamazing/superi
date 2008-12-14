<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditEventDescription.aspx.cs" Inherits="Administration_PopUps_EditEventDescription" %>
<%@ Register TagPrefix="FCKeditor" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <FCKeditor:FCKeditor Height="450" runat="server" ID="fcDescription" BasePath="~/Administration/Controls/fckeditor/"></FCKeditor:FCKeditor>
        <asp:Button runat="server" ID="bSave" Text="Сохранить" onclick="bSave_Click" />
    </form>
</body>
</html>
