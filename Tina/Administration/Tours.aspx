<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="Tours.aspx.cs" Inherits="Administration_Tours" ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Assembly="Superi" Namespace="Superi.CustomControls" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagName="TourProperties" TagPrefix="admin" Src="~/Administration/Controls/EditTour.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(TourEndRequest);

        function TourEndRequest() {
            if (GetAction() == "EditDescription") {
                $find("<%= mpeTourDetails.ClientID %>").show();
                SetAction('');
            }
        }

        function SetAction(val) {
            $get("ihAction").value = val;
        }

        function GetAction() {
            return $get("ihAction").value;
        }
    </script>

    <input type="hidden" id="ihAction" />


    <asp:LinqDataSource ID="ldsTours" runat="server" ContextTypeName="TourDataContext"
        EnableDelete="True" EnableInsert="True" EnableUpdate="True" TableName="Tours">
    </asp:LinqDataSource>
    <div style="float: left;">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                    DataSourceID="ldsTours" CellPadding="10" ForeColor="#333333" GridLines="Vertical"
                    EnableViewState="False" OnRowDataBound="GridView1_RowDataBound" BorderColor="Transparent"
                    BorderWidth="4px" HorizontalAlign="Center" 
                    onrowcommand="GridView1_RowCommand">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="#" InsertVisible="False" ReadOnly="True"
                            SortExpression="ID" />
                        <asp:BoundField DataField="Name" HeaderText="Название" SortExpression="Name" />
                        <asp:BoundField DataField="Year" HeaderText="Год" SortExpression="Year" />
                        <asp:TemplateField HeaderText="Фон">
                            <ItemTemplate>
                                <asp:Image Width="102px" Height="77px" ID="Image1" runat="server" ImageUrl='<%# Eval("BackgroundImage", "~/Images/TourImages/{0}") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="imageSmall" Height="76px" Width="102px" />
                        </asp:TemplateField>
                        <asp:CheckBoxField DataField="BlackText" HeaderText="Черный" SortExpression="BlackText">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CheckBoxField>
                        <asp:TemplateField HeaderText="Цвет городов">
                            <ItemTemplate>
                                <asp:Panel ID="pBgColor" runat="server" BorderColor="Black" Height="20px" Width="125px">
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Редактировать описание">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDescription" runat="server" CommandArgument='<%# Eval("ID") %>'
                                    CommandName="EditDescription">Редактировать описание</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Удалить" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    Text="Удалить"></asp:LinkButton>
                                <cc1:ConfirmButtonExtender ID="LinkButton1_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Вы уверенны что хотите удалить тур?" Enabled="True" TargetControlID="LinkButton1">
                                </cc1:ConfirmButtonExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        empty
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
            </Triggers>
        </asp:UpdatePanel>
        <fieldset style="padding: 10px; text-align: left; width: 200px; border: 1px solid #ccc;">
            <legend>Добавить тур:</legend>
            <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox><br />
            <cc1:TextBoxWatermarkExtender ID="tbTitle_TextBoxWatermarkExtender" runat="server"
                Enabled="True" TargetControlID="tbTitle" WatermarkText="Название">
            </cc1:TextBoxWatermarkExtender>
            <asp:TextBox runat="server" ID="tbYear"></asp:TextBox><br />
            <cc1:MaskedEditExtender ID="tbYear_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                Enabled="True" Mask="9999" MaskType="Number" TargetControlID="tbYear">
            </cc1:MaskedEditExtender>
            <cc1:TextBoxWatermarkExtender ID="tbYear_TextBoxWatermarkExtender" runat="server"
                Enabled="True" TargetControlID="tbYear" WatermarkText="Год">
            </cc1:TextBoxWatermarkExtender>
            <asp:TextBox runat="server" ID="tbBackground"></asp:TextBox><br />
            <cc1:TextBoxWatermarkExtender ID="tbBackground_TextBoxWatermarkExtender" runat="server"
                Enabled="True" TargetControlID="tbBackground" WatermarkText="Фон городов">
            </cc1:TextBoxWatermarkExtender>
            <asp:CheckBox runat="server" Text="Черный текст" ID="cbBlackText" /><br />
            <cc2:FolderUpload ID="fuBackgroundImage" runat="server" Folder="~/Images/TourImages/" /><br />
            <asp:LinkButton runat="server" ID="lbAdd" Text="Добавить" OnClick="lbAdd_Click"></asp:LinkButton>
        </fieldset>
    </div>
    <div style="float: left; padding-left: 10px; width: 300px;">
        <asp:SqlDataSource ID="sdsTourPictures" runat="server" ConnectionString="<%$ ConnectionStrings:ContentConnectionString %>"
            DeleteCommand="DELETE FROM [TourPictures] WHERE [ID] = @ID" InsertCommand="INSERT INTO [TourPictures] ([Picture], [Preview], [TourID], [SortOrder]) VALUES (@Picture, @Preview, @TourID, @SortOrder)"
            SelectCommand="SELECT * FROM [TourPictures] ORDER BY [SortOrder]" UpdateCommand="UPDATE [TourPictures] SET [Picture] = @Picture, [Preview] = @Preview, [TourID] = @TourID, [SortOrder] = @SortOrder WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Picture" Type="String" />
                <asp:Parameter Name="Preview" Type="String" />
                <asp:Parameter Name="TourID" Type="Int32" />
                <asp:Parameter Name="SortOrder" Type="Int32" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Picture" Type="String" />
                <asp:Parameter Name="Preview" Type="String" />
                <asp:Parameter Name="TourID" Type="Int32" />
                <asp:Parameter Name="SortOrder" Type="Int32" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:DropDownList ID="ddlTours" runat="server" AutoPostBack="True" DataSourceID="ldsTours"
            DataTextField="Name" DataValueField="ID">
        </asp:DropDownList>
        <br />
        Изображение:
        <cc2:FolderUpload ID="fuPicture" runat="server" Folder="~/Images/Gallery/Tours/"
            UnificateIncrementally="True" Unificator="_" UnificatorPosition="Postfix" /><br />
        Превью:
        <cc2:FolderUpload ID="fuPreview" runat="server" Folder="~/Images/Gallery/Tours/"
            UnificateIncrementally="True" Unificator="_" UnificatorPosition="Postfix" />
        <br />
        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" Text="Добавить"
            OnClick="InsertButton_Click" />
        <br />
        <br />
        <cc1:ReorderList ID="ReorderList1" runat="server" AllowReorder="True" DataSourceID="sdsTourPictures"
            PostBackOnReorder="false" SortOrderField="SortOrder" DragHandleAlignment="Left"
            DataKeyField="ID" OnItemCommand="ReorderList1_ItemCommand" Visible="true">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Preview", "~/Images/Gallery/Tours/{0}") %>' />
                <br />
                <asp:LinkButton runat="server" Text="Удалить" ID="lbDelete" CommandName="DeleteItem"
                    CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                <cc1:ConfirmButtonExtender ID="Image1_ConfirmButtonExtender" runat="server" ConfirmText="Вы уверенны что хотите удалить картинку?"
                    Enabled="True" TargetControlID="lbDelete">
                </cc1:ConfirmButtonExtender>
            </ItemTemplate>
            <DragHandleTemplate>
                <div style="height: 80px; width: 80px; cursor: n-resize; background-color: Teal;">
                    Потяните чтобы изменить положение
                </div>
            </DragHandleTemplate>
        </cc1:ReorderList>
        
        <asp:UpdatePanel runat="server" ID="upTourDescription">
            <ContentTemplate>
                <asp:LinkButton runat="server" ID="lbStub" style="display:none" />
                <asp:Panel runat="server" ID="pTourDetails" style="background-color:White;">
                    <div style="width:100%; text-align:right;"><asp:LinkButton runat="server" ID="lbCancel" Text="X"></asp:LinkButton></div>
                    <admin:TourProperties runat="server" ID="tpDetails" />
                    <div style="clear:both;">
                        <asp:Button Text="Сохранить" runat="server" ID="bSave" onclick="bSave_Click" />
                    </div>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="mpeTourDetails" runat="server" 
                    BackgroundCssClass="shaded" CancelControlID="lbCancel" DropShadow="True" 
                    DynamicServicePath="" Enabled="True" PopupControlID="pTourDetails" 
                    TargetControlID="lbStub">
                </cc1:ModalPopupExtender>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="bSave" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
