<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_NationalCard.aspx.cs"
    Inherits="Reports_Rep_NationalCard" StylesheetTheme="Default_Blue" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>گزارش کارت شناسايي ملي</title>
    <link rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div class="CommonMessageTitle" style="right: 0px; width: 750px; top: 0px; height: 36px">
            </div>
            <table id="TABLE1" class="CommonMessageContent" style="border-right: #9fbde5 2px solid;
                border-top: #9fbde5 2px solid; right: 0px; border-left: #9fbde5 2px solid; border-bottom: #9fbde5 2px solid;
                top: 0px; height: 36px" width="750" dir="rtl">
                <tr>
                    <td width="750" align="center" dir="rtl">
                        <table border="0" cellpadding="0" cellspacing="0" width="600">
                            <tr>
                                <td width="600">
                                    <table border="0" cellpadding="0" cellspacing="0" width="600">
                                        <tr>
                                            <td width="250" align="right" dir="rtl">
                                                <anthem:RadioButton ID="rdbStatus" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                                    GroupName="NationalCard" Text="بر اساس وضعيت" OnCheckedChanged="rdbStatus_CheckedChanged" /></td>
                                            <td width="250" align="right" dir="rtl">
                                                <anthem:RadioButton ID="rdbOffice" runat="server" AutoCallBack="True" AutoUpdateAfterCallBack="True"
                                                    GroupName="NationalCard" Text="بر اساس اداره" OnCheckedChanged="rdbOffice_CheckedChanged" /></td>
                                            <td width="100" rowspan="2">
                                                <anthem:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/Images/Refresh.jpg"
                                                    TextDuringCallBack='<img src="../Images/ajaxrefresh.gif" />' AutoUpdateAfterCallBack="True"
                                                    OnClick="btnRefresh_Click" /></td>
                                        </tr>
                                        <tr>
                                            <td width="250" align="right" dir="rtl">
                                                <anthem:DropDownList ID="ddlStatus" runat="server" Width="200px" DataTextField="StatusID"
                                                    DataValueField="StatusID" AutoUpdateAfterCallBack="True">
                                                </anthem:DropDownList>
                                            </td>
                                            <td width="250" align="right" dir="rtl">
                                                <anthem:DropDownList ID="ddlOffice" runat="server" Width="200px" DataTextField="OfficeName"
                                                    DataValueField="OfficeID" AutoUpdateAfterCallBack="True">
                                                </anthem:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="600">
                                    <br />
                                    <anthem:DataGrid runat="server" ID="dgNationalCard" AutoGenerateColumns="False" EnableTheming="False"
                                        AllowPaging="True" PagerStyle-Mode="NumericPages" PageSize="20" CellPadding="4"
                                        ForeColor="#333333" GridLines="None" AutoUpdateAfterCallBack="True">
                                        <Columns>
                                            <asp:TemplateColumn>
                                                <headertemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="500">
                                                        <tr>
                                                            <td width="200">
                                                                شماره ملي
                                                            </td>
                                                            <td width="150">
                                                                وضعيت
                                                            </td>
                                                            <td width="150">
                                                                اداره
                                                            </td>
                                                        </tr>
                                                    </table>
                                                
</headertemplate>
                                                <itemtemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="500">
                                                        <tr>
                                                            <td width="200">
                                                                <%# ((PNationalCard.Entity.Person)Container.DataItem).NationalID %>
                                                            </td>
                                                            <td width="150">
                                                                <%# ((PNationalCard.Entity.Person)Container.DataItem).Status.StatusID %>
                                                            </td>
                                                            <td width="150">
                                                                <%# ((PNationalCard.Entity.Person)Container.DataItem).Office.OfficeName %>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                
</itemtemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <EditItemStyle BackColor="#7C6F57" />
                                        <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                                        <AlternatingItemStyle BackColor="White" />
                                        <ItemStyle BackColor="#E3EAEB" />
                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    </anthem:DataGrid>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="border-right: cornflowerblue 1px solid; border-top: cornflowerblue 1px solid;
                                        border-left: cornflowerblue 1px solid; border-bottom: cornflowerblue 1px solid;
                                        background-color: white" width="300">
                                        <tr>
                                            <td colspan="2" align="center" width="150">
                                                <asp:ImageButton ID="btnHome" runat="server" ImageUrl="~/Images/home.png" OnClick="btnHome_Click"
                                                    ToolTip="صفحه اصلي" /></td>
                                            <td colspan="2" align="center" width="150">
                                                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/Images/exit.png" OnClick="btnExit_Click"
                                                    ToolTip="خروج" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
