<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigationTree.ascx.cs" Inherits="Administration_Controls_NavigationTree" %>
<%@ Register TagPrefix="admin" TagName="AddEditNavigation" Src="~/Administration/Controls/AddEditNavigation.ascx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<script type="text/javascript">
//    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndNavTreeRequest);
//    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginNavTreeRequest);

//    function BeginNavTreeRequest(sender, args) {
//    }

//    function EndNavTreeRequest(sender, args) {
    //    }

    function showNavigationPropterties() {
        $find("<%pNavigationProperties_ModalPopupExtender.ClientID %>").show();
    }
</script>

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

<asp:Label ID="lStub" runat="server" style="display:none" />
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <asp:Panel runat="server" ID="pNavigationProperties">
            <asp:LinkButton ID="lbCancel" style="float:right" runat="server">LinkButton</asp:LinkButton>
            <admin:AddEditNavigation ID="aeNav" runat="server" />
        </asp:Panel>    
        <cc1:ModalPopupExtender ID="pNavigationProperties_ModalPopupExtender" 
            runat="server" DropShadow="True" DynamicServicePath="" Enabled="True" 
            PopupControlID="lbStub" TargetControlID="pNavigationProperties" 
            CancelControlID="lbCancel">
        </cc1:ModalPopupExtender>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ibAddNode" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ibProperties" EventName="Click" />
        <asp:PostBackTrigger ControlID="aeNav" />
    </Triggers>
</asp:UpdatePanel>
