using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassBLL;
using ClassEntidades;

namespace WebGrafo
{
    public partial class FormPresentacion : System.Web.UI.Page
    {
        ClassBL objBL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objBL = new ClassBL();
                Session["objBL"] = objBL;
            }
            else
            {
                objBL = (ClassBL)Session["objBL"];
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Entidad objEntidad = new Entidad()
                {
                    Nombre = TextBox1.Text,
                    Edad = int.Parse(TextBox2.Text)
                };
                TextBox6.Text = objBL.AgregarVerticeBL(objEntidad);
            }
            catch (Exception ex)
            {
                TextBox6.Text = $"{ex.Message}";
            }
            TextBox1.Text = "";
            TextBox2.Text = "";
            MostrarGrafo();

            string[] arrayTemp = objBL.MostrarVerticesBL();
            DropDownList1.Items.Clear();
            DropDownList4.Items.Clear();
            DropDownList5.Items.Clear();

            foreach (string cadena in arrayTemp)
            {
                DropDownList1.Items.Add(cadena);
                DropDownList4.Items.Add(cadena);
                DropDownList5.Items.Add(cadena);
            };
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int origen = -5;
            int destino = -5;

            if (DropDownList4.SelectedIndex != -1 || DropDownList5.SelectedIndex != -1)
            {
                origen = DropDownList4.SelectedIndex;
                destino = DropDownList5.SelectedIndex;
                float costo = float.Parse(TextBox5.Text);

                TextBox6.Text = objBL.AgregarAristaBL(origen, destino, costo);
                TextBox5.Text = "";
                MostrarGrafo();
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            List<string> listTemp;
            int Pos_vertice = -5;
            string msj = "";

            if (DropDownList1.SelectedIndex != -1)
            {
                Pos_vertice = DropDownList1.SelectedIndex;
                listTemp = objBL.MostrarVerticesAristas(Pos_vertice, ref msj);

                DropDownList2.Items.Clear();

                foreach (string cadena in listTemp)
                {
                    DropDownList2.Items.Add(cadena);
                };
                TextBox6.Text = msj;
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            List<string> temp;
            int vertice = -5;

            if (DropDownList1.SelectedIndex != -1)
            {
                DropDownList3.Items.Clear();
                vertice = DropDownList1.SelectedIndex;
                temp = objBL.RecorrerDFS_BL(vertice);

                foreach (string cad in temp)
                {
                    DropDownList3.Items.Add(cad);
                }
            }
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            List<string> temp;
            int vertice = -5;

            if (DropDownList1.SelectedIndex != -1)
            {
                DropDownList3.Items.Clear();
                vertice = DropDownList1.SelectedIndex;
                temp = objBL.RecorrerBFS_BL(vertice);

                foreach (string cad in temp)
                {
                    DropDownList3.Items.Add(cad);
                }
            }
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            List<string> temp;
            int vertice = -5;

            if (DropDownList1.SelectedIndex != -1)
            {
                DropDownList3.Items.Clear();
                vertice = DropDownList1.SelectedIndex;
                temp = objBL.BusquedaTopologicaVerticeBL(vertice);

                foreach (string cad in temp)
                {
                    DropDownList3.Items.Add(cad);
                }
            }
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            int vertice = -5;
            string msj = "";

            if (DropDownList1.SelectedIndex != -1)
            {
                DropDownList3.Items.Clear();
                vertice = DropDownList1.SelectedIndex;
                string[] salida = objBL.Djikstra(vertice, ref msj);

                foreach (string cad in salida)
                {
                    DropDownList3.Items.Add(cad);
                }
                TextBox6.Text = msj;
            }
        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            int origen = -5;
            int destino = -5;

            if (DropDownList4.SelectedIndex != -1 || DropDownList5.SelectedIndex != -1)
            {
                DropDownList3.Items.Clear();
                origen = DropDownList4.SelectedIndex;
                destino = DropDownList5.SelectedIndex;
                List<string> ListaTemp = objBL.BusquedaTopologicaAristaBL(origen, destino);

                foreach (string Elemento in ListaTemp)
                {
                    DropDownList3.Items.Add(Elemento);
                }
            }
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            MostrarGrafo();
        }
        private void MostrarGrafo()
        {
            string jsonGrafo = objBL.SerializarGrafo();
            ClientScript.RegisterStartupScript(this.GetType(), "dibujarGrafo", $"dibujarGrafo('{jsonGrafo}');", true);
        }
    }
}