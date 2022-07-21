<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateInstance.aspx.cs" Inherits="CreateInstance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CreateInstance</title>
    <link href="App_Themes/Default_Blue/XMain.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:CheckBoxList ID="chklCreateInstance" runat="server">
            <asp:ListItem>PNationalCard</asp:ListItem>
            <asp:ListItem>Security</asp:ListItem>
        </asp:CheckBoxList></div>
        <br />
        <asp:Button ID="btnCreateInstance" runat="server" Text="CreateInstance" Width="150px" OnClick="btnCreateInstance_Click" />
    </form>
</body>
</html>
