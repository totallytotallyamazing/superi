<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Administration_Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="Data Source=mssql2.hosting.ua;Initial Catalog=nastyak_Odisseia;Persist Security Info=True;User ID=nastyak_odisseia;Password=cde32wsx" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT [Id], [Name], [Value] FROM [Settings]"></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
                ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Name" HeaderText="��������" SortExpression="Name" />
            <asp:BoundField DataField="Value" HeaderText="��������" SortExpression="Value" />
            <asp:CommandField ShowEditButton="True" EditText="�������������" CancelText="������" UpdateText="���������" />
            <asp:CommandField ShowDeleteButton="True" DeleteText="�������" />
        </Columns>
    </asp:GridView>  
    <asp:FormView DefaultMode="Insert" ID="FormView1" runat="server" DataKeyNames="Id" 
        DataSourceID="SqlDataSource1">
        <InsertItemTemplate>
            ��������:
            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
            <br />
            ��������:
            <asp:TextBox ID="ValueTextBox" runat="server" Text='<%# Bind("Value") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="��������" />
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>

