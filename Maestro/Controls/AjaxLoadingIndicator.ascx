<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AjaxLoadingIndicator.ascx.cs" Inherits="Controls_AjaxLoadingIndicator" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<%@ Import Namespace="Superi.Common" %>
<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(<%= ClientID %>EndRequest);
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(<%= ClientID %>BeginRequest);
    
    function <%= ClientID %>BeginRequest(sender, args)
    {
        $find("<%= mWait.ClientID %>").show();
    }
    
    function <%= ClientID %>EndRequest(sender, args)
    {
        $find("<%= mWait.ClientID %>").hide();
    }
    
</script>
    <asp:LinkButton runat="server" style="display:none" ID="lbStub" Text="askldasjklhasjkldhasjkldh"></asp:LinkButton>
    <ajax:ModalPopupExtender ID="mWait"
        runat="server"
        PopupControlID="pWait"
        TargetControlID="lbStub"
        DropShadow="true"
        BackgroundCssClass="shaded"
    />
    
    
<asp:Panel runat="server" ID="pWait" CssClass="shaded">
    <img src="<%= WebSession.BaseImageUrl %>">ajaxLoader.gif" alt="Loading" />
</asp:Panel>


