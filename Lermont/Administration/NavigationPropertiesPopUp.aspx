<%@ Page EnableEventValidation="false" ValidateRequest="false" Language="C#" AutoEventWireup="true" CodeFile="NavigationPropertiesPopUp.aspx.cs" Inherits="Administration_NavigationPropertiesPopUp" %>
<%@ Register TagPrefix="admin" TagName="AddEditNavigation" Src="~/Administration/Controls/AddEditNavigation.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
    
    </title>
    <script src="../js/jquery.js" type="text/javascript"></script>
    <script src="js/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Services>
                <asp:ServiceReference Path="~/Administration/WebServices/Common.asmx" />
            </Services>
        </asp:ScriptManager>
        <admin:AddEditNavigation ID="aeNav" runat="server" />
    </form>
</body>
</html>
