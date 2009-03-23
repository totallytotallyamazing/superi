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
        TableName="Games" OrderBy="Played, Date desc" EnableDelete="True" 
        EnableInsert="True" EnableUpdate="True">
    </asp:LinqDataSource>
    
    <div style="float:left; width:200px;">
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ldsTeams" DataKeyNames="ID" 
            onrowcommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="#" SortExpression="ID" />
                <asp:ImageField DataImageUrlField="Logo" 
                    DataImageUrlFormatString="~/Images/Logos/{0}" HeaderText="Лого">
                </asp:ImageField>
                <asp:TemplateField HeaderText="Название">
                    <ItemTemplate>
                        <%--<asp:Label runat="server" ID="lName"></asp:Label>--%>
                        <cc1:ResourceWritter ID="rlName" runat="server" 
                            ResourceId='<%# Eval("NameTextId") %>' Language="RU">
                        </cc1:ResourceWritter>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Удалить">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton5" runat="server" 
                            CommandArgument='<%# Eval("ID") %>' CommandName="DeleteTeam">Удалить</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:LinkButton ID="lbCreate" runat="server" Text="Создать"></asp:LinkButton>
        
        <cc2:PopupControlExtender ID="LinkButton1_PopupControlExtender" runat="server" 
             Enabled="True" PopupControlID="pCreateTeam" 
            TargetControlID="lbCreate" Position="Bottom">
        </cc2:PopupControlExtender>
        <%--<asp:Label runat="server" ID="lName"></asp:Label>--%>
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
    
<%--<cc2:DropShadowExtender runat="server" TargetControlID="pCreateTeam" Rounded="true" Radius="4"></cc2:DropShadowExtender>--%>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="ldsMatches" 
            GridLines="Horizontal" oneditcommand="DataList1_EditCommand" 
            onitemdatabound="DataList1_ItemDataBound" 
            onupdatecommand="DataList1_UpdateCommand" 
            oncancelcommand="DataList1_CancelCommand" 
            ondeletecommand="DataList1_DeleteCommand">
            <EditItemTemplate>
                <asp:Label ID="Label4" runat="server" Text="Маестро "></asp:Label>
                <asp:TextBox ID="tbHostCount" runat="server" Width="32px" 
                    Text='<%# Eval("HostCount") %>'></asp:TextBox>
                <cc2:MaskedEditExtender ID="tbHostCount_MaskedEditExtender" runat="server" 
                    AutoComplete="False" CultureAMPMPlaceholder="" 
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                    Mask="99" MaskType="Number" TargetControlID="tbHostCount">
                </cc2:MaskedEditExtender>
                <asp:Label ID="Label3" runat="server" Text="&amp;nbsp;&amp;mdash;&amp;nbsp;"></asp:Label>
                <asp:TextBox ID="tbTeamCount" runat="server" Width="32px" 
                    Text='<%# Eval("TeamCount") %>' EnableViewState="False"></asp:TextBox>
                <cc2:MaskedEditExtender ID="tbTeamCount_MaskedEditExtender" runat="server" 
                    AutoComplete="False" CultureAMPMPlaceholder="" 
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                    Mask="99" MaskType="Number" TargetControlID="tbTeamCount">
                </cc2:MaskedEditExtender>
                <asp:DropDownList ID="ddlTeams" runat="server">
                </asp:DropDownList>
                <br />
                Дата:
                <asp:TextBox ID="tbDate" runat="server" Text='<%# Bind("Date", "{0:dd.MM.yyyy}") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="tbDate" ErrorMessage="*" ValidationGroup="g2"></asp:RequiredFieldValidator>
                <br />
                <asp:CheckBox ID="cbPlayed" runat="server" Checked='<%# Bind("Played") %>' 
                    Text="Сыгранная" />
                <asp:HiddenField ID="hfTeamId" runat="server" Value='<%# Eval("TeamID") %>' />
                <br />
                <cc2:CalendarExtender ID="TextBox3_CalendarExtender" runat="server" 
                    TargetControlID="tbDate" Format="dd.MM.yyyy" FirstDayOfWeek="Monday">
                </cc2:CalendarExtender>
                
                
                Забили / предупреждения
                <div style="float:left; width:185px;">
                    <cc1:ResourceEditor ResourceId='<%# Bind("HostCommentsTextID") %>' Type="MultiLine" ID="reHostComments" runat="server">
                    </cc1:ResourceEditor>
                </div>                
                <div style="float:left; padding-left:10px; width:185px;">
                    <cc1:ResourceEditor ResourceId='<%# Bind("TeamCommentsTextID") %>' Type="MultiLine" ID="reTeamComments" runat="server">
                    </cc1:ResourceEditor>
                </div>
                <div style="clear:both">
                    <asp:LinkButton ID="lbSave" runat="server" CommandName="update" 
                        ValidationGroup="g2" CommandArgument='<%# Eval("ID") %>' Text="Сохранить"></asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="lbCancel" runat="server" CommandName="cancel">Отмена</asp:LinkButton>
                </div>
                <br />
            </EditItemTemplate>
            <ItemTemplate>
                <div style="float:left;">
                    <asp:Image ID="iMaestroLogo" runat="server" ImageUrl="~/Images/mae.gif" />
                    
                    <br />
                    <asp:Label ID="lMaestro" runat="server" Text="Маестро"></asp:Label>
                    
                </div>  
                <div style="float:left; padding:0 10px;">
                    &nbsp;<asp:Label ID="lHostCount" runat="server" Text='<%# Eval("HostCount") %>'></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="&amp;nbsp;&amp;mdash;&amp;nbsp;"></asp:Label>
                    <asp:Label ID="lTeamCount" runat="server" Text='<%# Eval("TeamCount") %>'></asp:Label>
                    &nbsp;
                    <br />
                    <asp:Label ID="lDate" runat="server" Text='<%# Eval("Date", "{0:dd.MM.yyyy}") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Сыгранная" 
                        Visible='<%# Eval("Played") %>'></asp:Label>
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit" 
                        CausesValidation="False" CommandArgument='<%# Eval("ID") %>'>Редактировать</asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="delete" 
                        CommandArgument='<%# Eval("ID") %>' CausesValidation="False">Удалить</asp:LinkButton>
                </div>  
                <div style="float:left;">
                    <asp:Image ID="iTeamLogo" runat="server" />
                    <br />
                    <asp:Label ID="lTeam" runat="server" Text="Команда"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <br />
        <asp:Panel ID="Panel1" runat="server" style="width:400px;">
            <asp:Label ID="Label5" runat="server" Text="Маестро "></asp:Label>
            <asp:TextBox ID="tbHostCount" runat="server" Width="32px" 
                    Text='<%# Eval("HostCount") %>'></asp:TextBox>
            <cc2:MaskedEditExtender ID="tbHostCount_MaskedEditExtender" runat="server" 
                AutoComplete="False" Mask="99" MaskType="Number" TargetControlID="tbHostCount">
            </cc2:MaskedEditExtender>
            <asp:Label ID="Label6" runat="server" Text="&amp;nbsp;&amp;mdash;&amp;nbsp;"></asp:Label>
            <asp:TextBox ID="tbTeamCount" runat="server" Width="32px" 
                    Text='<%# Eval("TeamCount") %>' EnableViewState="true"></asp:TextBox>
            <cc2:MaskedEditExtender ID="tbTeamCount_MaskedEditExtender" runat="server" 
                AutoComplete="False" ClipboardEnabled="False" Mask="99" MaskType="Number" 
                MessageValidatorTip="False" TargetControlID="tbTeamCount">
            </cc2:MaskedEditExtender>
            <asp:DropDownList ID="ddlTeams" runat="server">
            </asp:DropDownList>
            <br />
            Дата:
            <asp:TextBox ID="tbAddDate" runat="server" EnableViewState="False"></asp:TextBox>
            <cc2:CalendarExtender ID="tbAddDate_CalendarExtender" runat="server" 
                    TargetControlID="tbAddDate" Format="dd.MM.yyyy" 
                FirstDayOfWeek="Monday">
            </cc2:CalendarExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="tbAddDate" ErrorMessage="*" ValidationGroup="g1"></asp:RequiredFieldValidator>
            <br />
            <asp:CheckBox ID="cbPlayed" runat="server" 
                Text="Сыгранная" />
            <br />
            Забили / предупреждения
            <div style="float:left; width:185px;">
                <cc1:ResourceEditor Type="MultiLine" ID="reHostComments" runat="server">
                </cc1:ResourceEditor>
            </div>                
            <div style="float:left; padding-left:10px; width:185px;">
                <cc1:ResourceEditor Type="MultiLine" ID="reTeamComments" runat="server">
                </cc1:ResourceEditor>
            </div>
            <div style="clear:both">
                <asp:LinkButton ID="lbAdd" runat="server" onclick="lbAdd_Click" 
                    ValidationGroup="g1">Добавить</asp:LinkButton>
            </div>                
            &nbsp;
        </asp:Panel>
        <br />
    </div>
</asp:Content>  

