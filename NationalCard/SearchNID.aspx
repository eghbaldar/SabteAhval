<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchNID.aspx.cs" Inherits="Page_SearchNID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>پيگيري وضعيت صدور کارت شناسايي ملي</title>
    <link href="App_Themes/Default_Blue/XMain.css" rel="stylesheet" type="text/css" />
</head>

<script language="javascript" type="text/javascript">
    function setFocus(textbox,index)
    {
        var txtname = textbox.id;
        switch (index)
        {
            case 1:
                if (textbox.value.length == 3)
                {
                    txtname = txtname.substring(0,txtname.length -1) + 2;
                    var txt = document.getElementById(txtname);
                    txt.focus();
                }
                break;
            case 2:
                if (textbox.value.length == 6)
                {
                    txtname = txtname.substring(0,txtname.length -1) + 3;
                    var txt = document.getElementById(txtname);
                    txt.focus();
                }
                break;
        }
    }

    function insert(td)
    {
        var nid1 = document.getElementById('txtNID1');
        var nid2 = document.getElementById('txtNID2');
        var nid3 = document.getElementById('txtNID3');
        if(nid1.value.length < 3)
        {
            nid1.value = nid1.value + td.innerHTML;        
        }
        else
        {
            if(nid2.value.length < 6)
            {
                nid2.focus();
                nid2.value = nid2.value + td.innerHTML;
            }
            else
            {
                if(nid3.value.length < 1)
                {
                    nid3.focus();
                    nid3.value = nid3.value + td.innerHTML;
                }
            }
        }
    }

    function deleteNumber()
    {
        var nid1 = document.getElementById('txtNID1');
        var nid2 = document.getElementById('txtNID2');
        var nid3 = document.getElementById('txtNID3');
        nid1.value = '';
        nid2.value = '';
        nid3.value = '';
    }
</script>

<body>
    <form id="form1" runat="server">
        <table width="819" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="103">
                    <img src="images/Hlogo-Left.jpg" width="103" height="159" /></td>
                <td width="196">
                    <img src="images/Hiran-flag.jpg" width="196" height="159" /></td>
                <td width="243">
                    <img src="images/Hazadi-Milad.jpg" width="243" height="159" /></td>
                <td colspan="2">
                    <img src="images/Hlogo-test.jpg" width="277" height="159" /></td>
            </tr>
            <tr>
                <td>
                    <img src="images/Bright-kadr.jpg" width="103" height="39" /></td>
                <td background="images/Bleft-kadr-bg.jpg">
                    &nbsp;</td>
                <td background="images/Bleft-kadr-bg.jpg">
                    &nbsp;</td>
                <td width="264" background="images/Bleft-kadr-bg.jpg">
                    <span class="style3">&#1662;&#1740;&#1711;&#1740;&#1585;&#1740; &#1608;&#1590;&#1593;&#1740;&#1578;
                        &#1589;&#1583;&#1608;&#1585; &#1705;&#1575;&#1585;&#1578; &#1588;&#1606;&#1575;&#1587;&#1575;&#1740;&#1740;
                        &#1605;&#1604;&#1740; </span>
                </td>
                <td width="13">
                    <img src="images/Bleft-kadr.jpg" width="13" height="39" /></td>
            </tr>
        </table>
        <table width="819" border="0" align="center" cellpadding="0" cellspacing="0" background="images/Body-bg.jpg">
            <tr>
                <td width="52">
                    &nbsp;</td>
                <td width="716" valign="top">
                    <p align="right" class="style20">
                        <br />
                        <span class="style21">&#1605;&#1578;&#1602;&#1575;&#1590;&#1740; &#1605;&#1581;&#1578;&#1585;&#1605;
                        </span>
                        <br />
                        &#1670;&#1606;&#1575;&#1606;&#1670;&#1607; &#1705;&#1575;&#1585;&#1578; &#1588;&#1606;&#1575;&#1587;&#1575;&#1740;&#1740;
                        &#1605;&#1604;&#1740; &#1588;&#1605;&#1575; &#1589;&#1575;&#1583;&#1585; &#1608;
                        &#1570;&#1605;&#1575;&#1583;&#1607; &#1578;&#1581;&#1608;&#1740;&#1604; &#1605;&#1740;
                        &#1576;&#1575;&#1588;&#1583; &#1548; &#1576;&#1585;&#1575;&#1740; &#1583;&#1585;&#1740;&#1575;&#1601;&#1578;
                        &#1570;&#1606; &#1576;&#1575; &#1583;&#1585;&#1583;&#1587;&#1578; &#1583;&#1575;&#1588;&#1578;&#1606;
                        &#1575;&#1589;&#1604; &#1588;&#1606;&#1575;&#1587;&#1606;&#1575;&#1605;&#1607; &#1608;
                        &#1585;&#1587;&#1740;&#1583; &#1583;&#1585;&#1582;&#1608;&#1575;&#1587;&#1578; &#1576;&#1607;
                        &#1575;&#1583;&#1575;&#1585;&#1607; &#1579;&#1576;&#1578; &#1575;&#1581;&#1608;&#1575;&#1604;
                        &#1605;&#1585;&#1576;&#1608;&#1591;&#1607; &#1605;&#1585;&#1575;&#1580;&#1593;&#1607;
                        &#1601;&#1585;&#1605;&#1575;&#1574;&#1740;&#1583;
                    </p>
                    <table width="762" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="182">
                            </td>
                            <td width="406" class="style3" dir="rtl">
                                شماره ملي خود را جهت پيگيري صدور کارت شناسايي ملي وارد کنيد
                            </td>
                            <td width="174">
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="3" align="center">
                                <table width="90">
                                    <tr>
                                        <td id=td0 runat="server" width="30" align="center" onclick="insert(this);" class="NumericPadButton">
                                        </td>
                                        <td id=td1 runat="server" width="30" align="center" onclick="insert(this);" class="NumericPadButton">
                                            
                                        </td>
                                        <td id=td2 runat="server" width="30" align="center" onclick="insert(this);" class="NumericPadButton">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id=td3 runat="server" width="30" align="center" onclick="insert(this);" class="NumericPadButton">
                                        </td>
                                        <td id=td4 runat="server" width="30" align="center" onclick="insert(this);" class="NumericPadButton">
                                        </td>
                                        <td id=td5 runat="server" width="30" align="center" onclick="insert(this);" class="NumericPadButton">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id=td6 runat="server" width="30" align="center" onclick="insert(this);" class="NumericPadButton">
                                        </td>
                                        <td id=td7 runat="server" width="30" align="center" onclick="insert(this);" class="NumericPadButton">
                                        </td>
                                        <td id=td8 runat="server" width="30" align="center" onclick="insert(this);" class="NumericPadButton">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id=td9 runat="server" width="30" align="center" onclick="insert(this);" class="NumericPadButton">
                                        </td>
                                        <td colspan="2" align="center" onclick="deleteNumber()" class="NumericPadButton">
                                            Del
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td dir="rtl" valign="middle">
                                <asp:TextBox ID="txtNID3" runat="server" MaxLength="1" Height="24px" Style="text-align: center;
                                    vertical-align: middle;" Width="10px" TabIndex="6" onkeyup="setFocus(this,3)"
                                    CssClass="txt_nrm" Font-Names="Tahoma" ValidationGroup="RealValidate" Font-Size="12pt"></asp:TextBox>
                                -
                                <asp:TextBox ID="txtNID2" runat="server" MaxLength="6" Height="24px" Style="text-align: center;
                                    vertical-align: middle;" Width="56px" TabIndex="5" onkeyup="setFocus(this,2)"
                                    CssClass="txt_nrm" Font-Names="Tahoma" ValidationGroup="RealValidate" Font-Size="12pt"></asp:TextBox>
                                -
                                <asp:TextBox ID="txtNID1" runat="server" MaxLength="3" Height="24px" Style="text-align: center;
                                    vertical-align: middle;" Width="29px" TabIndex="4" onkeyup="setFocus(this,1)"
                                    CssClass="txt_nrm" ValidationGroup="RealValidate" Font-Size="12pt"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNID1"
                                    ErrorMessage="شماره ملي را کامل وارد نماييد." Width="10px" ValidationGroup="RealValidate">*</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNID2" ErrorMessage="شماره ملي را کامل وارد نماييد."
                                        Width="10px" ValidationGroup="RealValidate">*</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNID3" ErrorMessage="شماره ملي را کامل وارد نماييد."
                                            Width="10px" ValidationGroup="RealValidate">*</asp:RequiredFieldValidator>
                                <asp:Button ID="btnSearch" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="اعلام وضعيت"
                                    ValidationGroup="RealValidate" OnClick="btnSearch_Click" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2" dir="rtl">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="540px" ValidationGroup="RealValidate">
                                </asp:ValidationSummary>
                                <asp:Label ID="lblDescription" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                    ForeColor="#0000C0"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <p align="right" class="style20">
                        &nbsp;</p>
                </td>
                <td width="51">
                    &nbsp;</td>
            </tr>
        </table>
        <table width="819" border="0" align="center" cellpadding="0" cellspacing="0" background="images/Body-bg.jpg">
            <tr>
                <td width="52" rowspan="2">
                    &nbsp;</td>
                <td width="714">
                    <div align="right">
                        <img src="images/soru.jpg" width="85" height="42" /></div>
                </td>
                <td width="53" rowspan="2" valign="bottom" class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <div align="right" class="style12">
                        <span class="style11">
                            <br />
                            &#1588;&#1605;&#1575;&#1585;&#1607; &#1605;&#1604;&#1740; &#1662;&#1583;&#1740;&#1583;&#1607;
                            &#1606;&#1608;&#1740;&#1606;&#1740; &#1575;&#1587;&#1578; &#1705;&#1607; &#1740;&#1705;&#1740;
                            &#1575;&#1586; &#1575;&#1576;&#1586;&#1575;&#1585;&#1607;&#1575;&#1740; &#1576;&#1587;&#1740;&#1575;&#1585;
                            &#1605;&#1607;&#1605; &#1588;&#1606;&#1575;&#1587;&#1575;&#1574;&#1740; &#1548;
                            &#1608; &#1575;&#1585;&#1575;&#1574;&#1607; &#1582;&#1583;&#1605;&#1575;&#1578;
                            &#1576;&#1607; &#1605;&#1585;&#1583;&#1605; &#1608; &#1602;&#1575;&#1576;&#1604;
                            &#1605;&#1576;&#1575;&#1583;&#1604;&#1607; &#1575;&#1591;&#1604;&#1575;&#1593;&#1575;&#1578;
                            &#1583;&#1585; &#1576;&#1740;&#1606; &#1705;&#1604;&#1740;&#1607; &#1583;&#1587;&#1578;&#1711;&#1575;&#1607;&#1607;&#1575;
                            &#1605;&#1740; &#1576;&#1575;&#1588;&#1583;&#1548; &#1575;&#1740;&#1606; &#1588;&#1605;&#1575;&#1585;&#1607;
                            &#1705;&#1604;&#1740;&#1583; &#1740;&#1705;&#1607; &#1575;&#1740; &#1575;&#1587;&#1578;
                            &#1705;&#1607; &#1575;&#1605;&#1705;&#1575;&#1606; &#1583;&#1587;&#1578;&#1585;&#1587;&#1740;
                            &#1576;&#1607; &#1575;&#1591;&#1604;&#1575;&#1593;&#1575;&#1578; &#1575;&#1601;&#1585;&#1575;&#1583;
                            &#1705;&#1588;&#1608;&#1585; &#1585;&#1575; &#1583;&#1585; &#1583;&#1587;&#1578;&#1711;&#1575;&#1607;&#1607;&#1575;&#1740;
                            &#1605;&#1582;&#1578;&#1604;&#1601; &#1601;&#1585;&#1575;&#1607;&#1605; &#1605;&#1740;
                            &#1606;&#1605;&#1575;</span>&#1740;&#1583;</div>
                </td>
            </tr>
        </table>
        <table width="819" border="0" align="center" cellpadding="0" cellspacing="0" background="images/Body-bg.jpg">
            <tr>
                <td width="103">
                    <img src="images/meliikart1.jpg" width="103" height="233" /></td>
                <td width="180">
                    <img src="images/meliikart2.jpg" width="180" height="233" /></td>
                <td width="525" background="images/bgbg.jpg">
                    <table width="484" height="233" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="484" height="148" valign="top">
                                <div align="right" class="style15">
                                    <p class="style22">
                                        &#1588;&#1605;&#1575;&#1585;&#1607; &#1605;&#1604;&#1740; &#1705;&#1604;&#1740;&#1607;
                                        &#1583;&#1587;&#1578;&#1585;&#1587;&#1740; &#1576;&#1607; &#1575;&#1591;&#1604;&#1575;&#1593;&#1575;&#1578;
                                        &#1575;&#1588;&#1582;&#1575;&#1589; &#1583;&#1585; &#1583;&#1608;&#1604;&#1578;
                                        &#1575;&#1604;&#1705;&#1578;&#1585;&#1608;&#1606;&#1740;&#1705; &#1605;&#1740; &#1576;&#1575;&#1588;&#1583;</p>
                                    <p class="style22">
                                        &#1576;&#1583;&#1608;&#1606; &#1583;&#1575;&#1588;&#1578;&#1606; &#1705;&#1575;&#1585;&#1578;
                                        &#1588;&#1606;&#1575;&#1587;&#1575;&#1740;&#1740; &#1605;&#1604;&#1740; &#1575;&#1585;&#1575;&#1574;&#1607;
                                        &#1607;&#1585;&#1711;&#1608;&#1606;&#1607; &#1582;&#1583;&#1605;&#1575;&#1578; &#1578;&#1608;&#1587;&#1591;
                                        &#1583;&#1587;&#1578;&#1711;&#1575;&#1607; &#1607;&#1575;&#1740; &#1583;&#1608;&#1604;&#1578;&#1740;
                                        &#1594;&#1740;&#1585; &#1605;&#1605;&#1705;&#1606; &#1605;&#1740; &#1576;&#1575;&#1588;&#1583;</p>
                                </div>
                                <p align="center" class="style3">
                                    &#1576;&#1606;&#1575;&#1576;&#1585;&#1575;&#1740;&#1606; &#1583;&#1585; &#1582;&#1601;&#1592;
                                    &#1608; &#1606;&#1711;&#1607;&#1583;&#1575;&#1585;&#1740; &#1705;&#1575;&#1585;&#1578;
                                    &#1588;&#1606;&#1575;&#1587;&#1575;&#1740;&#1740; &#1605;&#1604;&#1740; &#1582;&#1608;&#1583;
                                    &#1705;&#1608;&#1588;&#1575; &#1576;&#1575;&#1588;&#1740;&#1583;
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td height="54">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style24">
                                <div align="right">
                                    1387 - 1388 &#1605;&#1593;&#1575;&#1608;&#1606;&#1578; &#1570;&#1605;&#1575;&#1585;
                                    &#1608; &#1575;&#1606;&#1601;&#1608;&#1585;&#1605;&#1575;&#1578;&#1740;&#1705; &#1575;&#1583;&#1575;&#1585;&#1607;
                                    &#1705;&#1604; &#1579;&#1576;&#1578; &#1575;&#1581;&#1608;&#1575;&#1604; &#1575;&#1587;&#1578;&#1575;&#1606;
                                    &#1578;&#1607;&#1585;&#1575;&#1606;
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="11">
                    <img src="images/right.jpg" width="12" height="233" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
