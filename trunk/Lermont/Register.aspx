<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
        LoginCreatedUser="False">
        <WizardSteps>
<asp:CreateUserWizardStep runat="server"></asp:CreateUserWizardStep>
<asp:CompleteWizardStep runat="server"></asp:CompleteWizardStep>
</WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>

