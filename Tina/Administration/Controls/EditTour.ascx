<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditTour.ascx.cs" Inherits="Administration_Controls_EditTour" %>
<%@ Register TagPrefix="FCKeditor" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<div style="clear:both; width:865px; padding-left:10px;">
    <div style="float:left;">
        <asp:TextBox ID="tbCities" runat="server" TextMode="MultiLine" Height="285px" 
            Width="250"></asp:TextBox>
        <cc1:TextBoxWatermarkExtender ID="tbCities_TextBoxWatermarkExtender" 
            runat="server" Enabled="True" TargetControlID="tbCities" 
            WatermarkText="Список городов">
        </cc1:TextBoxWatermarkExtender>
    </div>
    <div style="float:left;">
        <asp:TextBox runat="server" ID="tbTextTitle" Width="600px"></asp:TextBox>
        <cc1:TextBoxWatermarkExtender ID="tbTextTitle_TextBoxWatermarkExtender" 
            runat="server" Enabled="True" TargetControlID="tbTextTitle" 
            WatermarkText="Заголовок">
        </cc1:TextBoxWatermarkExtender>
        <br />
        <asp:TextBox runat="server" ID="tbSubTitle" Width="600px"></asp:TextBox>
        <cc1:TextBoxWatermarkExtender ID="tbSubTitle_TextBoxWatermarkExtender" 
            runat="server" Enabled="True" TargetControlID="tbSubTitle" 
            WatermarkText="Подзаголовок">
        </cc1:TextBoxWatermarkExtender>
        <FCKeditor:FCKeditor Height="250px" Width="600" ToolbarSet="Basic" ID="fcText" runat="server" BasePath="~/Administration/Controls/fckeditor/">
        </FCKeditor:FCKeditor>
    </div>
</div>