<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormPresentacion.aspx.cs" Inherits="WebGrafo.FormPresentacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-bs-theme="dark">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Grafo Web</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="GraficarGrafoJS/Circulo.js"></script>
    <script src="GraficarGrafoJS/Trigonometria.js"></script>
    <script src="GraficarGrafoJS/dibujarGrafo.js"></script>
</head>
<body style="background-color:#1A1C22">
    <form id="form1" runat="server">
        <div class="container text-center">
            <h1>Grafo en web</h1>
            <div class="container text-center">
                <h3>Agregar Vertice</h3>
                <hr class="my-4" />
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
            </div>

            <div class="container text-center">
                <h3>Conectar a:</h3>
                <hr class="my-4" />
                <div class="row g-3 mb-5">
                    Origen: 
                <div class="col">
                    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="btn btn-dark"></asp:DropDownList>
                </div>
                    Destino: 
                <div class="col">
                    <asp:DropDownList ID="DropDownList5" runat="server" CssClass="btn btn-dark"></asp:DropDownList>
                </div>
                    Costo:
                <div class="col">
                    <asp:TextBox ID="TextBox5" runat="server" Width="44px" CssClass="form-control"></asp:TextBox>
                </div>
                    <div class="col">
                        <asp:Button ID="Button2" runat="server" Text="Agregar arista" CssClass="btn btn-outline-light" OnClick="Button2_Click" />
                    </div>
                </div>
            </div>

            <div class="row g-3 mb-5">
                <div class="col">
                    <asp:TextBox ID="TextBox6" runat="server" Width="400px" ReadOnly="true" CssClass="alert alert-primary"></asp:TextBox>
                </div>
            </div>

            <div class="container text-center">
                <div class="row g-3 mb-5">
                    Vértices:
                    <div class="col">
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="39px" Width="329px" CssClass="btn btn-dark">
                        </asp:DropDownList>
                    </div>
                    Aristas del Vértice:
                    <div class="col">
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="btn btn-dark" Height="39px" Width="322px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row mb-5">
                    <div class="col align-self-center">
                        <asp:Button ID="Button3" runat="server" Text="Mostrar Aristas del vertice" CssClass="btn btn-outline-primary" OnClick="Button3_Click" />
                    </div>
                </div>
            </div>

            <h3>Recorridos y búsqueda</h3>
            <hr class="my-4" />
            <div class="row mb-5">
                <div class="col align-self-center">
                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="btn btn-dark" Height="39px" Width="220px">
                    </asp:DropDownList>
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
                <div class="col">
                    <asp:Button ID="Button8" runat="server" Text="Buscar aristas" CssClass="btn btn-outline-warning" OnClick="Button8_Click" />
                </div>
                <div class="col">
                    <asp:Button ID="Button7" runat="server" Text="Encontrar camino más corto" CssClass="btn btn-outline-warning" OnClick="Button7_Click" />
                </div>
            </div>

            <hr class="my-4" />
            <div class="row">
                <div class="col align-self-center">
                    <canvas id="Canvas1" width="1000" height="1000" style="border: 2px ridge #317A86"></canvas>
                </div>
            </div>
            <div class="row">
                <div class="col align-self-center">
                    <asp:Button ID="Button9" runat="server" Text="Mostrar Grafo" CssClass="btn btn-outline-warning" OnClick="Button9_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
