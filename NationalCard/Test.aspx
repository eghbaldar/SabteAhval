<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <script language=javascript type="text/javascript">
    function show(td)
    {
        debugger
        var txt = document.getElementById("TextBox1");
        txt.value = td.innerHTML;
    }
    </script>
        <div>
            <table width="90">
                <tr>
                    <td width="30" align="center" onclick="show(this);">
                        1
                    </td>
                    <td width="30" align="center">
                        <asp:Label runat=server ID="Label1" Text="2"></asp:Label>
                    </td>
                    <td width="30" align="center">
                        <asp:Label runat=server ID="Label2" Text="3"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30" align="center">
                        <asp:Label runat=server ID="Label3" Text="4"></asp:Label>
                    </td>
                    <td width="30" align="center">
                        <asp:Label runat=server ID="Label4" Text="5"></asp:Label>
                    </td>
                    <td width="30" align="center">
                        <asp:Label runat=server ID="Label5" Text="6"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="30" align="center">
                        <asp:Label runat=server ID="Label6" Text="7"></asp:Label>
                    </td>
                    <td width="30" align="center">
                        <asp:Label runat=server ID="Label7" Text="8"></asp:Label>
                    </td>
                    <td width="30" align="center">
                        <asp:Label runat=server ID="Label8" Text="9"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </form>
</body>
</html>
