<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Holidays.aspx.cs" Inherits="Holidays" %>
<%@ Register TagPrefix="od" TagName="CalendarMonth" Src="~/Controls/CalendarMonth.ascx" %>
<%@ Register TagPrefix="od" TagName="ThisDay" Src="~/Controls/ThisDay.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="calendarContent">
        <div id="monthFrame">
            <div id="monthLeft">
                <div id="monthLeftTop">
                    <div id="monthTitle">
                        октябрь
                    </div>   
                    <div id="monthDays">
                        <od:CalendarMonth ID="CalendarMonth1" runat="server" Month="10" />
                    </div>             
                </div>
                <div id="monthLeftBottom">
                    <od:ThisDay runat="server" Mode="Large" />
                </div>
            </div>
            <div id="monthRight">
            
            </div>
        </div>
    </div>
</asp:Content>

