<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebMensagens.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/logout.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="logout">

        <asp:Image ID="ImgUser" runat="server" />
        <asp:Label ID="Label1" runat="server" Text="Usuário:" Font-Bold="True" Font-Size="Large"></asp:Label>
        <asp:Label ID="lbNome" runat="server" Text="Nome do usuario:" Font-Size="Medium"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Email:" Font-Bold="True" Font-Size="Large"></asp:Label>
        <asp:Label ID="lbEmail" runat="server" Text="E-mail do usuario:"></asp:Label>

    </div>


</asp:Content>
