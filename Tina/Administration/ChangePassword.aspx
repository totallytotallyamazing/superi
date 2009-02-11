<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Administration_ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Изменение пароля</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ChangePassword ID="ChangePassword1" runat="server" CancelButtonText="Отмена" ChangePasswordButtonText="Изменить пароль" ChangePasswordFailureText="Пароль неправильный или новый пароль не соответствуеть требованиям. Минимальное количество символов: {0}. Символов, отличных от букв или цифр: {1}." ChangePasswordTitleText="Смена пароля" ConfirmNewPasswordLabelText="Подтверждение нового пароля:" ConfirmPasswordCompareErrorMessage="Новый пароль и подтверждение должны совпадать." ConfirmPasswordRequiredErrorMessage="Введите подтверждение пароля." NewPasswordLabelText="Новый пароль:" NewPasswordRequiredErrorMessage="Введите новый пароль." OnContinueButtonClick="ChangePassword1_ContinueButtonClick" PasswordLabelText="Старый пароль:" PasswordRequiredErrorMessage="Введите старый пароль." SuccessText="Пароль был успешно изменен" SuccessTitleText="Смена пароля завершена" UserNameLabelText="Имя пользователя:" UserNameRequiredErrorMessage="Введите имя пользователя." ContinueButtonText="Продолжить">
        </asp:ChangePassword>
    </div>
    </form>
</body>
</html>
