<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigationTree.ascx.cs" Inherits="Administration_Controls_NavigationTree" %>
<input type="hidden" runat="server" id="ihNodeID" />
<asp:TreeView runat="server" ID="twPages" OnSelectedNodeChanged="twPages_SelectedNodeChanged" CssClass="bordered">
</asp:TreeView>

<div id="NavigationControls" runat="server">
    <asp:ImageButton runat="server" ID="ibAddNode" ImageUrl="~/Administration/Images/addNode.jpg" ToolTip="Добавить страницу" />
    <asp:ImageButton runat="server" ID="ibLevelUp" Visible="false"
        ImageUrl="~/Administration/Images/moveUpLevel.jpg" 
        ToolTip="Переместить на уровень выше" onclick="MoveToParent" />
    <asp:ImageButton runat="server" ID="ibLevelDown" Visible="false"
        ImageUrl="~/Administration/Images/moveDownLevel.jpg" 
        ToolTip="Переместить на уровень ниже" onclick="MakeChildOfPrevious" />
    <asp:ImageButton runat="server" ID="ibMoveUp"
        ImageUrl="~/Administration/Images/moveUp.jpg" ToolTip="Сместить вверх" 
        onclick="MoveNavigationUp" />
    <asp:ImageButton runat="server" ID="ibMoveDown" 
        ImageUrl="~/Administration/Images/moveDown.jpg" ToolTip="Сместить вниз" 
        onclick="MoveNavigationDown" />
    <asp:ImageButton runat="server" ID="ibProperties" ImageUrl="~/Administration/Images/properties.jpg" ToolTip="Свойства" />
</div> 
