﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormPresentacion.aspx.cs" Inherits="WebGrafo.FormPresentacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-bs-theme="dark">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Grafo Web</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body style="background-color:#1A1C22">
    <form id="form1" runat="server">
        <div class="container text-center">
            <h1>Grafo en web</h1>
            
            Agregar Vertice
            <hr class="my-4"/>
            <div class="row g-3 mb-5">
                Nombre: 
                <div class="col">
                    <asp:TextBox ID="TextBox1" runat="server" Width="164px" CssClass="form-control"></asp:TextBox>
                </div>
                Edad: 
                <div class="col">
                    <asp:TextBox ID="TextBox2" runat="server" Width="44px" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:Button ID="Button1" runat="server" Text="Agregar vertice" CssClass="btn btn-outline-light" OnClick="Button1_Click" />
                </div>
            </div>
            <hr class="my-4"/>
            Conectar a:
            <hr class="my-4"/>
            <div class="row g-3 mb-5">
                Origen: 
                <div class="col">
                    <asp:TextBox ID="TextBox3" runat="server" Width="44px" CssClass="form-control"></asp:TextBox>
                </div>
                Destino: 
                <div class="col">
                    <asp:TextBox ID="TextBox4" runat="server" Width="44px" CssClass="form-control"></asp:TextBox>
                </div>
                Costo:
                <div class="col">
                    <asp:TextBox ID="TextBox5" runat="server" Width="44px" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
           
            <div class="row mb-5">
                <div class="col">
                    <asp:TextBox ID="TextBox6" runat="server" Width="350px" CssClass="form-control"></asp:TextBox>            
                </div>
                <div class="col">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="39px" Width="329px" CssClass="btn btn-dark">
                    </asp:DropDownList>
                </div>
                <div class="col">
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="btn btn-dark" Height="39px" Width="322px">
                    </asp:DropDownList>
                </div>      
            </div>
            <div class="row mb-5">
                 <div class="col">
                    <asp:Button ID="Button2" runat="server" Text="Agregar arista" CssClass="btn btn-outline-light" OnClick="Button2_Click" />
                </div> 
                <div class="col">
                    <asp:Button ID="Button3" runat="server" Text="Mostrar Aristas del vertice" CssClass="btn btn-outline-primary" OnClick="Button3_Click" />
                </div>
            </div>
            
            <div class="row mb-5">   
                <div class="col">
                    <asp:Button ID="Button4" runat="server" Text="Recorrer DFS" CssClass="btn btn-outline-warning" OnClick="Button4_Click" />
                </div>
                <div class="col">
                    <asp:Button ID="Button5" runat="server" Text="Recorrer BFS" CssClass="btn btn-outline-warning" OnClick="Button5_Click" />
                </div>
                <div class="col">
                    <asp:Button ID="Button6" runat="server" Text="Busqueda Topológica" CssClass="btn btn-outline-warning" OnClick="Button6_Click" />
                </div>
            </div>
            <hr class="my-4" />
            Recorridos y búsqueda
            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="btn btn-dark" Height="39px" Width="220px">
            </asp:DropDownList>
            
            <hr class="my-4"/>
            <canvas></canvas>
        </div>
    </form>
</body>
</html>
