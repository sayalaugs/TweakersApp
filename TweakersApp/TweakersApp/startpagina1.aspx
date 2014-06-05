<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="startpagina1.aspx.cs" Inherits="TweakersApp.startpagina1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 48%;
        }
        .style2
        {
            width: 101px;
        }
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 101px;
            height: 31px;
        }
        .style5
        {
            height: 31px;
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
        .style8
        {
            width: 109px;
        }
        .style9
        {
            width: 109px;
            height: 300px;
        }
        .style10
        {
            height: 300px;
        }
        .style11
        {
            width: 109px;
            height: 26px;
        }
        .style12
        {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label7" runat="server" Text="Product Toevoegen:"></asp:Label>
    
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
                </td>
            </tr>
        </table>
    
    </div>
    <br />
    <asp:Label ID="lblArtikel" runat="server" Text="Artikel plaatsen" 
        Visible="False"></asp:Label>
    <asp:Panel ID="pnlArtikelPlaatsen" runat="server" Visible="False">
        <table class="style3">
            <tr>
                <td class="style2">
                    <asp:Label ID="Label4" runat="server" Text="Titel:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbArticleTitel" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4" valign="top">
                    Selecteer product:</td>
                <td class="style5" valign="top">
                    <asp:DropDownList ID="ddlArtikelProducts" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style6" valign="top">
                    <asp:Label ID="Label6" runat="server" Text="Inhoud artikel:"></asp:Label>
                </td>
                <td class="style7" valign="top">
                    <asp:TextBox ID="tbArticleText" runat="server" Height="238px" 
                    Width="766px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2" valign="top">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnPlaceArticle" runat="server" Text="Plaats artikel" 
                    onclick="btnPlaceArticle_Click" />
                    &nbsp;<asp:Label ID="lblMessage" runat="server" Text="..."></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <p>
        <asp:Label ID="Label11" runat="server" Text="Review plaatsen"></asp:Label>
    </p>
    <table class="style3">
        <tr>
            <td class="style11">
                <asp:Label ID="Label8" runat="server" Text="Titel:"></asp:Label>
            </td>
            <td class="style12">
                <asp:TextBox ID="tbReviewTitel" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style8">
                Product:</td>
            <td>
                    <asp:DropDownList ID="ddlReviewProducts" runat="server">
                    </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td class="style9" valign="top">
                <asp:Label ID="Label9" runat="server" Text="Text:"></asp:Label>
            </td>
            <td class="style10" valign="top">
                <asp:TextBox ID="tbReviewText" runat="server" Height="296px" TextMode="MultiLine" 
                    Width="767px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="Label10" runat="server" Text="Rating"></asp:Label>
            </td>
            <td>
                <asp:RadioButton ID="rbOne" GroupName="rating"   runat="server" Text="1            " />
                <asp:RadioButton ID="rbTwo" GroupName="rating"  runat="server" Text="2            " />
                <asp:RadioButton ID="rbThree" GroupName="rating"  runat="server" Text="3                        " />
                <asp:RadioButton ID="rbFour" GroupName="rating"  runat="server" Text="4            " />
                <asp:RadioButton ID="rbFive" GroupName="rating"  runat="server" Text="5" />
            </td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnReview" runat="server" onclick="btnReview_Click" 
                    Text="Plaats Review" />
            </td>
        </tr>
        </table>
    <asp:GridView ID="gvComments" runat="server">
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
