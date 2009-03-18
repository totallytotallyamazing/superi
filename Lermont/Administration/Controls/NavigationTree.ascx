<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigationTree.ascx.cs" Inherits="Administration_Controls_NavigationTree" %>
<%@ Register TagPrefix="admin" TagName="AddEditNavigation" Src="~/Administration/Controls/AddEditNavigation.ascx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<script type="text/javascript">

    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestNTree);

    function BeginRequestNTree(sender, args) {
      //  $("#<%= pNavigationProperties.ClientID %>").empty();
    }

    function showNavigationPropterties() {
        $(function() { $("#<%= pNavigationProperties.ClientID %>").dialog({ modal: true, autoOpen: false }); })
        $("#<%= pNavigationProperties.ClientID %>").dialog("open");
    }

    $(function() { $("#<%= pNavigationProperties.ClientID %>").dialog({ modal: true, autoOpen: false }); })
</script>

<input type="hidden" runat="server" id="ihNodeID" />
<asp:TreeView runat="server" ID="twPages" OnSelectedNodeChanged="twPages_SelectedNodeChanged" CssClass="bordered">
</asp:TreeView>

<div id="NavigationControls" runat="server">
    <asp:ImageButton runat="server" ID="ibAddNode" ImageUrl="~/Administration/Images/addNode.jpg" ToolTip="Добавить страницу" onclick="InitNavigationPopUp" />
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
    <asp:ImageButton runat="server" ID="ibProperties" 
        ImageUrl="~/Administration/Images/properties.jpg" ToolTip="Свойства" 
        onclick="InitNavigationPopUp" />
</div> 
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <asp:Panel runat="server" ID="pNavigationProperties">
            <admin:AddEditNavigation ID="aeNav" runat="server" />
        </asp:Panel>    
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ibAddNode" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ibProperties" EventName="Click" />
        <asp:PostBackTrigger ControlID="aeNav" />
    </Triggers>
</asp:UpdatePanel>
