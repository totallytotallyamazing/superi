<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Holidays.aspx.cs" Inherits="Holidays" %>
<%@ Register TagPrefix="od" TagName="CalendarMonth" Src="~/Controls/CalendarMonth.ascx" %>
<%@ Register TagPrefix="od" TagName="ThisDay" Src="~/Controls/ThisDay.ascx" %>
<%@ Register TagPrefix="od" TagName="WeekEvents" Src="~/Controls/WeekEvents.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="calendarContent">
        <div id="monthFrame">
            <div id="monthLeft">
                <div id="monthLeftTop">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <od:CalendarMonth ID="cmMonth" runat="server"/>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div id="monthLeftBottom">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <od:ThisDay Mode="Large" runat="server" ID="tdHolidays" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmMonth" EventName="DateChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
            
            <div id="monthRight">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <od:WeekEvents runat="server" ID="weWeek" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmMonth" EventName="DateChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>

