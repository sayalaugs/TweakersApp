<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TweakersApp.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="lblInlogtext" runat="server" Font-Bold="True" 
            Text="Ingelogd als:"></asp:Label>

        <asp:Label ID="lblUser" runat="server" Text="..."></asp:Label>

        <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Artikels"></asp:Label>
    <br />
    <asp:GridView ID="gvArticles" runat="server">
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <br />
    </form>
</asp:Content>
