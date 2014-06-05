<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddReview.aspx.cs" Inherits="TweakersApp.AddReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style3
        {
            width: 100%;
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
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Review plaatsen:" Font-Bold="True"></asp:Label>
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
    </form>
</asp:Content>
