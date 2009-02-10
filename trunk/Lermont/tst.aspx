<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tst.aspx.cs" Inherits="tst" %>
<%@ Register TagPrefix="cc1" Assembly="Superi" Namespace="Superi.CustomControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:Panel ID="Panel1" runat="server">
    </asp:Panel>
    <asp:BulletedList ID="BulletedList1" runat="server">
    </asp:BulletedList>

    <cc1:GalleryExtender ID="BulletedList1_GalleryExtender" runat="server" 
        ImagePlaceHoldeID="Panel1" TargetControlID="BulletedList1">
    </cc1:GalleryExtender>
   </form>
</body>
</html>
