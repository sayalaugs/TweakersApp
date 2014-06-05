<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleInfo.aspx.cs" Inherits="TweakersApp.ArticleInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
<p>
    <asp:Label ID="lblArtTitel" runat="server" Font-Bold="True" Text="Titel"></asp:Label>
</p>
<p>
    <asp:TextBox ID="tbArtText" runat="server" Height="240px" Width="795px" 
        TextMode="MultiLine"></asp:TextBox>
</p>
<p>
    &nbsp;</p>
<p>
    <asp:GridView ID="gvComments" runat="server" Width="603px" onrowcommand="gvComments_RowCommand">
        <Columns>
            <asp:ButtonField CommandName="Like" Text="Like" />
            <asp:ButtonField CommandName="Dislike" Text="Dislike" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</p>
<p>
    <asp:Label ID="lblMessage" runat="server" 
        Text="U moet ingelogd zijn om een reactie te plaatsen." Visible="False"></asp:Label>
</p>
<p>
    <asp:TextBox ID="tbArtComment" runat="server" Height="84px" Width="327px"></asp:TextBox>
    <asp:Button ID="btnAddComment" runat="server" onclick="btnAddComment_Click" 
        Text="Plaats reactie" />
</p>
<p>
    &nbsp;</p>
</form>
</asp:Content>
