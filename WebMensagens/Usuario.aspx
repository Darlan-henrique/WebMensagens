<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="WebMensagens.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="Panel1" runat="server" GroupingText="Cadastro/Alteração de usuários">
        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
        <br />
        <asp:TextBox ID="txtId" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nome do usuário"></asp:Label>
        <br />
        <asp:TextBox ID="txtNome" runat="server" Width="543px"></asp:TextBox>
        <br />
          <asp:Label ID="Label3" runat="server" Text="E-mail"></asp:Label>
        <br />
        <asp:TextBox ID="txtEmail" runat="server" Width="543px"></asp:TextBox>
        <br />
          <asp:Label ID="Label4" runat="server" Text="Senha"></asp:Label>
        <br />
        <asp:TextBox ID="txtSenha" runat="server" Width="543px" TextMode="Password"></asp:TextBox>
         <br />
        <br />
        <asp:Button ID="btInserir" runat="server" Text="Inserir" OnClick="btInserir_Click"/>
        <asp:Button ID="btCancelar" runat="server" CausesValidation="False" Text="Cancelar" OnClick="btCancelar_Click"/>
        <br />
    </asp:Panel>
     <asp:Panel ID="Panel2" runat="server" GroupingText="Registros dos usuários ">
     <asp:GridView ID="gvDados" runat="server" AutoGenerateColumns="False" Width="563px" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="gvDados_RowDeleting" OnSelectedIndexChanged="gvDados_SelectedIndexChanged" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="id" HeaderText="Id" />
                <asp:BoundField DataField="nome" HeaderText="Nome" />
                <asp:BoundField DataField="email" HeaderText="E-mail" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
             </asp:Panel>
</asp:Content>
