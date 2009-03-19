<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigationTree.ascx.cs" Inherits="Administration_Controls_NavigationTree" %>
<%@ Register TagPrefix="admin" TagName="AddEditNavigation" Src="~/Administration/Controls/AddEditNavigation.ascx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<script type="text/javascript">
    function openNavPopUp(id, addMode) {
        openPopupWindow('NavigationPropertiesPopUp.aspx?id=' + id + "&add=" + addMode, 300, 400);
        return false;
    }
</script>

<input type="hidden" runat="server" id="ihNodeID" />
<asp:TreeView runat="server" ID="twPages" OnSelectedNodeChanged="twPages_SelectedNodeChanged" CssClass="bordered">
</asp:TreeView>

<div id="NavigationControls" runat="server">
    <asp:Image runat="server" ID="ibAddNode" ImageUrl="~/Administration/Images/addNode.jpg" ToolTip="�������� ��������"/>
    <asp:ImageButton runat="server" ID="ibLevelUp" Visible="false"
        ImageUrl="~/Administration/Images/moveUpLevel.jpg" 
        ToolTip="����������� �� ������� ����" onclick="MoveToParent" />
    <asp:ImageButton runat="server" ID="ibLevelDown" Visible="false"
        ImageUrl="~/Administration/Images/moveDownLevel.jpg" 
        ToolTip="����������� �� ������� ����" onclick="MakeChildOfPrevious" />
    <asp:ImageButton runat="server" ID="ibMoveUp"
        ImageUrl="~/Administration/Images/moveUp.jpg" ToolTip="�������� �����" 
        onclick="MoveNavigationUp" />
    <asp:ImageButton runat="server" ID="ibMoveDown" 
        ImageUrl="~/Administration/Images/moveDown.jpg" ToolTip="�������� ����" 
        onclick="MoveNavigationDown" />
    <asp:Image runat="server" ID="ibProperties" 
        ImageUrl="~/Administration/Images/properties.jpg" ToolTip="��������" 
        onclick="InitNavigationPopUp" />
    <asp:ImageButton runat="server" ID="ibRemoveNode" 
        ImageUrl="~/Administration/Images/deleteNode.jpg" onclick="DeleteNode" />
    <cc1:ConfirmButtonExtender ID="ibRemoveNode_ConfirmButtonExtender" 
        runat="server" ConfirmText="�� �������?" Enabled="True" 
        TargetControlID="ibRemoveNode">
    </cc1:ConfirmButtonExtender>
</div> 
