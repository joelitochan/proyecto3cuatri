﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DAO;
using BO;
using System.Data;
using System.Data.SqlClient;

namespace Services
{
   public class CTRL_Categoria
    {
        CategoriaDAO oCategoriaDAO;

        public CTRL_Categoria()
        {
            oCategoriaDAO = new CategoriaDAO();
        }

        public bool Accion(string strAccion, CategoriaBO oCategoriaBO)
        {
            switch (strAccion)
            {
                case "btnAgregar":
                    oCategoriaDAO.agregar(oCategoriaBO);
                    break;
                case "btnEliminar":
                    oCategoriaDAO.eliminar(oCategoriaBO);
                    break;
                case "btnModificar":
                    oCategoriaDAO.modificar(oCategoriaBO);
                    break;
                case "btnBuscar":
                    oCategoriaDAO.buscar(oCategoriaBO);
                                     
                    break;

                case "btnLimpiar":
                    
                    break;
                    


            }
            return true;
        }

        public DataSet listar()
        {
            return oCategoriaDAO.listar();
        }

       
    }
}
