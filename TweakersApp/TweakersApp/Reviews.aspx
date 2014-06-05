<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="TweakersApp.Reviews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:Label ID="lblInlogtext" runat="server" Font-Bold="True" 
            Text="Ingelogd als:"></asp:Label>
    <asp:Label ID="lblUser" runat="server" Text="..."></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnAddReview" runat="server" Text="Review toevoegen" />
&nbsp;&nbsp;
        <asp:Button ID="btnAddArticle" runat="server" Text="Artikel toevoegen" 
            onclick="btnAddArticle_Click1" />
&nbsp;&nbsp;
        <asp:Button ID="btnAddProduct" runat="server" Text="Product toevoegen" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Artikels"></asp:Label>
    <br />
    <asp:GridView ID="gvArticles" runat="server" onrowcommand="gvArticles_RowCommand">
        <Columns>
            <asp:ButtonField Text="Button" CommandName="GetArtID"/>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <br />
    </form>
</asp:Content>
