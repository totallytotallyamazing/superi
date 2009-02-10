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
                <asp:HyperLink runat="server" ID="hlPicture" BorderColor="Black" BorderWidth="1"></asp:HyperLink>
                <asp:Image BorderColor="Black" BorderWidth="1" runat="server" ID="iPicture"  />
            </div>
            <asp:Panel CssClass="articleText" runat="server" ID="pText">
                <asp:Panel runat="server" CssClass="articleTitle" ID="pTitle">
                    <asp:Literal runat="server" ID="lTitle"></asp:Literal>
                    <asp:Label runat="server" ID="lDate" CssClass="articleDate"></asp:Label>
                </asp:Panel>
                <asp:Literal runat="server" ID="lText"></asp:Literal>
            </asp:Panel>
            <div class="articleDetailsLink">
                <Superi:ResourceLinkButton runat="server" ID="rlbDetails" CommandName="Display" ResourceName="details" />
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
<script type="text/javascript">
    $(document).ready(function() { $(".articleImage a").fancybox({ 'overlayShow': true }) });
</script>
<asp:UpdatePanel runat="server" ID="upDetails">
    <ContentTemplate>
        <asp:LinkButton runat="server" ID="lbStub" style="display:none" />
        <asp:Panel runat="server" ID="pDetails" CssClass="articleDetails">
            <asp:Image runat="server" ID="iArticlePicture" CssClass="articleDetailPicture" />            
            <asp:Literal ID="lDetails" runat="server"></asp:Literal>
            <div class="articleDetailsClose">
                <Superi:ResourceLinkButton ID="rlbClose" runat="server" ResourceName="close"></Superi:ResourceLinkButton>
            </div>
        </asp:Panel>
        <ajax:ModalPopupExtender runat="server" 
            ID="mpeDetails" 
            PopupControlID="pDetails" 
            TargetControlID="lbStub" 
            DropShadow="true" 
            BackgroundCssClass="shaded" 
            CancelControlID="rlbClose"/>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="rItems" EventName="ItemCommand" />
    </Triggers>
</asp:UpdatePanel>

