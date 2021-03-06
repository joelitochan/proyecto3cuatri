﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BO;
using DAO;
using Services;
using AdministradorGUI;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace AdministradorGUI
{
    public partial class admi_de_eventosGUI : System.Web.UI.Page
    {
        
        ctrol_dirrecionSERVICIOS ser_direccion = new ctrol_dirrecionSERVICIOS();
        ctrol_eventosSERVICIO control = new ctrol_eventosSERVICIO();
        eventoDAO eventado = new eventoDAO();
        direccionDAO obj = new direccionDAO();
        loginDAO login = new loginDAO();
        int fila;
        string strNuevoNombre = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                ddl_categoria.DataSource = eventado.buscar_categoria().Tables[0];
                ddl_categoria.DataTextField = "NOMBRE";
                ddl_categoria.DataValueField = "CODIGO";
                ddl_categoria.DataBind();
                ddl_municipio.DataSource = eventado.buscar_municipio().Tables[0];
                ddl_municipio.DataTextField = "NOMBRE";
                ddl_municipio.DataValueField = "CODIGO";
                ddl_municipio.DataBind();
                refrescar();

                //este cambia los emcabezados del tabla
                dgb_eventos.HeaderRow.Cells[3].Text = "Nombre Del Evento";
                dgb_eventos.HeaderRow.Cells[2].Text = "Descripción";
                dgb_eventos.HeaderRow.Cells[24].Text = "Nombre Del Usuario";
                dgb_eventos.HeaderRow.Cells[25].Text = "Apellido Del Usuario";
                dgb_eventos.HeaderRow.Cells[26].Text = "Teléfono";
                dgb_eventos.HeaderRow.Cells[28].Text = "Correo";
                dgb_eventos.HeaderRow.Cells[29].Text = "Alias del Usuario";

            }


           
            }  
    
        public void usuario()
        {
            try
            {
                
              
                DataRow row = obj.buscar().Tables[0].Rows[fila];
                txt_usuario.Text = Convert.ToString(row[0]);
                txt_usuario.DataBind();
            }
            catch
            {

            }
                
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {

        }

        protected void txt_codir_ValueChanged(object sender, EventArgs e)
        {

        }
      
        public EventoBO devolver()
        {
            EventoBO obj = new EventoBO();
           
            int id = 0; int.TryParse(txtid.Value, out id);
            
            obj.Codigo = id;
            obj.Descripcion =txt_descrip.Text;
            obj.Nombre = txt_nombre.Text;
            obj.costo = Convert.ToDouble(txt_precio.Text);
           obj.FechaApertura = Convert.ToDateTime(txt_aperura.Text);
            obj.FechaCierre = Convert.ToDateTime(txt_fecha_cierre.Text);
            obj.FotoPromocion = strNuevoNombre;
            obj.UbicacionGeografica = txt_ubicar.Text;
            obj.longitud = txt_lo.Text;
            obj.latitud = txtlat.Text;
            obj.visitas = 0;
            obj.aprovacion = Convert.ToString(0);
            //obj.CodigoDireccion = Convert.ToInt32(iddir.ToString());
            obj.CodigoCategoria = Convert.ToInt32(ddl_categoria.SelectedValue);
            obj.CodigoUsuario =Convert.ToInt32( txt_usuario.Text);
            //
            obj.aprovacion = (rbt_noapro.Checked) ? "0" : "1";
            int iddir = 0; int.TryParse(txt_codir.Value, out iddir);
            obj.Codigo_dir = iddir;
            obj.Colonia = txt_colonia.Text;
            obj.CodigoPostal = txt_postal.Text;
            obj.Cruzamiento = txt_crizamiento.Text;
            obj.NumeroExterior = txt_numexter.Text;
            obj.NumeroInterior = txt_numint.Text;
            obj.CodigoMunicipio = Convert.ToInt32(ddl_municipio.SelectedValue);
            //

            return obj;



        }
        public Direccion mandar()
        {
            Direccion dir = new Direccion();

           
            int iddir = 0; int.TryParse(txt_codir.Value, out iddir);
            dir.Codigo = iddir;
            dir.Colonia = txt_colonia.Text;
            dir.CodigoPostal = txt_postal.Text;
            dir.Cruzamiento = txt_crizamiento.Text;
            dir.NumeroExterior = txt_numexter.Text;
            dir.NumeroInterior = txt_numint.Text;
            dir.CodigoMunicipio = Convert.ToInt32(ddl_municipio.SelectedValue);

           
         
            return dir;



        }
        public void refrescar()
        {

            dgb_eventos.DataSource= eventado.buscar();
            dgb_eventos.DataBind();
           
        }

        protected void dgb_eventos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void mandaraltexvo(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btn_seleccionar")
            {
                //foto promocion 7
                // int fila = Convert.ToInt32(e.CommandArgument.ToString());
                int fila = Convert.ToInt32(e.CommandArgument);
                txtid.Value = dgb_eventos.Rows[fila].Cells[1].Text;
                txt_ubicar.Text = dgb_eventos.Rows[fila].Cells[8].Text;
                txt_lo.Text = dgb_eventos.Rows[fila].Cells[10].Text;
                txtlat.Text = dgb_eventos.Rows[fila].Cells[9].Text;
                DateTime fechaapertura = Convert.ToDateTime(dgb_eventos.Rows[fila].Cells[5].Text);
                txt_aperura.Text = fechaapertura.ToString("yyyy-MM-dd");
                txt_codir.Value = dgb_eventos.Rows[fila].Cells[12].Text;
                txt_colonia.Text = dgb_eventos.Rows[fila].Cells[17].Text;
                txt_crizamiento.Text = dgb_eventos.Rows[fila].Cells[19].Text;
                txt_descrip.Text = dgb_eventos.Rows[fila].Cells[2].Text;
                DateTime ida = Convert.ToDateTime(dgb_eventos.Rows[fila].Cells[6].Text);
                txt_fecha_cierre.Text = ida.ToString("yyyy-MM-dd");
                txt_nombre.Text = dgb_eventos.Rows[fila].Cells[3].Text;
                txt_numexter.Text = dgb_eventos.Rows[fila].Cells[21].Text;
                txt_numint.Text = dgb_eventos.Rows[fila].Cells[20].Text;
                txt_postal.Text = dgb_eventos.Rows[fila].Cells[18].Text;
                txt_precio.Text = dgb_eventos.Rows[fila].Cells[4].Text;
                txt_codir.Value = dgb_eventos.Rows[fila].Cells[16].Text;
               txt_visitas.Text= dgb_eventos.Rows[fila].Cells[15].Text;
                Image1.ImageUrl = "/img" + dgb_eventos.Rows[fila].Cells[7].Text.ToString() + ".jpg";
                rbt_aprovado.Checked = (Convert.ToString(dgb_eventos.Rows[fila].Cells[11].Text) != "0") ? true : false;
                rbt_noapro.Checked = (Convert.ToString(dgb_eventos.Rows[fila].Cells[11].Text) == "0") ? true : false;
                txt_usuario.Text = dgb_eventos.Rows[fila].Cells[14].Text;
                ddl_categoria.SelectedValue = dgb_eventos.Rows[fila].Cells[13].Text;
                ddl_municipio.SelectedValue = dgb_eventos.Rows[fila].Cells[22].Text;

            }

           /*
            if (e.CommandName == "btn_aprovar")
            {
                int fila = Convert.ToInt32(e.CommandArgument.ToString());
               // int indice = Convert.ToInt32(e.CommandArgument);
                int id =int.Parse( dgb_eventos.Rows[fila].Cells[2].Text);
             
                EventoBO obj= new EventoBO();
                obj.Codigo = id;
                eventado.modificaraprovacion(obj,Convert.ToString(1));
                refrescar();
            }*/
        }

        protected void dgb_eventos_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[17].Visible = false;
            e.Row.Cells[18].Visible = false;
            e.Row.Cells[19].Visible = false;
            e.Row.Cells[20].Visible = false;
            e.Row.Cells[21].Visible = false;
            e.Row.Cells[22].Visible = false;
            e.Row.Cells[23].Visible = false;
           
            e.Row.Cells[31].Visible = false;
            e.Row.Cells[30].Visible = false;
            e.Row.Cells[32].Visible = false;
            e.Row.Cells[27].Visible = false;
        }
        public string NombreImagen()
        {
            DateTime tiempo = DateTime.Now;
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(tiempo.ToString(System.Globalization.CultureInfo.InvariantCulture)));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        protected void accion(object sender, EventArgs e)
        {
            //GeneraXML();
            var btnSeleccionado = (Button)sender;
            // cargar la foto
            if (btnSeleccionado.ID == "btn_agregar")
            {
                if (file_foto.HasFile)
                {
                    strNuevoNombre = NombreImagen();
                    file_foto.SaveAs(Server.MapPath("~/img") + strNuevoNombre + ".jpg");
                }
                //FileUploadFoto.Save("miimagen.jpg",ImageFormat.Jpeg);
            }
            if (btnSeleccionado.ID == "btn_modificar")
            {
                if (file_foto.HasFile)
                {
                    File.Delete(MapPath(Image1.ImageUrl));
                    strNuevoNombre = NombreImagen();
                    file_foto.SaveAs(Server.MapPath("~img") + strNuevoNombre + ".jpg");
                }
                //FileUploadFoto.Save("miimagen.jpg",ImageFormat.Jpeg);
            }
            if (btnSeleccionado.ID == "btn_eliminar")
            {
                if (file_foto.HasFile)
                {
                    File.Delete("~/img" + Image1.ImageUrl);
                }
                //FileUploadFoto.Save("miimagen.jpg",ImageFormat.Jpeg);
            }
               //se crea el reporte y se agrega la funcion de accion del boton
            if (btnSeleccionado.ID == "btn_nuevo") //cambiar por btnReporte
            {
                DataSet Evento = eventado.buscar();
                DataTable dt = Evento.Tables[0];

                Reportes.ReporteEVentos rpFac = new Reportes.ReporteEVentos();
                rpFac.SetDataSource(dt);

                Session["llena"] = rpFac;
                Session["Tipo"] = "Evento";

                abreVentana("Reporte.aspx");
            }

            Button btnsellcionado = (Button)sender;

           control.accion(devolver(), btnsellcionado.ID);
           // ser_direccion.accion(mandar(), btnsellcionado.ID);
            refrescar();
           

        }
        //primero se genera el xml
        private void abreVentana(string ventana)
        {
            Response.Redirect(ventana, true);
        }

        public void GeneraXML()
        {
            //UsuarioBO usuario = new UsuarioBO();


            DataSet usuarios = eventado.buscar();
            DataTable dt = usuarios.Tables[0];

            dt.WriteXml("eventos.xml");
        }

        protected void btn_eliminar_Click1(object sender, EventArgs e)
        {

        }

        protected void txt_aperura_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_fecha_cierre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void HiddenField1_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void rbt_noapro_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_noapro.Checked == true)
            {
                rbt_aprovado.Checked = false;
            }
         
        }

        protected void rbt_aprovado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_aprovado.Checked == true)
            {
                rbt_noapro.Checked = false;
            }
        }

        protected void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_nombre.Text = "";
            txt_aperura.Text = "";
            txt_fecha_cierre.Text = "";
            txt_precio.Text = "";
            txt_ubicar.Text = "";
            txt_postal.Text = "";
            txt_colonia.Text = "";
            txt_numint.Text = "";
            txt_numexter.Text = "";
            txt_crizamiento.Text = "";
            txt_descrip.Text = "";

        }
    }
}