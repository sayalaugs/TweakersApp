<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddArticle.aspx.cs" Inherits="TweakersApp.AddArticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style3
        {
            width: 100%;
        }
        .style2
        {
            width: 101px;
        }
        .style6
        {
            width: 101px;
            height: 230px;
        }
        .style7
        {
            height: 230px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
     <asp:Label ID="Label1" runat="server" Text="Artikel plaatsen:" Font-Bold="True"></asp:Label>
    <table class="style3" __designer:mapid="28">
        <tr __designer:mapid="29">
            <td class="style2" __designer:mapid="2a">
                <asp:Label ID="Label4" runat="server" Text="Titel:"></asp:Label>
            </td>
            <td __designer:mapid="2c">
                <asp:TextBox ID="tbArticleTitel" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr __designer:mapid="32">
            <td class="style6" valign="top" __designer:mapid="33">
                <asp:Label ID="Label6" runat="server" Text="Inhoud artikel:"></asp:Label>
            </td>
            <td class="style7" valign="top" __designer:mapid="35">
                <asp:TextBox ID="tbArticleText" runat="server" Height="238px" 
                    Width="766px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr __designer:mapid="37">
            <td class="style2" valign="top" __designer:mapid="38">
                    &nbsp;</td>
            <td __designer:mapid="39">
                <asp:Button ID="btnPlaceArticle" runat="server" Text="Plaats artikel" 
                    onclick="btnPlaceArticle_Click" />
                    &nbsp;<asp:Label ID="lblMessage" runat="server" Text="..."></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</asp:Content>
