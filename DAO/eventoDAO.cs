﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BO;

namespace DAO
{
    class eventoDAO : interface_metodos_guardar_eliminar_actualizar_buscar
    {
        conexionDAO conectar = new conexionDAO();
        public int agregar(object agregar)
        {
            EventoBO obejto = (EventoBO)agregar;
              SqlCommand cmd = new SqlCommand("INSERT INTO DIRECCION(COLONIA,CODIGOPOSTAL,CRUZAMIENTO,NUMEROINTERIOR,NUMEROEXTERIOR ,MUNICIPIO) values(@col,@pos,@cru,@numin,@numex,@muni)");
            /*   cmd.Parameters.Add("@col", SqlDbType.VarChar).Value = obejto.Colonia;
              cmd.Parameters.Add("@pos", SqlDbType.Char).Value = obejto.CodigoPostal;
              cmd.Parameters.Add("@cru", SqlDbType.VarChar).Value = obejto.Cruzamiento;
              cmd.Parameters.Add("@numin", SqlDbType.VarChar).Value = obejto.NumeroInterior;
              cmd.Parameters.Add("@numex", SqlDbType.VarChar).Value = obejto.NumeroExterior;
              cmd.Parameters.Add("@muni", SqlDbType.Int).Value = obejto.CodigoMunicipio;*/
            cmd.CommandType = CommandType.Text;

              return conectar.EjecutarComando(cmd);
        }

        public DataSet buscar()
        {
            throw new NotImplementedException();
        }

        public int eliminar(object eliminar)
        {
            EventoBO obejto = (EventoBO)eliminar;
            SqlCommand cmd = new SqlCommand("delete  from EVENTO where CODIGO=@cod");
            cmd.Parameters.Add("@cod", SqlDbType.Int).Value = obejto.Codigo;

              cmd.CommandType = CommandType.Text;


            return conectar.EjecutarComando(cmd);

        }

        public int modificar(object modificar)
        {
            EventoBO obejto = (EventoBO)modificar;
            SqlCommand cmd = new SqlCommand("update  DIRECCION set COLONIA=@col,CODIGOPOSTAL=@pos,CRUZAMIENTO=@cru,NUMEROINTERIOR=@numin,NUMEROEXTERIOR=@numex ,MUNICIPIO=@muni where CODIGO=@cod");
        /*      cmd.Parameters.Add("@cod", SqlDbType.Int).Value = obejto.Codigo;
            cmd.Parameters.Add("@col", SqlDbType.VarChar).Value = obejto.Colonia;
            cmd.Parameters.Add("@pos", SqlDbType.Char).Value = obejto.CodigoPostal;
            cmd.Parameters.Add("@cru", SqlDbType.VarChar).Value = obejto.Cruzamiento;
            cmd.Parameters.Add("@numin", SqlDbType.VarChar).Value = obejto.NumeroInterior;
            cmd.Parameters.Add("@numex", SqlDbType.VarChar).Value = obejto.NumeroExterior;
            cmd.Parameters.Add("@muni", SqlDbType.Int).Value = obejto.CodigoMunicipio;
            cmd.CommandType = CommandType.Text;*/

            return conectar.EjecutarComando(cmd);
        }
    }
}
