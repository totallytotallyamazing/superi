<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Players.ascx.cs" Inherits="Controls_Players" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(ArticlesEndRequest);
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(ArticlesBeginRequest);

    function ArticlesBeginRequest(sender, args) {

    }

    function ArticlesEndRequest(sender, args) {
        if ($("#<%= hfArticleClicked.ClientID %>").attr("value") === "1")
            $find("<%= mpeDetails.ClientID %>").show();
        $("#<%= hfArticleClicked.ClientID %>").attr("value", "0");
    }

    function ibClientClick(eventTarget, eventArgument) {
        __doPostBack(eventTarget, eventArgument);
        return false;
    }

    $(document).keyup(keyUp);

    function keyUp(eventObj) {
        if (eventObj.keyCode == 27) {
            $find("<%= mpeDetails.ClientID %>").hide();
        }
    }
</script>

<asp:Repeater runat="server" ID="rPlayers" 
    onitemdatabound="rPlayers_ItemDataBound" OnItemCommand="rPlayers_ItemCommand">
    <ItemTemplate>
        <div class="player">
            <asp:LinkButton runat="server" ID="lbPicture">
                <asp:Image runat="server" ID="iPicture" />
            </asp:LinkButton><br />
            <%--<asp:ImageButton runat="server" ID="ibPicture" /><br />--%>
            <asp:LinkButton runat="server" ID="lbName"></asp:LinkButton>
        </div>
    </ItemTemplate>
</asp:Repeater>


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
                    <asp:Literal ID="lText" runat="server"></asp:Literal>
                <div style="color:#233A90">
                    <hr style="margin:5px 0;" />
                    <asp:Literal ID="lDetails" runat="server"></asp:Literal>    
                </div>
            </div>
        </asp:Panel>
        <asp:HiddenField runat="server" ID="hfArticleClicked" />
        <ajax:ModalPopupExtender runat="server" ID="mpeDetails" PopupControlID="pDetails"
            TargetControlID="lbStub" DropShadow="false" BackgroundCssClass="shaded" CancelControlID="ibArticleClose" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="rPlayers" EventName="ItemCommand" />
    </Triggers>
</asp:UpdatePanel>