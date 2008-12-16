<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThisDay.ascx.cs" Inherits="Controls_ThisDay" %>
<script type="text/javascript">
    var keepOpacity = false;
    var descriptionShown = false;

    function showDescription(id, el) {
        var divDescription = document.getElementById(id);
        var elPos = getAbsolutePos(el);
        divDescription.style.display = 'block';
        divDescription.style.left = elPos.x + 'px';
        divDescription.style.top = +(elPos.y+15) + 'px';
        keepOpacity = true;
        descriptionShown = true;
        opacity(id, 0, 100, 500);
    }

    function hideDescription(id) {
        descriptionShown = false;
        opacity(id, 100, 0, 500);
        setTimeout('hideDiv("'+id+'")', 500);
    }

    function hideDiv(id) {
        var divDescription = document.getElementById(id);
        divDescription.style.display = 'none';
    }

    function descriptionMouseOut(id) {
        if (descriptionShown) {
            keepOpacity = false;
            setTimeout('conditionalHide("' + id + '")', 150);
        }
    }

    function descriptionMouseOver() {
        if (descriptionShown) {
            keepOpacity = true;
        }
    }

    function conditionalHide(id) {
        if (!keepOpacity) {
            hideDescription(id);
        }
    }
    
</script>
<asp:Panel runat="server" ID="pDay" CssClass="todayDay">
    <asp:Label runat="server" ID="lDay"></asp:Label>
</asp:Panel>
<asp:Panel runat="server" ID="pDate">
    <div class="todayMonth">
        <asp:Label runat="server" ID="lMonth"></asp:Label>    
    </div>
    <div class="todayDate">
        <asp:Label runat="server" ID="lDate"></asp:Label>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pHolidays">
    <asp:Repeater runat="server" ID="rHolidays" 
        onitemdatabound="rHolidays_ItemDataBound">
        <ItemTemplate>
            <div class="holidaysContainer">
                <asp:HyperLink runat="server" ID="hlHoliday" CssClass="todayHoliday"></asp:HyperLink>
                <div class="descriptionDiv" style="display:none;" runat="server" id="divDescription" onmouseout="descriptionMouseOut(this.id)" onmouseover="descriptionMouseOver()">
                    <asp:Literal runat="server" ID="lDescription"></asp:Literal>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Panel>