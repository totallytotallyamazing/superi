<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Administration_ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>��������� ������</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ChangePassword ID="ChangePassword1" runat="server" 
            CancelButtonText="������" ChangePasswordButtonText="�������� ������" 
            ChangePasswordFailureText="������ ������������ ��� ����� ������ �� �������������� �����������. ����������� ���������� ��������: {0}. ��������, �������� �� ���� ��� ����: {1}." 
            ChangePasswordTitleText="����� ������" 
            ConfirmNewPasswordLabelText="������������� ������ ������:" 
            ConfirmPasswordCompareErrorMessage="����� ������ � ������������� ������ ���������." 
            ConfirmPasswordRequiredErrorMessage="������� ������������� ������." 
            NewPasswordLabelText="����� ������:" 
            NewPasswordRequiredErrorMessage="������� ����� ������." 
            OnContinueButtonClick="ChangePassword1_ContinueButtonClick" 
            PasswordLabelText="������ ������:" 
            PasswordRequiredErrorMessage="������� ������ ������." 
            SuccessText="������ ��� ������� �������" 
            SuccessTitleText="����� ������ ���������" UserNameLabelText="��� ������������:" 
            UserNameRequiredErrorMessage="������� ��� ������������." 
            ContinueButtonText="����������" 
            oncancelbuttonclick="ChangePassword1_CancelButtonClick">
        </asp:ChangePassword>
    </div>
    </form>
</body>
</html>
