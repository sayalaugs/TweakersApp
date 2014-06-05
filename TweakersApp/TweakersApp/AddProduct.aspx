<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="TweakersApp.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style1
        {
            width: 48%;
        }
        .style2
        {
            width: 101px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:Label ID="Label4" runat="server" Text="Product toevoegen:" 
        Font-Bold="True"></asp:Label>
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="Naam:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbProductNaam" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Prijs:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbProductPrice" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" valign="top">
                <asp:Label ID="Label3" runat="server" Text="Release date:"></asp:Label>
            </td>
            <td>
                <asp:Calendar ID="CalReleaseDate" runat="server" Height="16px" Width="54px">
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="style2">
                    &nbsp;</td>
            <td>
                <asp:Button ID="btnAddProduct" runat="server" onclick="btnAddProduct_Click" 
                        Text="Toevoegen" />
                <asp:Label ID="lblMessage" runat="server" Text="..."></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</asp:Content>
