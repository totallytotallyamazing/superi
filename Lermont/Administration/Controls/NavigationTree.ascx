<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigationTree.ascx.cs" Inherits="Administration_Controls_NavigationTree" %>
<input type="hidden" runat="server" id="ihNodeID" />
<asp:TreeView runat="server" ID="twPages" OnSelectedNodeChanged="twPages_SelectedNodeChanged" CssClass="bordered">
</asp:TreeView>

<div id="NavigationControls" runat="server">
    <asp:ImageButton runat="server" ID="ibAddNode" ImageUrl="~/Administration/Images/addNode.jpg" ToolTip="�������� ��������" />
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
    <asp:ImageButton runat="server" ID="ibProperties" ImageUrl="~/Administration/Images/properties.jpg" ToolTip="��������" />
</div> 
