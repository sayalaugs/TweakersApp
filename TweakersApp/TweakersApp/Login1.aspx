<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="TweakersApp.Login1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label3" runat="server" Text="Inloggen" Font-Bold="True"></asp:Label>
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
                    <asp:Label ID="lblMessageLogin" runat="server" Text="..."></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    <br />

     <asp:Label ID="Label4" runat="server" Text="Registreren" Font-Bold="True"></asp:Label>
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
                <asp:Label ID="lblMessageRegister" runat="server" Text="..."></asp:Label>
            </td>
        </tr>
    </table>
    </form>
    </asp:Content>