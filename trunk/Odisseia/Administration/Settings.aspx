<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Administration_Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT [ID], [Name], [Value] FROM [Settings]" 
        DeleteCommand="DELETE FROM [Settings] WHERE [ID] = @ID" 
        InsertCommand="INSERT INTO [Settings] ([Name], [Value]) VALUES (@Name, @Value)" 
        UpdateCommand="UPDATE [Settings] SET [Name] = @Name, [Value] = @Value WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Value" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Value" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
                ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Name" HeaderText="Параметр" SortExpression="Name" />
            <asp:BoundField DataField="Value" HeaderText="Значение" SortExpression="Value" />
            <asp:CommandField ShowEditButton="True" EditText="Редактировать" CancelText="Отмена" UpdateText="Сохранить" />
            <asp:CommandField ShowDeleteButton="True" DeleteText="Удалить" />
        </Columns>
    </asp:GridView>  
    <asp:FormView DefaultMode="Insert" ID="FormView1" runat="server" DataKeyNames="Id" 
        DataSourceID="SqlDataSource1">
        <InsertItemTemplate>
            Параметр:
            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
            <br />
            Значение:
            <asp:TextBox ID="ValueTextBox" runat="server" Text='<%# Bind("Value") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Добавить" />
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>

