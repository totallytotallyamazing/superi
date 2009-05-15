<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="Videos.aspx.cs" Inherits="Administration_Videos" %>

<%@ Register TagName="LoadingIndicator" TagPrefix="admin" Src="~/Controls/AjaxLoadingIndicator.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="Superi" Namespace="Superi.CustomControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        Для сортировки видео потяните за синий квадрат слева
    </div>
    <br />
    <admin:LoadingIndicator runat="server" />
    <asp:LinqDataSource ID="ldsVideos" runat="server" ContextTypeName="VideosDataContext"
        EnableDelete="True" EnableInsert="True" EnableUpdate="True" TableName="Videos"
        OrderBy="SortOrder">
    </asp:LinqDataSource>
    <cc2:ReorderList ID="ReorderList1" runat="server" AllowReorder="True" DataSourceID="ldsVideos"
        PostBackOnReorder="True" DataKeyField="ID" SortOrderField="SortOrder">
        <ItemTemplate>
            <div class="reorderItem">
                <cc1:ResourceWritter ID="ResourceWritter1" runat="server" ResourceId='<%# Bind("TitleTextID") %>'
                    Language="RU" />
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Удалить" CommandName="Delete"
                    CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                <cc2:ConfirmButtonExtender ID="LinkButton1_ConfirmButtonExtender" runat="server"
                    ConfirmText="Удалить видео?" Enabled="True" TargetControlID="LinkButton1">
                </cc2:ConfirmButtonExtender>
            </div>
        </ItemTemplate>
        <DragHandleTemplate>
            <div class="dragHandle">
            </div>
        </DragHandleTemplate>
    </cc2:ReorderList>
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" DataSourceID="ldsVideos"
        DefaultMode="Insert">
        <InsertItemTemplate>
            Подпись:
            <cc1:ResourceEditor ID="ResourceEditor1" runat="server" ResourceId='<%# Bind("TitleTextID") %>'>
            </cc1:ResourceEditor>
            <br />
            Код клипа:
            <asp:TextBox ID="EmbedTextBox" runat="server" Height="121px" Text='<%# Bind("Embed") %>'
                TextMode="MultiLine" Width="322px" />
            <br />
            <asp:HiddenField runat="server" ID="hfSortOrder" Value='<%# Bind("SortOrder") %>' />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Добавить" />
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
