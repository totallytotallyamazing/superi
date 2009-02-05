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
            DataSourceID="ldsTeams">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="#" SortExpression="ID" />
                <asp:ImageField DataImageUrlField="Logo" 
                    DataImageUrlFormatString="~/Images/Logos/{0}" HeaderText="Лого">
                </asp:ImageField>
                <asp:TemplateField HeaderText="Название">
                    <ItemTemplate>
                        <cc1:ResourceWritter ID="rlName" runat="server" 
                            ResourceId='<%# Eval("NameTextId") %>' Language="RU">
                        </cc1:ResourceWritter>
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
    
        <asp:Repeater ID="rMatches" runat="server" DataSourceID="ldsMatches">
            <ItemTemplate>
                <div>
                    
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

