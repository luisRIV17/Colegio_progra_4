<%@ Page Title="" Language="C#" MasterPageFile="~/Pamaster.Master" AutoEventWireup="true" CodeBehind="PnotasA.aspx.cs" Inherits="Parcial_2.PnotasA" %>
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

        .grid{

            padding:0px;
             overflow:auto;
            display: grid;
            grid-gap:10px;
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
            padding-top:150px;
        }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <div class="container marg" style="width:70%">
        <div class="row justify-content-center ro">
            <div class="col-sm-12 col-md-3 col-lg-12  text-start">
                <asp:Label ID="Label2" Font-Size="1.9em" runat="server" Text="Listado de Cursos" CssClass="titu"></asp:Label>
            </div>
        </div>
    </div>
     <div class="container cont">
         <div class="row justify-content-center ro">
         <div class="col-sm-12 col-md-12 col-lg-12 text-center">
                 <asp:Label ID="lbresult" ForeColor="#990000" runat="server" Text=""></asp:Label>
             </div>
         </div>
        <div class="row justify-content-center mar ro">
            <div class="col-sm-12 col-md-12 col-lg-12 grid ">
                <asp:GridView ID="GridView1" CssClass="table table-dark table-responsive" Font-Size="0.9em"  HeaderStyle-ForeColor ="Black" runat="server"  ></asp:GridView>
            </div>
        </div>
     </div>
        
      
</asp:Content>
