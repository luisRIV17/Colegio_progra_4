<%@ Page Title="" Language="C#" MasterPageFile="~/Pmaster.Master" AutoEventWireup="true" CodeBehind="Pcurso.aspx.cs" Inherits="Parcial_2.Pcurso" %>
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
        .tx
        {
            border-radius:7px;
            width:70%;
        }
        .bt{
            border-radius:7px;
            color:white;
            background:#4f10ef;
            width:150px;
            height:50px;
        }
        .bt:hover{
            background:blue;
        }
        .grid{
            width:80%;
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
                <asp:Label ID="Label2" Font-Size="1.9em" runat="server" Text="Ingreso de Cursos" CssClass="titu"></asp:Label>
            </div>
        </div>
    </div>
     
    <div class="container cont">
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>
        <div class="row justify-content-center ro">
            <div class="col-sm-12 col-md-3 col-lg-3 text-lg-end text-md-end text-sm-start">
                <asp:Label ID="Label1" runat="server" Text="Codigo:" CssClass="lb"></asp:Label>
            </div>
            <div class="col-sm-12 col-md-6 col-lg-6 text-start  ">
                <asp:TextBox ID="txtcodigo" runat="server" CssClass="form-control tx "></asp:TextBox> 
            </div>
         </div>
         <div class="row justify-content-center ro">
             <div class="col-sm-12 col-md-3 col-lg-3 text-lg-end text-md-end text-sm-start">
                 <asp:Label ID="Label7" runat="server" Text="Nombre:" CssClass="lb"></asp:Label>
             </div>
             <div class="col-sm-12 col-md-6 col-lg-6 text-start ">
                 <asp:TextBox ID="txtnombre" runat="server" CssClass="form-control tx "></asp:TextBox>
             </div>
         </div>
        
         </ContentTemplate> 
             </asp:UpdatePanel>
         
        <div class="row justify-content-center ro">
             <div class="col-sm-12 col-md-12 col-lg-12 text-center">
                  <asp:Button ID="Button1" runat="server" Text="Guardar" CssClass="bt" OnClick="Button1_Click" />
                  <asp:Button ID="bteliminar" runat="server" Enabled="False"  OnClientClick="return confirm('Desea Eliminar este Usuario?')" Text="Eliminar" CssClass="bt" OnClick="bteliminar_Click" />
             </div>
             <div class="col-sm-12 col-md-12 col-lg-12 text-center">
                 <asp:Label ID="lbresult" ForeColor="#990000" runat="server" Text=""></asp:Label>
             </div>
         </div>
        
        
           
        <div class="row justify-content-center mar ro">
            <div class="col-sm-12 col-md-12 col-lg-12 grid ">
                <asp:GridView ID="GridView1" CssClass="table table-dark table-responsive" Font-Size="0.9em"  HeaderStyle-ForeColor ="Black" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>
            </div>
        </div>
             
    </div>
</asp:Content>
