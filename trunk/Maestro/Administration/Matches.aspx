<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Matches.aspx.cs" Inherits="Administration_Matches" %>

<%@ Register assembly="Superi" namespace="Superi.CustomControls" tagprefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LinqDataSource ID="ldsTeams" runat="server" 
        ContextTypeName="GamesDataContext" 
        Select="new (NameTextId, DescriptionTextId, Logo, ID)" TableName="Teams">
    </asp:LinqDataSource>
    <asp:LinqDataSource ID="ldsMatches" runat="server" 
        ContextTypeName="GamesDataContext" 
        Select="new (Date, ID, HostCount, TeamCount, Team)" TableName="Games">
    </asp:LinqDataSource>
    
    <div style="float:left; width:200px;">
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ldsTeams" onrowdatabound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="#" SortExpression="ID" />
                <asp:ImageField DataImageUrlField="Logo" 
                    DataImageUrlFormatString="~/Images/Logos/{0}" HeaderText="Лого">
                </asp:ImageField>
                <asp:TemplateField HeaderText="Название">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lName"></asp:Label>
<%--                        <cc1:ResourceWritter ID="rlName" runat="server" 
                            ResourceId='<%# Eval("NameTextId") %>' Language="RU">
                        </cc1:ResourceWritter>--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:LinkButton ID="lbCreate" runat="server" Text="Создать"></asp:LinkButton>
        
        <cc2:PopupControlExtender ID="LinkButton1_PopupControlExtender" runat="server" 
             Enabled="True" PopupControlID="pCreateTeam" 
            TargetControlID="lbCreate" >
        </cc2:PopupControlExtender>
        <%--<cc2:DropShadowExtender runat="server" TargetControlID="pCreateTeam" Rounded="true" Radius="4"></cc2:DropShadowExtender>--%>
        <br />
        <asp:Panel ID="pCreateTeam" runat="server" CssClass="popUpPanel">
            Название:
            <cc1:ResourceEditor Type="SingleLine" runat="server" ID="reName"></cc1:ResourceEditor>
            Лого:<br />
            <cc1:FolderUpload Folder="~/Images/Logos/" runat="server" ID="fuLogo" />
            <br />
            <asp:Button runat="server" ID="bCreate" Text="Сохранить" onclick="bCreate_Click" />
        </asp:Panel>
    
    </div>
    <div style="float:left;">
    
<%--        <asp:Repeater ID="rMatches" runat="server" DataSourceID="ldsMatches">
            <ItemTemplate>
                <div style="text-align:center">
                    <asp:Image runat="server" ID="iMaestro" />
                    <asp:Label CssClass="gameCount" Text="<%# Eval("HostCount") %>" runat="server" ID="lHostCount"></asp:Label>
                    &nbsp;
                    <asp:Label CssClass="gameCount" runat="server" Text="&mdash"></asp:Label>
                    &nbsp;
                    <asp:Label CssClass="gameCount" runat="server" Text="<%# Eval("TeamCount") %>" ID="TeamCount"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="<%# Eval("Date") %>" ID="lDate"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:Repeater>--%>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="ldsMatches">
            <EditItemTemplate>
                <asp:Label ID="Label4" runat="server" Text="Маестро "></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Width="32px" 
                    Text='<%# Eval("HostCount") %>'></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="&amp;nbsp;&amp;mdash;&amp;nbsp;"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" Width="32px" 
                    Text='<%# Eval("TeamCount") %>'></asp:TextBox>
                <asp:DropDownList ID="ddlTeams" runat="server">
                </asp:DropDownList>
                <br />
                Дата:
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("Date", "{0:d}") %>'></asp:TextBox>
                <br />
                <asp:CheckBox ID="cbPlayed" runat="server" Checked='<%# Eval("Played") %>' 
                    Text="Сыгранная" />
                <br />
                <cc2:CalendarExtender ID="TextBox3_CalendarExtender" runat="server" 
                    TargetControlID="TextBox3" Format="dd.MM.yyyy" FirstDayOfWeek="Monday">
                </cc2:CalendarExtender>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update">Сохранить</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel">Отмена</asp:LinkButton>
                <br />
            </EditItemTemplate>
            <ItemTemplate>
<%--                    <asp:Image runat="server" ID="iMaestro" />
                    <asp:Label CssClass="gameCount" Text="<%# Eval("HostCount") %>" runat="server" ID="lHostCount"></asp:Label>
                    &nbsp;
                    <asp:Label ID="Label1" CssClass="gameCount" runat="server" Text="&mdash"></asp:Label>
                    &nbsp;
                    <asp:Label CssClass="gameCount" runat="server" Text="<%# Eval("TeamCount") %>" ID="TeamCount"></asp:Label>
                    <br />
                    <asp:Label runat="server" Text="<%# Eval("Date") %>" ID="lDate"></asp:Label>--%>
                <div style="float:left;">
                    <asp:Image ID="iMaestroLogo" runat="server" />
                    
                    <br />
                    <asp:Label ID="lMaestro" runat="server" Text="Маестро"></asp:Label>
                    
                </div>  
                <div style="float:left; padding:0 10px;">
                    &nbsp;<asp:Label ID="lHostCount" runat="server" Text='<%# Eval("HostCount") %>'></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="&amp;nbsp;&amp;mdash;&amp;nbsp;"></asp:Label>
                    <asp:Label ID="lTeamCount" runat="server" Text='<%# Eval("TeamCount") %>'></asp:Label>
                    &nbsp;
                    <br />
                    <asp:Label ID="lDate" runat="server" Text='<%# Eval("Date", "{0:d}") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Сыгранная" 
                        Visible='<%# Eval("Played") %>'></asp:Label>
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">Редактировать</asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete">\</asp:LinkButton>
                </div>  
                <div style="float:left;">
                    <asp:Image ID="iTeamLogo" runat="server" />
                    <br />
                    <asp:Label ID="lTeam" runat="server" Text="Команда"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="Label4" runat="server" Text="Маестро "></asp:Label>
            <asp:TextBox ID="tbHostCount" runat="server" Width="32px" 
                    Text='<%# Eval("HostCount") %>'></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="&amp;nbsp;&amp;mdash;&amp;nbsp;"></asp:Label>
            <asp:TextBox ID="tbTeamCount" runat="server" Width="32px" 
                    Text='<%# Eval("TeamCount") %>'></asp:TextBox>
            <asp:DropDownList ID="ddlTeams" runat="server">
            </asp:DropDownList>
            <br />
            Дата:
            <asp:TextBox ID="tbAddDate" runat="server" Text='<%# Eval("Date", "{0:d}") %>'></asp:TextBox>
            <cc2:CalendarExtender ID="tbAddDate_CalendarExtender" runat="server" 
                    TargetControlID="tbAddDate" Format="dd.MM.yyyy" 
                FirstDayOfWeek="Monday">
            </cc2:CalendarExtender>
            <br />
            <asp:CheckBox ID="cbPlayed" runat="server" Checked='<%# Eval("Played") %>' 
                Text="Сыгранная" />
            <br />
            <asp:LinkButton ID="lbAdd" runat="server">Добавить</asp:LinkButton>
            &nbsp;
        </asp:Panel>
        <br />
    </div>
</asp:Content>  

