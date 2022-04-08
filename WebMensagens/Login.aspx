<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebMensagens.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

      <!-- Meta tags Obrigatórias -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"/>
    <title></title>
     <link rel="stylesheet" href="CSS/LoginCss.css"/>
</head>
   
<body>
    <form id="form1" runat="server">
       <div class="login">
   
                <asp:Label ID="Label1" runat="server" Text="Login" class="form-label" Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="txbLogin" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Senha" Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="txbSenha" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btlogar"  runat="server" Text="Logar" class="btn btn-primary" OnClick="btlogar_Click"/>
                 <br />
            <br />
           <p>Login: admin@admin.com.br</p>
           <p>Senha:123</p>
        </div>
    </form>


</body>
</html>
