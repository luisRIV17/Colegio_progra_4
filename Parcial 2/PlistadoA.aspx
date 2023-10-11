<%@ Page Title="" Language="C#" MasterPageFile="~/Ppmaster.Master" AutoEventWireup="true" CodeBehind="PlistadoA.aspx.cs" Inherits="Parcial_2.PlistadoA" %>
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
        .drop{
            border-radius:7px;
            width:65%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div class="container marg" style="width:70%">
        <div class="row justify-content-center ro">
            <div class="col-sm-12 col-md-3 col-lg-12  text-start">
                <asp:Label ID="Label2" Font-Size="1.9em" runat="server" Text="Asignacion de Notas" CssClass="titu"></asp:Label>
            </div>
        </div>
    </div>
     <div class="container cont">
         <div class="row justify-content-center ro">
            <div class="col-sm-12 col-md-3 col-lg-4 text-lg-end text-md-end text-sm-start">
                 <asp:Label ID="Label6" runat="server" Text="Seleccione el Curso:" CssClass="lb"></asp:Label>
             </div>
             <div class="col-sm-12 col-md-6 col-lg-6 text-start ">
                 <asp:DropDownList ID="dropcurso" CssClass="drop drop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropdepa_SelectedIndexChanged"></asp:DropDownList>
             </div>
         </div>
         <div class="row justify-content-center ro">
         <div class="col-sm-12 col-md-12 col-lg-12 text-center">
                 <asp:Label ID="lbresult" ForeColor="#990000" runat="server" Text="a"></asp:Label>
             </div>
         </div>
           <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>
        <div class="row justify-content-center mar ro">
          
            <div class="col-sm-12 col-md-12 col-lg-12 grid ">
                <asp:GridView ID="GridView1" CssClass="table table-dark table-responsive" Font-Size="0.9em"  HeaderStyle-ForeColor ="Black" runat="server" AutoGenerateColumns="False"  >
                    <Columns>
                        <asp:TemplateField HeaderText="Codigo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Codigo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbcod" runat="server" Text='<%# Bind("Codigo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Curso">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Curso") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Curso") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Alumno">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Alumno") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Alumno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Zona">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4"  runat="server" Text='<%# Bind("Zona") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtzona" runat="server" AutoPostBack="True" OnTextChanged="txtzona_TextChanged" Text='<%# Bind("Zona") %>' TextMode="Number"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Final">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Final") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtfinal" runat="server"  AutoPostBack="True" OnTextChanged="txtzona_TextChanged" Text='<%# Bind("Final") %>' TextMode="Number"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Total") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Resultado">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Resultado") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("Resultado") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delegado">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Delegado") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="checkdele" runat="server" Checked='<%# Bind("Delegado") %>' AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
<HeaderStyle ForeColor="Black"></HeaderStyle>
                </asp:GridView>
            </div>
             
        </div>
     <div class="row justify-content-center ro">
         <div class=" col-6 col-sm-6 col-md-6 col-lg-6  text-center">
             <asp:Button ID="btdele" Width="40%" CssClass="btn btn-dark" runat="server" Text="Editar Delegado" OnClick="btdele_Click" Visible="False" />
             </div>
         </div>
      </ContentTemplate> 
             </asp:UpdatePanel>
     </div>
</asp:Content>
