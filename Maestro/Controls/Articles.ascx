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

<asp:Repeater runat="server" ID="rItems" OnItemDataBound="rItems_ItemDataBound" OnItemCommand="rItems_ItemCommand">
    <ItemTemplate>
        <div class="article">
            <div class="articleImage">
                <asp:HyperLink runat="server" ID="hlPicture" BorderColor="Black" BorderWidth="1"></asp:HyperLink>
                <asp:Image BorderColor="Black" BorderWidth="1" runat="server" ID="iPicture" />
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

<%if(ZoomImage){ %>
<script type="text/javascript">
    $(document).ready(function() { $(".articleImage a").fancybox({ 'overlayShow': true }) });
</script>
<%} %>

<asp:UpdatePanel runat="server" ID="upDetails">
    <ContentTemplate>
        <asp:LinkButton runat="server" ID="lbStub" Style="display: none" />
        <asp:Panel runat="server" ID="pDetails" CssClass="articleDetails">
            <div id="articleBg">
                <div class="articleBg fancy_bg_n"></div>
                <div class="articleBg fancy_bg_ne"></div>
                <div class="articleBg fancy_bg_e"></div>
                <div class="articleBg fancy_bg_se"></div>
                <div class="articleBg fancy_bg_s"></div>
                <div class="articleBg fancy_bg_sw"></div>
                <div class="articleBg fancy_bg_w"></div>
                <div class="articleBg fancy_bg_nw"></div>
            </div>
            <asp:ImageButton ImageUrl="~/Images/fancybox/fancy_closebox.png" CssClass="articleClose" ID="ibArticleClose" runat="server" />
            <div class="articleInner">
                <asp:Image runat="server" ID="iArticlePicture" CssClass="articleDetailPicture" />
                <asp:Literal ID="lDetails" runat="server"></asp:Literal>
            </div>
        </asp:Panel>
        <ajax:ModalPopupExtender runat="server" ID="mpeDetails" PopupControlID="pDetails"
            TargetControlID="lbStub" DropShadow="false" BackgroundCssClass="shaded" CancelControlID="ibArticleClose" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="rItems" EventName="ItemCommand" />
    </Triggers>
</asp:UpdatePanel>
