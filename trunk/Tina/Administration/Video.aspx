<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Video.aspx.cs" Inherits="Administration_Video" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<%@ Register Assembly="Superi" Namespace="Superi.CustomControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:LinqDataSource ID="ldsVideo" runat="server" 
        ContextTypeName="VideoDataContext" EnableDelete="True" EnableInsert="True" 
        TableName="Videos">
    </asp:LinqDataSource>
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" 
        DataSourceID="ldsVideo" InsertItemPosition="LastItem">
        <ItemTemplate>
            <tr style="background-color: #FFFBD6;color: #333333;">
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                </td>
                <td>
                    <asp:Label ID="ImageLabel" runat="server" Text='<%# Eval("Image") %>' />
                </td>
                <td>
                    <asp:Label ID="SourceLabel" runat="server" Text='<%# Eval("Source") %>' />
                </td>
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                        Text="Удалить" />
                    <cc2:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton">
                     </cc2:ConfirmButtonExtender>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color: #FAFAD2;color: #284775;">
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                </td>
                <td>
                    <asp:Label ID="ImageLabel" runat="server" Text='<%# Eval("Image") %>' />
                </td>
                <td>
                    <asp:Label ID="SourceLabel" runat="server" Text='<%# Eval("Source") %>' />
                </td>
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" 
                        Text="Удалить" />
                    <cc2:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="DeleteButton">
                     </cc2:ConfirmButtonExtender>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" 
                style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>
                        No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                </td>
                <td>
                    <cc1:FolderUpload Folder="~/Images/VideoImages/" ID="fuImage" UploadedFile='<%# Bind("Image") %>' runat="server" />
                </td>
                <td>
                    <cc1:FolderUpload Folder="~/Videos/" ID="fuSource" UploadedFile='<%# Bind("Source") %>' runat="server" />
                </td>
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                        Text="Добавить" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                        Text="Очистить" />
                </td>
            </tr>
        </InsertItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table ID="itemPlaceholderContainer" runat="server" border="1" 
                            style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color: #FFFBD6;color: #333333;">
                                <th runat="server">
                                    Название
                                </th>
                                <th runat="server">
                                    Фон
                                </th>
                                <th id="Th1" runat="server">
                                    Имя файла
                                </th>
                            </tr>
                            <tr ID="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" 
                        style="text-align: center;background-color: #FFCC66;font-family: Verdana, Arial, Helvetica, sans-serif;color: #333333;">
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
    
</asp:Content>

