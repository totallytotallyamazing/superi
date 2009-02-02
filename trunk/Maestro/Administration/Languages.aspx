<%@ Page Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Languages.aspx.cs" Inherits="Administration_Languages" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
        InsertMethod="Insert" SelectMethod="Get" TypeName="Superi.Features.Languages"
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Code" Type="String" />
            <asp:Parameter Name="ShortName" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Code" Type="String" />
            <asp:Parameter Name="ShortName" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
            <asp:BoundField DataField="ShortName" HeaderText="ShortName" SortExpression="ShortName" />
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" DefaultMode="Insert">
        <InsertItemTemplate>
            Code:
            <asp:TextBox ID="CodeTextBox" runat="server" Text='<%# Bind("Code") %>'>
            </asp:TextBox><br />
            ShortName:
            <asp:TextBox ID="ShortNameTextBox" runat="server" Text='<%# Bind("ShortName") %>'>
            </asp:TextBox><br />
            Name:
            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>'>
            </asp:TextBox><br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert">
            </asp:LinkButton>
        </InsertItemTemplate>
    </asp:FormView>
    
</asp:Content>

