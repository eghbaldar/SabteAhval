<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Convertor.aspx.cs" Inherits="Convertor"
    StylesheetTheme="Default_Blue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="CommonMessageTitle" style="right: 0px; width: 750px; top: 0px; height: 36px"
            align="center">
            <asp:Label runat="server" ID="lblTitle" Text="ورود اطلاعات از طريق بانک اکسس" Font-Bold="True"
                Font-Names="Tahoma" Font-Size="10pt" Height="23px" ></asp:Label>
        </div>
        <table id="TABLE1" class="CommonMessageContent" style="border-right: #9fbde5 2px solid;
            border-top: #9fbde5 2px solid; right: 0px; border-left: #9fbde5 2px solid; border-bottom: #9fbde5 2px solid;
            top: 0px; height: 36px" width="750" dir="rtl">
            <tr>
                <td height="200" style="width: 750px">
                    <table border="0" cellpadding="0" cellspacing="0" width="600">
                        <tr>
                            <td align="right" colspan="2" height="27">
                                <asp:Label ID="lblAlert" runat="server" ForeColor="Red"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="100" height="27" align="right">
                                آدرس فايل :
                            </td>
                            <td width="500" height="27" align="right">
                                <asp:FileUpload ID="fuNationalCard" runat="server" Width="264px" />
                            </td>
                        </tr>
                        <tr>
                            <td width="100" height="27" align="right">
                                اداره مربوطه :
                            </td>
                            <td width="500" height="27" align="right">
                                <asp:DropDownList ID="ddlOffice" runat="server" Width="200px" DataTextField="OfficeName"
                                    DataValueField="OfficeID">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="100" height="27" align="right">
                                وضعيت کارت :
                            </td>
                            <td width="500" height="27" align="right">
                                <asp:DropDownList ID="ddlStatus" runat="server" Width="400px" DataTextField="StatusDesc"
                                    DataValueField="StatusID">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" height="27">
                                <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="ذخيره"
                                    Width="70px" /></td>
                        </tr>
                    </table>
                    <br />
                    <table style="border-right: cornflowerblue 1px solid; border-top: cornflowerblue 1px solid;
                        border-left: cornflowerblue 1px solid; border-bottom: cornflowerblue 1px solid;
                        background-color: white" width="300">
                        <tr>
                            <td align="center" colspan="2" width="150">
                                <asp:ImageButton ID="btnHome" runat="server" ImageUrl="~/Images/home.png" OnClick="btnHome_Click"
                                    ToolTip="صفحه اصلي" /></td>
                            <td align="center" colspan="2" width="150">
                                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/Images/exit.png" OnClick="btnExit_Click"
                                    ToolTip="خروج" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
