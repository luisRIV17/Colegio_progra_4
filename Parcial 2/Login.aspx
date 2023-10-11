<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Parcial_2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
     <style type="text/css">
         .cuerpo{
              margin:0;
              padding:0;
              background:url(Imagenes/1.jpg) no-repeat   center top;
              background-size:cover;
              font-family:sans-serif;
              height:100vh;/*tamaño de la imagen, view height*/
          }
         
          .divlog
          {
              width:320px;
              height:420px;
              background:#434faa;
              color:#fff;
              top:50%;
              left:50%;
              position:absolute;
              transform:translate(-50%,-50%);
              box-sizing:border-box;
              padding:70px 30px;
              border-radius:10px;
          }
          .logo
          {
              width:100px;
              height:100px;
              border-radius:50%;
              position:absolute;
              top:-50px;
              left:35%;

            
          }
          .titulo{
               margin:0;
              padding:0 0 20px;
              text-align:center;
              font-size:22px;
          }
          .enu{
              margin-top:25px;
              padding:0;
              font-weight:bold; /*remarcar*/
              display:block;
          }
          .boton{
              width:100%;
              height:40px;
               border:none;
               outline:none;
              
              margin-top:40px;
              background:#4f10ef;
              color:white;
              font-size:18px;
              border-radius:15px;
              cursor:pointer;
             
          }
          .boton:hover{
            background-color:blue;
        }
          .entradas{
              border:none;
               width:100%;
              border-bottom:5px solid white;
              background:transparent;
              outline:none;
              height:40px;
              color:#fff;
              font-size:16px;
          }
           .enu2{
              margin-top:15px;
              padding:0;
              font-weight:bold; /*remarcar*/
              display:block;
              color:#fb3030;
          }
          </style>
</head>
<body class="cuerpo">
    
        <div class="divlog">
          <img class="logo" src="Imagenes/books-icon.png" alt="logo" />
            <h1 class="titulo">Inicio de Sesion</h1>
            <form  runat="server">
               <label class="enu" for="Usuario">Usuario</label>
                <asp:TextBox ID="txt1" runat="server" class="entradas" type="text" placeholder="Ingrese Usuario" />

                <label class="enu" for="Contraseña">Contraseña</label>
                <asp:TextBox ID="txt2" runat="server" class="entradas" type="password" placeholder="Ingrese Contraseña" />
               
                <asp:Button ID="Button1" runat="server" class="boton"  Text="Ingresar" OnClick="Button11_Click" />
                <asp:Label ID="lbresult" CssClass="enu2" runat="server" Text=""></asp:Label>
                   
            </form>
        </div>
   
</body>
</html>
