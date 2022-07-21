<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Person.aspx.cs" Inherits="Person"
    Title="" StylesheetTheme="Default_Blue" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                        Style="direction: rtl" DataKeyField="NationalID" AllowSorting="True" OnItemDataBound="gvMaster_ItemDataBound"
                        OnPageIndexChanged="gvMaster_PageIndexChanged" OnItemCommand="gvMaster_ItemCommand"
                        AutoUpdateAfterCallBack="True" PageSize="10" TextDuringCallBack='<img src="s" />'>
                        <Columns>
                            <asp:TemplateColumn>
                                <headertemplate>
                            <table border="0" cellpadding="0" cellspacing="0" dir="rtl">
                                    <tr>
                                        <td width="20">
                                        </td>
                                        <td align="center" width="150px">
                                            شماره ملي</td>
                                        <td align="center" width="200px">
                                            اداره</td>
                                        <td align="center" width="200px">
                                            وضعيت</td>
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
                                        <anthem:ImageButton id="imgSelect" runat="server" ImageUrl="~/Images/back_16.gif" AutoUpdateAfterCallBack="True" EnableTheming="False" TextDuringCallBack='<img src="Images/tiny_red.gif" />' CausesValidation="False" CommandName="Select"></anthem:ImageButton> 
                                    </TD>
                                    <TD width="150px">
                                        <%# ((PNationalCard.Entity.Person)Container.DataItem).NationalID%>
                                    </TD>
                                    <TD width="200px">
                                        <%# ((PNationalCard.Entity.Person)Container.DataItem).Office.OfficeName%>
                                    </TD>
                                    <TD width="200px">
                                        <%# ((PNationalCard.Entity.Person)Container.DataItem).Status.StatusDesc%>
                                    </TD>
                                    <TD width=20>
                                       <anthem:ImageButton id="imgIssued" runat="server" ImageUrl="~/Images/edit_16.gif" AutoUpdateAfterCallBack="True" ToolTip="ويرايش" EnableTheming="False" TextDuringCallBack='<img src="Images/tiny_red.gif" />' CommandName="Edit"></anthem:ImageButton>
                                    </TD>
                                    <TD width=20>
                                        <anthem:ImageButton id="imgDelete" runat="server" ImageUrl="~/Images/cancl_16.gif" AutoUpdateAfterCallBack="True" ToolTip="حذف" EnableTheming="False" TextDuringCallBack='<img src="Images/tiny_red.gif" />' CommandName="Delete" OnClientClick="javascript:return confirm('آيا مطمئن به حذف هستيد؟');"></anthem:ImageButton>
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
                                        <td style="height: 22px" align="right" width="400">
                                            <anthem:Label ID="lblRecStatus" runat="server" CssClass="lbl_nrm" Width="350px" AutoUpdateAfterCallBack="True"
                                                UpdateAfterCallBack="True">نمايش</anthem:Label></td>
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
                                                شماره ملي :</td>
                                            <td width="400">
                                                <anthem:TextBox Width="150" ID="txtNationalID" runat="server" AutoUpdateAfterCallBack="True"
                                                    Enabled="False" MaxLength="10"></anthem:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100">
                                                اداره :</td>
                                            <td width="400">
                                                <anthem:DropDownList ID="drpOfficeID" runat="server" AutoUpdateAfterCallBack="True"
                                                    Enabled="False" Width="250px" DataTextField="OfficeName" DataValueField="OfficeID">
                                                </anthem:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100">
                                                وضعيت :</td>
                                            <td width="400">
                                                <anthem:DropDownList ID="drpStatusID" runat="server" AutoUpdateAfterCallBack="True"
                                                    Enabled="False" Width="100px" DataTextField="StatusID" DataValueField="StatusID"
                                                    OnSelectedIndexChanged="drpStatusID_SelectedIndexChanged" AutoCallBack="True"
                                                    TextDuringCallBack="...">
                                                </anthem:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100">
                                            </td>
                                            <td width="400">
                                                <anthem:Label ID="lblStatusDesc" runat="server" AutoUpdateAfterCallBack="True" CssClass="lbl_nrm"
                                                    Height="50px" UpdateAfterCallBack="True" Width="390px"></anthem:Label></td>
                                        </tr>
                                    </table>
                                </anthem:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <table style="border-right: cornflowerblue 1px solid; border-top: cornflowerblue 1px solid;
                                    border-left: cornflowerblue 1px solid; border-bottom: cornflowerblue 1px solid;
                                    background-color: white" width="210">
                                    <tr>
                                        <td style="text-align: center" width="25">
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/edit_16.gif" /></td>
                                        <td width="185">
                                            ويرايش</td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center" width="25">
                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/cancl_16.gif" /></td>
                                        <td width="185">
                                            حذف</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <a href="SettingPanel.aspx">پنل اصلي</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <a href="Login.aspx">خروج</a>
                                        </td>
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
