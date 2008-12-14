<%@ Page Title="" EnableEventValidation="false" ValidateRequest="false" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="TradeMarks.aspx.cs" Inherits="Administration_TradeMarks" %>
<%@ Register TagName="AddTradeMarks" TagPrefix="Admin" Src="~/Administration/Controls/AddTradeMarks.ascx" %>
<%@ Register TagName="TradeMarks" TagPrefix="Admin" Src="~/Administration/Controls/TradeMarksFrame.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">   
    <Admin:AddTradeMarks runat="server" />
    <br />
    
    <div class="tmFramesHolder">
        <div class="leftFrame">
            Товары:
            <Admin:TradeMarks runat="server" Goods="true" />
        </div>
        <div class="rightFrame">
            Услуги:
            <Admin:TradeMarks runat="server" Goods="false" />
        </div>
    </div>
    
</asp:Content>

