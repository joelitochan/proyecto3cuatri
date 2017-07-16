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
    public partial class loginn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UsuarioBO obj = new UsuarioBO();
            obj.Usuario = txt_usuario.Text;
            obj.Contraseña = txt_contraseña.Text;

            usuarioDAO usuario = new usuarioDAO();

            if (usuario.verificar(obj))
            {
                Session["usuario"] = txt_usuario.Text;
             
                Response.Write("<script>alert('usuario correcto')</script>");
                Response.Redirect("prueva.aspx", true);
            }
            else
            {
                Response.Write("<script>alert('usuario incorrecto')</script>");

            }

        }
    }
}