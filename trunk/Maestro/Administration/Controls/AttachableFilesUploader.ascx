<%@ Import Namespace="Superi.Features"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AttachableFilesUploader.ascx.cs" Inherits="Administration_Controls_AttachableFilesUploader" %>
<%@ Register TagPrefix="Controls" TagName="AttachableFileUploader" Src="~/Administration/Controls/AttachableFileUploader.ascx" %>
<script type="text/javascript">
    function toggleDivs(lang, id)
    {
        var lng;
        for (lng in langs)
        {
            var lngVal = langs[lng];
            var el = document.getElementById(id+'_div_' +lngVal);
            var aEl = document.getElementById(id+'_a_' +lngVal);
            if(lngVal===lang)
            {
                el.style.display='block';
                aEl.style.border='1px solid #8c8c8c';
            }
            else
            {
                el.style.display='none';
                aEl.style.border='none';
            }
        }
    }

</script>
<table>
    <tr>
        <asp:Repeater runat="server" ID="rLanguages">
            <ItemTemplate>
                <td>
                    <a id="<%= ClientID %>_a_<%# ((Language) Container.DataItem).Code %>" href="javascript:toggleDivs('<%# ((Language) Container.DataItem).Code %>', '<%= ClientID %>')"><%# ((Language) Container.DataItem).Name %></a>
                </td>
            </ItemTemplate>
        </asp:Repeater>
    </tr>
</table>
<asp:Repeater runat="server" ID="rFiles">
    <ItemTemplate>
        <div id="<%= ClientID %>_div_<%# ((Language) Container.DataItem).Code %>">
            <Controls:AttachableFileUploader ID="afuFile" runat="server" />
        </div>
    </ItemTemplate>
</asp:Repeater>
<asp:Button runat="server" ID="btnSave" Text="Сохранить" OnClick="btnSave_Click" />

