<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"
    StylesheetTheme="Default_Blue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <title>ورود کاربران</title>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
            <tr>
                <td width="100%" height="30%">
                </td>
            </tr>
            <tr>
                <td width="100%" height="40%" align="center" valign="middle">
                    <asp:Login ID="Login1" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4"
                        BorderStyle="Solid" BorderWidth="1px" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#333333"
                        Height="150px" PasswordLabelText="رمز عبور :" UserNameLabelText="نام کاربر :"
                        Width="260px" DisplayRememberMe="False" LoginButtonText="ورود" OnAuthenticate="Login1_Authenticate"
                        PasswordRequiredErrorMessage="رمز عبور را وارد نماييد" TitleText="ورود کاربر"
                        UserNameRequiredErrorMessage="نام کاربري را وارد نماييد" FailureText="نام کاربري يا رمز عبور اشتباه است.">
                        <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                        <TextBoxStyle CssClass="txt_nrm" Width="150px" />
                        <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px"
                            ForeColor="#284E98" CssClass="btn_nrm" Width="70px" />
                    </asp:Login>
                </td>
            </tr>
            <tr>
                <td width="100%" height="30%">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
