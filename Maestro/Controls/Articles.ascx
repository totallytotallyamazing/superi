<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Articles.ascx.cs" Inherits="Controls_Articles" %>
<%@ Register TagPrefix="Superi" Assembly="Superi" Namespace="Superi.CustomControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Import Namespace="Superi.Common" %>
<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(ArticlesEndRequest);
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(ArticlesBeginRequest);

    function ArticlesBeginRequest(sender, args) {

    }

    function ArticlesEndRequest(sender, args) {
        $find("<%= mpeDetails.ClientID %>").show();
    }
</script>

<asp:Repeater runat="server" ID="rItems" onitemdatabound="rItems_ItemDataBound" 
    onitemcommand="rItems_ItemCommand">
    <ItemTemplate>
        <div class="article">
            <div class="articleImage">
                <asp:Image runat="server" ID="iPicture"  />
            </div>
            <div class="articleText">
                <div class="articleTitle">
                    <asp:Literal runat="server" ID="lTitle"></asp:Literal>
                    <asp:Label runat="server" ID="lDate" CssClass="articleDate"></asp:Label>
                </div>
                <div class="articleText"></div>
                <asp:Literal runat="server" ID="lText"></asp:Literal>
            </div>
        </div>
        <div class="articleDetails">
            <Superi:ResourceLinkButton runat="server" ID="rlbDetails" CommandName="Display" ResourceName="details" />
        </div>
    </ItemTemplate>
</asp:Repeater>

<asp:UpdatePanel runat="server" ID="upDetails">
    <ContentTemplate>
        <asp:LinkButton runat="server" ID="lbStub" style="display:none" />
        <asp:Panel runat="server" ID="pDetails" CssClass="articleDetails">
            <asp:Literal ID="lDetails" runat="server"></asp:Literal>
            <div class="articleDetailsClose">
                <asp:Button runat="server" ID="bClose" />
            </div>
        </asp:Panel>
        <ajax:RoundedCornersExtender ID="RoundedCornersExtender1" 
            runat="server" 
            Radius="10" 
            TargetControlID="pDetails" 
            BorderColor="Black" />
        <ajax:ModalPopupExtender runat="server" 
            ID="mpeDetails" 
            PopupControlID="pDetails" 
            TargetControlID="lbStub" 
            DropShadow="true" 
            BackgroundCssClass="shaded" CancelControlID="bClose"/>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="rItems" EventName="ItemCommand" />
    </Triggers>
</asp:UpdatePanel>

