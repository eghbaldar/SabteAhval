<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SettingPanel.aspx.cs" Inherits="SettingPanel"
    StylesheetTheme="Default_Blue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                    <td width="750" height="300" align="right" dir="rtl" valign="top">
                        &nbsp;<asp:TreeView ID="TreeView1" runat="server" ExpandDepth="0" ImageSet="Contacts"
                            NodeIndent="10" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" Style="direction: rtl"
                            Width="100%" Height="96px">
                            <ParentNodeStyle Font-Bold="True" ForeColor="#5555DD" />
                            <HoverNodeStyle Font-Underline="False" />
                            <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                            <Nodes>
                                <asp:TreeNode SelectAction="Expand" Text="دسترسي" Value="Security">
                                    <asp:TreeNode Text="تعريف کاربران" Value="User" Target="~/Security/User.aspx">
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="تعريف گروه" Value="Group" Target="~/Security/Group.aspx">
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="کاربر گروه" Value="UserGroup" Target="~/Security/UserGroup.aspx"></asp:TreeNode>
                                    <asp:TreeNode Text="تعريف عمل Action" Target="~/Security/Action.aspx" Value="تعريف عمل Action"></asp:TreeNode>
                                    <asp:TreeNode Text="تعريف فعاليت" Target="~/Security/Activity.aspx" Value="تعريف فعاليت"></asp:TreeNode>
                                    <asp:TreeNode Text="انتساب فعاليت به گروه" Target="~/Security/ActivityGroup.aspx" Value="انتساب فعاليت به گروه"></asp:TreeNode>
                                    <asp:TreeNode Text="نوع فعاليت" Target="~/Security/ActivityType.aspx" Value="نوع فعاليت"></asp:TreeNode>
                                    <asp:TreeNode Text="انتساب عمل به نوع فعاليت" Target="~/Security/ActivityTypeAction.aspx" Value="انتساب عمل به نوع فعاليت">
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="انتساب کاربر به اداره" Target="~/Security/UserOffice.aspx" Value="انتساب کاربر به اداره"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode SelectAction="Expand" Text="ثبت احوال" Value="ثبت احوال">
                                    <asp:TreeNode Text="تعريف ادارات" Target="~/Base/Office.aspx" Value="تعريف ادارات"></asp:TreeNode>
                                    <asp:TreeNode Text="وضعيت کارت ملي" Target="~/Base/Status.aspx" Value="وضعيت کارت ملي"></asp:TreeNode>
                                    <asp:TreeNode Text="ليست شماره هاي ملي" Target="~/Person.aspx" Value="ليست شماره هاي ملي"></asp:TreeNode>
                                    <asp:TreeNode Text="ورود اطلاعات" Target="~/Convertor.aspx" Value="ورود اطلاعات"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="گزارشات" Value="Reports">
                                    <asp:TreeNode Text="گزارش کارت شناسايي ملي" Value="Rep_NatinalCard" Target="~/Reports/Rep_NationalCard.aspx"></asp:TreeNode>
                                </asp:TreeNode>
                            </Nodes>
                            <NodeStyle ChildNodesPadding="5px" Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black"
                                HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="3px" Width="150px" />
                        </asp:TreeView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
