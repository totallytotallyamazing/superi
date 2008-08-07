<%@ Page Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Administration_Products" Title="Untitled Page" %>
<%@ Register TagPrefix="Controls" Namespace="CustomControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function checkGroupName()
    {
        var tbGroupName = document.getElementById(<%=  tbGroupName.ClientID%>);
        if(tbGroupName && tbGroupName.value!='')
            return true;
        else
            return false;
    }   
</script>

    <asp:HiddenField runat="server" id="hfGroupID" />
    <asp:HiddenField runat="server" ID="hfProductSelected" />
    
    <asp:ObjectDataSource ID="dsProducts" runat="server" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Get" TypeName="Superi.Shop.Products" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Price" Type="Decimal" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
            <asp:Parameter Name="Weight" Type="Decimal" />
        </UpdateParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="hfGroupID" Name="ScopeID" PropertyName="Value" Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Price" Type="Decimal" />
            <asp:Parameter Name="GroupID" Type="Int32" />
            <asp:Parameter Name="Weight" Type="Decimal" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <table>
        <tr>
            <td style="float:left; width:300px; height:100%; border:1px solid #969696;" valign="top">
                <asp:TreeView runat="server" ID="twGroups" ShowCheckBoxes="All"></asp:TreeView>
                <asp:TextBox runat="server" ID="tbGroupName"></asp:TextBox>
                <asp:Button runat="server" Text="Создать группу" ID="btnAddGroup" OnClick="btnAddGroup_Click" /><br />
                <asp:Button runat ="server" Text="(в корне)" ID="btnAddRootGroup" OnClick="btnAddRootGroup_Click" />
                <asp:Button runat="server" ID="btnRemoveScopes" Text="Удалить отмеченные" OnClick="btnRemoveScopes_Click" />
            </td>

            <td valign="top">
                <div id="divGrids" runat="server">
            <asp:GridView ID="gwProducts" runat="server" DataKeyNames="ID" DataSourceID="dsProducts" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:BoundField DataField="Weight" HeaderText="Вес" SortExpression="Weight" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <asp:FormView ID="fwProduct" runat="server" DefaultMode="Insert" DataSourceID="dsProducts">
                <InsertItemTemplate> 
                    <div style="display:none;">
                    GroupID:
                    <asp:TextBox ID="GroupIDTextBox" runat="server" Text='<%# Bind("GroupID") %>'>
                    </asp:TextBox><br />
                    </div>
                    Название:
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>'>
                    </asp:TextBox><br />
                    Цена:
                    <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>'>
                    </asp:TextBox><br />
                    Вес:
                    <asp:TextBox ID="WeightTextBox" runat="server" Text='<%# Bind("Weight") %>'>
                    </asp:TextBox><br />
                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                        Text="Insert">
                    </asp:LinkButton>
                </InsertItemTemplate>
            </asp:FormView>
            
            <asp:PlaceHolder runat="server" ID="phEdit">
                Название:
                <Controls:ResourceEditor runat="server" ID="reName"></Controls:ResourceEditor>
                Изображение:<br />
                <asp:Image runat="server" ID="iPicture" /><br />
                <asp:Button runat="server" ID="btnRemovePicture" Text="Удалить изображение" /><br />
                <asp:FileUpload ID="fuPicture" runat="server" /><br />
                <asp:Button ID="btnUpdate" runat="server" Text="Сохранить" />
            </asp:PlaceHolder>
        </div>
            </td>
        </tr>
    </table>
    <div style="clear:both; height:800px;">
        <div>

        </div>

    
    </div>
</asp:Content>

