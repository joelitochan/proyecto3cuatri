﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using DAO;
using System.Web.Security;

namespace GUI
{
    public partial class loggin_fuerademasterpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void condicion_de_login(object sender, EventArgs e)
        {
            UsuarioBO obj = new UsuarioBO();
            obj.Usuario = txt_usuario.Text;
            obj.Contraseña = txt_contraseña.Text;
          
            usuarioDAO usuario = new usuarioDAO();
            loginDAO login = new loginDAO();
            

            if (login.verificar(obj))
            {
                Session["usuario"] = txt_usuario.Text;
                Session["id"] = login.buscarelid(obj);



                var Roles = usuario.ObtenerTipoCuenta(txt_usuario.Text);
                var fila = Roles.Tables[0].Rows[0];

                string Rol = fila[0].ToString();

                Session["tipo"] = Rol;
                Response.Write("<script>alert('usuario correcto')</script>");

                if (Rol == "USUARIO")
                {
                    Response.Redirect("WebForm1.aspx", true);


                }
                else if (Rol == "ADMINISTRADOR")
                {
                    Response.Redirect("http://localhost:52104/admi_de%20eventosGUI.aspx", true);
                }
                else if (Rol == "ORGANIZADOR")
                {

                    Response.Redirect("WebForm1.aspx", true);
                }
            }
            else
            {
                Response.Write("<script>alert('usuario incorrecto')</script>");

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("registro_usuarios_fueramasterpge.aspx");
        }
    }
}