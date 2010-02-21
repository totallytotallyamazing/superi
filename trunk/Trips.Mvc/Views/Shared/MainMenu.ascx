<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<script type="text/javascript">
    Sys.require([Sys.scripts.jQuery], function() {
        $(function() {
            var boxWidth = $("#box").width();
            var containerWidth = $("#header").width();
            var padding = (containerWidth - boxWidth) / 2 - $("#headerLogo").width();
            $("#box").css("padding-left", padding);

            $(".headerMenuItem").blur();
        })

        $(window).resize(function() {
            var boxWidth = $("#box").width();
            var containerWidth = $("#header").width();
            var padding = (containerWidth - boxWidth) / 2 - $("#headerLogo").width();
            $("#box").css("padding-left", padding);
        })
    });
</script>

<div id="box">
    <div class="headerMenuItem">
        <a href="/Request">
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:WebResources, Request %>"></asp:Literal>
        </a>
    </div>
    <div class="headerMenuItem">
        <a href="/Catalogue">
            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:WebResources, Catalogue %>"></asp:Literal>
        </a>
    </div>
    <div class="headerMenuItem">
        <a href="/Conditions">
            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:WebResources, Conditions %>"></asp:Literal>
        </a>
    </div>
    <div class="headerMenuItem">
        <a href="/Contacts">
            <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:WebResources, Contacts %>"></asp:Literal>
        </a>
    </div>
</div>
