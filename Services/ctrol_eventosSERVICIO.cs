﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAO;
namespace Services
{
 public   class ctrol_eventosSERVICIO
    {

        eventoDAO objdai;
        public ctrol_eventosSERVICIO()
        {
            objdai = new eventoDAO();
        }

        public bool accion(EventoBO evento, string str_accion)
        {
            switch (str_accion)
            {
                case "btn_agregar":
                    objdai.agregar(evento);
                    break;
                case "btn_eliminar":
                    objdai.eliminar(evento);
                    break;
                case "btn_modificar":
                    objdai.modificar(evento);
                    break;
                case "btn_limpiar":

                    break;



            }
            return true;

        }












    }
}
