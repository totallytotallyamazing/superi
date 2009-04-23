<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Matches.ascx.cs" Inherits="Controls_Matches" %>
<%@ Register TagPrefix="m" TagName="Match" Src="~/Controls/Match.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Import Namespace="Superi.Common" %>
<script type="text/javascript">
    function displayDescription(id) {
        Matches.GetDescription(id, '<%= WebSession.Language %>', descriptionSuccess, descriptionFailure);
    }

    function descriptionSuccess(response) {
        $("#matchDescriptionInner").html(response);
        $find('<%= mpeDetails.ClientID %>').show();
    }
    
    function descriptionFailure(){
        alert('description failure');
    }
</script>
<asp:Repeater ID="rMatches" runat="server" 
    onitemdatabound="rMatches_ItemDataBound">
    <ItemTemplate>
        <m:Match runat="server" ID="mMatch" />
        
<%--                    HostCount='<%# Eval("HostCount") %>' 
            TeamCount='<%# Eval("TeamCount") %>' 
            ImageUrl='<%# Eval("Logo") %>'
            MatchDate='<%# Eval("Date") %>'
            Played='<%# Eval("Played") %>'
            TeamTextId='<%# Eval("TeamTextId") %>'--%>
    </ItemTemplate>
</asp:Repeater>

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
        <div class="articleInner" id="matchDescriptionInner">
        </div>
    </asp:Panel>
    <ajax:ModalPopupExtender runat="server" ID="mpeDetails" PopupControlID="pDetails"
        TargetControlID="lbStub" DropShadow="false" BackgroundCssClass="shaded" CancelControlID="ibArticleClose" />
