<%@ Page Language="C#" MasterPageFile="~/Administration/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Texts.aspx.cs" Inherits="Administration_Texts" Title="Untitled Page" %>
<%@ Register TagPrefix="FCKeditor" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<%@ Register TagPrefix="Controls" Namespace="CustomControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:HiddenField ID="hfTextSelected" runat="server" />
	<asp:GridView ID="gwTexts" runat="server" AutoGenerateColumns="False" DataSourceID="odsTexts" DataKeyNames="ID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
		<Columns>
			<asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
			<asp:BoundField DataField="Alias" HeaderText="�������� ������" SortExpression="Alias" />
			<asp:BoundField DataField="Name" HeaderText="���������" SortExpression="Name" />
			<asp:CommandField CancelText="������" DeleteText="�������" EditText="�������� ����� � ���������"
				InsertText="��������" SelectText="��������" ShowEditButton="True" UpdateText="���������" />
			<asp:CommandField SelectText="�����" ShowSelectButton="True" />
			<asp:CommandField DeleteText="�������" ShowDeleteButton="True" />
		</Columns>
	</asp:GridView>
	<asp:FormView ID="fwText" runat="server" DataSourceID="odsTexts" DefaultMode="Insert">
		<InsertItemTemplate>
			�������� ������:
			<asp:TextBox ID="AliasTextBox" runat="server" Text='<%# Bind("Alias") %>'>
			</asp:TextBox><br />
			���������:
			<asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>'>
			</asp:TextBox><br />
			<asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
				Text="��������">
			</asp:LinkButton>
		</InsertItemTemplate>
	</asp:FormView>
	
	<asp:ObjectDataSource ID="odsTexts" runat="server" DeleteMethod="DeleteText" InsertMethod="InsertText"
		SelectMethod="GetTexts" TypeName="Superi.Features.Texts" UpdateMethod="UpdateTextName">
		<DeleteParameters>
			<asp:Parameter Name="ID" Type="Int32" />
		</DeleteParameters>
		<UpdateParameters>
			<asp:Parameter Name="Name" Type="String" />
			<asp:Parameter Name="Id" Type="Int32" />
		</UpdateParameters>
		<InsertParameters>
			<asp:Parameter Name="Name" Type="String" />
		</InsertParameters>
	</asp:ObjectDataSource>

	
	<asp:PlaceHolder id="phEdit" runat="server" Visible="false">
		<div>
	        ��������:
	        <Controls:ResourceEditor Type="SingleLine" ID="reName" runat="server"></Controls:ResourceEditor>
	    </div>
	    <div style="height:600px;">
    	    <Controls:ResourceEditor Type="RichText" ID="reText" runat="server" RichHeight="550"></Controls:ResourceEditor>
    	</div>
<%--		<FCKeditor:FCKeditor Height="600px" id="fckeDescription" runat="server" BasePath="~/Administration/Controls/fckeditor/"></FCKeditor:FCKeditor>--%>
		<asp:Button ID="btnUpdateDescription" runat="server" Text="���������" />
	</asp:PlaceHolder>

</asp:Content>

