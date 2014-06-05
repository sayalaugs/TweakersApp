<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="TweakersApp.Login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 32%;
        }
        .style2
        {
            width: 117px;
        }
        .style3
        {
            width: 61%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" Text="Gebruikersnaam:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbUsername" runat="server">123</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" Text="Wachtwoord:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbPassword" runat="server">123</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" Text="Login" />
                </td>
            </tr>
        </table>
    
    </div>
    <table class="style3">
        <tr>
            <td class="style2">
                Gebruikersnaam:</td>
            <td>
                <asp:TextBox ID="tbRegUserLogin" runat="server">234</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Wachtwoord:</td>
            <td>
                <asp:TextBox ID="tbRegUserPassword" runat="server">234</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Naam:</td>
            <td>
                <asp:TextBox ID="tbRegName" runat="server">Aap</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Geboortedatum:</td>
            <td>
                <asp:Calendar ID="calRegBirthday" runat="server" Height="74px" Width="46px">
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Email:</td>
            <td>
                <asp:TextBox ID="tbRegEmail" runat="server" Width="358px">aap@hotmail.com</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Geslacht:</td>
            <td>
                <asp:DropDownList ID="ddlRegGender" runat="server">
                    <asp:ListItem>M</asp:ListItem>
                    <asp:ListItem>V</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Type:</td>
            <td>
                <asp:DropDownList ID="ddlRegType" runat="server">
                    <asp:ListItem>Normaal</asp:ListItem>
                    <asp:ListItem>Auteur</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnRegister" runat="server" onclick="btnRegister_Click" 
                    Text="Registreer" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
