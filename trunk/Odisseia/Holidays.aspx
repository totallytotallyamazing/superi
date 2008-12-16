<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Holidays.aspx.cs" Inherits="Holidays" %>
<%@ Register TagPrefix="od" TagName="CalendarMonth" Src="~/Controls/CalendarMonth.ascx" %>
<%@ Register TagPrefix="od" TagName="ThisDay" Src="~/Controls/ThisDay.ascx" %>
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
                            <od:ThisDay runat="server" Mode="Large" ID="tdHolidays" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cmMonth" EventName="DateChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
            
            <div id="monthRight">
            
            </div>
        </div>
    </div>
</asp:Content>

