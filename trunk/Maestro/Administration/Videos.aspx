<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Videos.aspx.cs" Inherits="Administration_Videos" %>

<%@ Register Assembly="Superi" Namespace="Superi.CustomControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LinqDataSource ID="ldsVideos" runat="server" 
        ContextTypeName="VideosDataContext" EnableDelete="True" EnableInsert="True" 
        EnableUpdate="True" TableName="Videos">
    </asp:LinqDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ID" DataSourceID="ldsVideos" Width="600">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="ID" />
            <asp:TemplateField HeaderText="Подпись (RU)" SortExpression="TitleTextID">
                <ItemTemplate>
                    <cc1:ResourceWritter ID="ResourceWritter1" runat="server" ResourceId='<%# Bind("TitleTextID") %>' Language="RU" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Embed" HeaderText="Код клипа" 
                SortExpression="Embed" />
            <asp:CommandField DeleteText="Удалить" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" 
        DataSourceID="ldsVideos" DefaultMode="Insert">
        <InsertItemTemplate>
            Подпись:
            <cc1:ResourceEditor ID="ResourceEditor1" runat="server" ResourceId='<%# Bind("TitleTextID") %>'>
            </cc1:ResourceEditor>
            <br />
            Код клипа:
            <asp:TextBox ID="EmbedTextBox" runat="server" Height="121px" 
                Text='<%# Bind("Embed") %>' TextMode="MultiLine" Width="322px" />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Добавить" />
        </InsertItemTemplate>
    </asp:FormView>
    
</asp:Content>

