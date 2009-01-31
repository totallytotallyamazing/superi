<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FAQEditor.ascx.cs" Inherits="Administration_Controls_FAQEditor" %>
<%@ Register TagPrefix="ajax" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%--<table>
<tr>
    <td style="height: 21px">
        Комментарий
    </td>
    <td>
        Отображать
    </td>
    <td style="height: 21px">
        Читать
    </td>
    <td style="height: 21px">
        Удалить
    </td>
</tr>
<asp:Repeater runat="server" ID="rItems" OnItemCommand="rItems_ItemCommand" OnItemDataBound="rItems_ItemDataBound">
    <ItemTemplate>
        <tr>
            <td><asp:Literal runat="server" ID="lComment"></asp:Literal></td>
            <td><asp:CheckBox runat="server" ID="cbDisplay" /></td>
            <td><asp:LinkButton CommandName="Answer" Text="Читать" runat="server" ID="lbAnswer"></asp:LinkButton></td>
            <td><asp:LinkButton CommandName="Delete" Text="Удалить" runat="server" ID="lbDelete"></asp:LinkButton></td>
        </tr>
    </ItemTemplate>
</asp:Repeater>
</table>
<asp:HiddenField runat="server" ID="hfItemId" />
<asp:PlaceHolder runat="server" ID="phAnswer">
        <div>
            <asp:Literal runat="server" ID="lQuestion"></asp:Literal>
        </div>
</asp:PlaceHolder>--%><asp:ObjectDataSource ID="odsFaq" runat="server" 
    DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Get" 
    TypeName="Superi.Features.FAQs" UpdateMethod="Update">
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="Id" Type="Int32" />
        <asp:Parameter Name="Name" Type="String" DefaultValue="" />
        <asp:Parameter Name="Email" Type="String" DefaultValue="" />
        <asp:Parameter Name="Question" Type="String" DefaultValue="" />
        <asp:Parameter Name="Answer" Type="String" DefaultValue="" />
        <asp:Parameter Name="Display" Type="Boolean" DefaultValue="false" />
    </UpdateParameters>
    <InsertParameters>
        <asp:Parameter Name="Name" Type="String" DefaultValue="" />
        <asp:Parameter Name="Email" Type="String" DefaultValue="" />
        <asp:Parameter Name="Question" Type="String" DefaultValue="" />
        <asp:Parameter Name="Answer" Type="String" DefaultValue="" />
        <asp:Parameter Name="Display" Type="Boolean" DefaultValue="false" />
    </InsertParameters>
</asp:ObjectDataSource>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="odsFaq" 
    onrowcommand="GridView1_RowCommand" DataKeyNames="Id">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="#" ReadOnly="True" 
            SortExpression="Id" />
        <asp:CheckBoxField DataField="Display" HeaderText="Показывать" 
            SortExpression="Display" />
        <asp:BoundField DataField="Name" HeaderText="Имя" SortExpression="Name" />
        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        <asp:TemplateField HeaderText="Комментарий">
            <ItemTemplate>
                <asp:Panel ID="pComment" runat="server" BackColor="#999999">
                    <asp:TextBox ID="tbComment" runat="server" Height="136px" 
                        Text='<%# Bind("Question") %>' TextMode="MultiLine" Width="366px"></asp:TextBox>
                    <br />
                    <asp:Button ID="bSave" runat="server" 
                        CommandArgument='<%# Eval("Id", "{0}") %>' 
                        Text="Сохранить" CommandName="UpdateComment" />
                    <asp:Button ID="bCancel" runat="server" Text="Отмена" />
                </asp:Panel>
                <ajax:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                    CancelControlID="bCancel" DropShadow="True" 
                    PopupControlID="pComment" TargetControlID="lbComment">
                </ajax:ModalPopupExtender>
                <asp:LinkButton ID="lbComment" runat="server">Коментарий</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField CancelText="Отмена" DeleteText="Удалить" EditText="Изменить" 
            ShowDeleteButton="True" ShowEditButton="True" UpdateText="Сохранить" />
    </Columns>
</asp:GridView>


