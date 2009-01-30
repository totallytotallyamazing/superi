<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" %>
<%@ Register TagPrefix="od" TagName="Vouchers" Src="~/Controls/Vouchers.ascx" %>

<asp:Content ID="titleContent" ContentPlaceHolderID="titlePlaceHolder" runat="server">
    <link rel="Stylesheet" href="css/productDescription.css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(CommentsEndRequest);

        function CommentsEndRequest(sender, args) {
            var bw = $("#main").innerWidth();
            var bh = visibleAreaSize().h;
            var panel;
            if (sender._postBackSettings.panelID.indexOf("lbComments") > -1) {
                panel = $("#<%= pComments.ClientID %>");
                panel.css("display", "block");
                panel.css("left", bw / 2 - panel.width() / 2);
                panel.css("top", bh / 2 - panel.height() / 2 + $("html").scrollTop());
            }
        }
    </script>

    <div id="detailsContainer">
        <div id="tradeMarkPropertues">
            <div id="commentsAndLogo">
                <div id="logo">
                    <asp:Image runat="server" ID="iLogo" />
                </div>
                <div id="comments" class="fixPng">
                    <asp:LinkButton runat="server" ID="lbComments" onclick="lbComments_Click">
                    </asp:LinkButton>
                </div>
            </div>
            <div id="description">
                <asp:Literal runat="server" ID="lDescription"></asp:Literal>
            </div>
        </div>
        <div id="vouchers">
            <od:Vouchers runat="server" ID="vVouchers" />
        </div>
        <div id="customDescription">
            <asp:Literal runat="server" ID="lShortDescription"></asp:Literal>
        </div>
        <div id="additionalProperties">
            <div>
                <strong>Кому подарть:</strong>&nbsp;
                <asp:Literal runat="server" ID="lRecipient"></asp:Literal>                
            </div>
            <div>
                <strong>Когда подарить:</strong>&nbsp;
                <asp:Literal runat="server" ID="lOccasion"></asp:Literal>                
            </div>
            <div>
                <strong>Что вы получите</strong>&nbsp;
                <asp:Literal runat="server" ID="lEventSuggestion"></asp:Literal>                
            </div>
        </div>
    </div>
    <asp:UpdatePanel runat="server" ID="upCommnts">
        <ContentTemplate>
            <asp:Panel CssClass="commentsPanel" runat="server" ID="pComments">
                <div id="commentsTop">
                   <asp:Image runat="server" ImageUrl="~/Images/baloonClose.JPG" ToolTip="x" ID="iCloseComments" />
                </div>
                <div id="commentsTitle">
                    <asp:Literal runat="server" ID="lCommentsTitle"></asp:Literal>
                </div>
                <div id="commentsBody">
                    <div id="commentsList">
                    
                    </div>    
                    <div id="addComment">
                    
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lbComments" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

