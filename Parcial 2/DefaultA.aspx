<%@ Page Title="" Language="C#" MasterPageFile="~/Pamaster.Master" AutoEventWireup="true" CodeBehind="DefaultA.aspx.cs" Inherits="Parcial_2.DefaultA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        .cont{
            padding-top:20px;
            background:#434faa;
            font-family:'Century Gothic';
            font-size:1.4em;
            width:70%;
            border-radius:10px;
        }
        .ro{
            padding-bottom:15px;
        }
        .mar{
            margin-left:25px;
             margin-right:25px;
        }
        .lb
        {
            color:#ffffff;
        }
        .titu{
            font-weight:bold;
            color:#212529;
            -webkit-text-stroke: 1px #fff;
        }
      .marg{
            padding-top:350px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container marg" style="width:70%">
        <div class="row justify-content-center ro">
            <div class="col-sm-12 col-md-12 col-lg-12  text-center">
                <asp:Label ID="Label2" Font-Size="2.8em" runat="server" Text="Pagina de Inicio Alumno" CssClass="titu"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
