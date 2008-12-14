<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Holidays.aspx.cs" Inherits="Administration_Holidays" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView runat="server" ID="gwHolidays" AutoGenerateColumns="False" 
        onrowcommand="gwHolidays_RowCommand" onrowdatabound="gwHolidays_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Праздник" />
            <asp:TemplateField HeaderText="Число">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lDay"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Месяц">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lMonth"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="hlDescription" Text="Описание"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbDelete" Text="Удалить" CommandName="DeleteItem"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <div>
        Праздник:
        <asp:TextBox runat="server" ID="tbName"></asp:TextBox>
        <div>
        Месяц:
        <asp:DropDownList runat="server" ID="ddlMonth" AutoPostBack="true" 
            onselectedindexchanged="ddlMonth_SelectedIndexChanged">
            <asp:ListItem Text="Январь" Value="1"></asp:ListItem>
            <asp:ListItem Text="Февраль" Value="2"></asp:ListItem>
            <asp:ListItem Text="Март" Value="3"></asp:ListItem>
            <asp:ListItem Text="Апрель" Value="4"></asp:ListItem>
            <asp:ListItem Text="Май" Value="5"></asp:ListItem>
            <asp:ListItem Text="Июнь" Value="6"></asp:ListItem>
            <asp:ListItem Text="Июль" Value="7"></asp:ListItem>
            <asp:ListItem Text="Август" Value="8"></asp:ListItem>
            <asp:ListItem Text="Сентябрь" Value="9"></asp:ListItem>
            <asp:ListItem Text="Октябрь" Value="10"></asp:ListItem>
            <asp:ListItem Text="Ноябрь" Value="11"></asp:ListItem>
            <asp:ListItem Text="Декабрь" Value="12"></asp:ListItem>
        </asp:DropDownList>
        </div>
        <asp:UpdatePanel runat="server" ID="upDay">
            <ContentTemplate>
                Число:  
                <asp:DropDownList runat="server" ID="ddlDay"></asp:DropDownList>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlMonth" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <div>
            <asp:Button runat="server" ID="bAdd" Text="Добавить" onclick="bAdd_Click" />
        </div>
    </div>
 
</asp:Content>

