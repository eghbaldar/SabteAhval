<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Group.aspx.cs" Inherits="Group"
    Title="" StylesheetTheme="Default_Blue" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>تعريف گروه کاربران</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="CommonMessageTitle" style="right: 0px; width: 750px; top: 0px; height: 36px">
        </div>
        <table id="TABLE1" class="CommonMessageContent" style="border-right: #9fbde5 2px solid;
            border-top: #9fbde5 2px solid; right: 0px; border-left: #9fbde5 2px solid; border-bottom: #9fbde5 2px solid;
            top: 0px; height: 36px" width="750" dir="rtl">
            <tr>
                <td height="200" style="width: 750px">
                    <anthem:DataGrid ID="gvMaster" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        Style="direction: rtl" DataKeyField="GroupID" AllowSorting="True" OnItemDataBound="gvMaster_ItemDataBound"
                        OnPageIndexChanged="gvMaster_PageIndexChanged" OnItemCommand="gvMaster_ItemCommand"
                        AutoUpdateAfterCallBack="True" PageSize="10" TextDuringCallBack='<img src="../Images/tiny_red.gif" />'>
                        <Columns>
                            <asp:TemplateColumn>
                                <headertemplate>
                            <table border="0" cellpadding="0" cellspacing="0" dir="rtl">
                                    <tr>
                                        <td width="20">
                                        </td>
                                        <td align="center" width="100px">
                                            کد گروه</td>
                                        <td align="center" width="300px">
                                            نام گروه</td>
                                        <td width="20">
                                        </td>
                                        <td width="20">
                                        </td>
                                        <td width="20">
                                        </td>
                                    </tr>
                            </table>
                        </headertemplate>
                                <itemtemplate>
                            <TABLE dir="rtl" cellSpacing="0" cellPadding="0" border="0">
                                <TR>
                                    <TD width=20>
                                        <anthem:ImageButton id="imgSelect" runat="server" ImageUrl="~/Images/back_16.gif" AutoUpdateAfterCallBack="True" EnableTheming="False" TextDuringCallBack='<img src="../Images/tiny_red.gif" />' CausesValidation="False" CommandName="Select"></anthem:ImageButton> 
                                    </TD>
                                    <TD width="100px">
                                        <%# ((HNP.Security.Difinition.Group)Container.DataItem).GroupID%>
                                    </TD>
                                    <TD width="300px">
                                        <%# ((HNP.Security.Difinition.Group)Container.DataItem).GroupName%>
                                    </TD>
                                    <TD width=20>
                                       <anthem:ImageButton id="imgIssued" runat="server" ImageUrl="~/Images/edit_16.gif" AutoUpdateAfterCallBack="True" ToolTip="ويرايش" EnableTheming="False" TextDuringCallBack='<img src="../Images/tiny_red.gif" />' CommandName="Edit"></anthem:ImageButton>
                                    </TD>
                                    <TD width=20>
                                        <anthem:ImageButton id="imgDelete" runat="server" ImageUrl="~/Images/cancl_16.gif" AutoUpdateAfterCallBack="True" ToolTip="حذف" EnableTheming="False" TextDuringCallBack='<img src="../Images/tiny_red.gif" />' CommandName="Delete" OnClientClick="javascript:return confirm('آيا مطمئن به حذف هستيد؟');"></anthem:ImageButton>
                                    </TD>
                                </TR>
                            </TABLE>
                        </itemtemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <SelectedItemStyle CssClass="popupHover" />
                        <PagerStyle HorizontalAlign="Center" Mode="NumericPages" />
                    </anthem:DataGrid></td>
            </tr>
            <tr>
                <td height="150" style="vertical-align: top;">
                    <table>
                        <tr>
                            <td axis="1" class="div_toolbox">
                                <table cellpadding="0" cellspacing="0" style="text-align: center">
                                    <tr>
                                        <td style="height: 22px">
                                            <anthem:Button ID="BtnAppend" runat="server" AutoUpdateAfterCallBack="True" CssClass="btnappend"
                                                TextDuringCallBack='...' ToolTip="ايجاد" EnableTheming="False" OnClick="BtnAppend_Click" /></td>
                                        <td style="height: 22px">
                                            <anthem:Button ID="BtnSave" runat="server" AutoUpdateAfterCallBack="True" CssClass="btnsave"
                                                TextDuringCallBack='...' ToolTip="ذخيره" Visible="False" EnableTheming="False"
                                                OnClick="BtnSave_Click" /></td>
                                        <td style="height: 22px">
                                            <anthem:Button ID="BtnCancel" runat="server" AutoUpdateAfterCallBack="True" CssClass="btncancel"
                                                TextDuringCallBack='...' ToolTip="انصراف" Visible="False" EnableTheming="False"
                                                OnClick="BtnCancel_Click" CausesValidation="False" /></td>
                                        <td style="height: 22px">
                                            <anthem:Label ID="lblRecStatus" runat="server" CssClass="lbl_nrm" Width="51px" AutoUpdateAfterCallBack="True"
                                                UpdateAfterCallBack="True">نمايش</anthem:Label></td>
                                        <td style="height: 22px">
                                            <anthem:Label ID="lblStatus" runat="server" CssClass="lbl_nrm" Font-Names="Tahoma"
                                                Font-Size="8pt" Width="350px"></anthem:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <anthem:Panel ID="plMaster" runat="server" Height="100%" Width="100%">
                                    <table width="500">
                                        <tr>
                                            <td width="100">
                                                کد گروه :</td>
                                            <td width="400">
                                                <anthem:Label ID="lblGroupID" runat="server" AutoUpdateAfterCallBack="True" Enabled="False"></anthem:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100">
                                                نام گروه :</td>
                                            <td width="400">
                                                <anthem:TextBox Width="300" ID="txtGroupName" runat="server" AutoUpdateAfterCallBack="True"
                                                    Enabled="False"></anthem:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </anthem:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
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
    </form>
</body>
</html>
