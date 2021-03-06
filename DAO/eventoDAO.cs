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
  public  class eventoDAO : interface_metodos_guardar_eliminar_actualizar_buscar
    {
        Direccion Direccion;
        conexionDAO conectar = new conexionDAO();
        public int agregar(object agregar)
        {
           //INSERT INTO EVENTO(DESCRIPCION,NOMBRE,COSTO,FECHAAPERTURA,FECHACIERRE,FOTOPROMOCION,UBICACIONGEOGRAFICA,LATITUD,LONGITUD,APROVACION,DIRECCION,CATEGORIA,USUARIO)VALUES APROVACION=@aprova
           
           EventoBO obejto = (EventoBO)agregar;
               SqlCommand dir = new SqlCommand("INSERT INTO DIRECCION(COLONIA,CODIGOPOSTAL,CRUZAMIENTO,NUMEROINTERIOR,NUMEROEXTERIOR ,MUNICIPIO) output" + " inserted.CODIGO values(@col,@pos,@cru,@numin,@numex,@muni)");
            // dir.Parameters.AddWithValue
            // int id =dir.ExecuteNonQuery();
            //   conectar.EjecutarComando(dir);
            dir.Parameters.Add("@col", SqlDbType.VarChar).Value = obejto.Colonia;//----
            dir.Parameters.Add("@pos", SqlDbType.Char).Value = obejto.CodigoPostal;
            dir.Parameters.Add("@cru", SqlDbType.VarChar).Value = obejto.Cruzamiento;
            dir.Parameters.Add("@numin", SqlDbType.VarChar).Value = obejto.NumeroInterior;
            dir.Parameters.Add("@numex", SqlDbType.VarChar).Value = obejto.NumeroExterior;
            dir.Parameters.Add("@muni", SqlDbType.Int).Value = obejto.CodigoMunicipio;//--

            int id = conectar.EjecutarComando(dir);


            SqlCommand cmd = new SqlCommand("INSERT INTO EVENTO(DESCRIPCION ,NOMBRE,COSTO ,FECHAAPERTURA ,FECHACIERRE,FOTOPROMOCION,UBICACIONGEOGRAFICA,LATITUD,LONGITUD,APROVACION,DIRECCION,CATEGORIA,USUARIO,VISITAS)  VALUES(@des,@nom,@cos,@feaper,@fecier,@foto,@ubicacion,@lat,@long,@aprova,'" + id + "',@cat,@codus,@visi)");

          

            
          /*  cmd.Parameters.Add("@col", SqlDbType.VarChar).Value = obejto.Colonia;//----
            cmd.Parameters.Add("@pos", SqlDbType.Char).Value = obejto.CodigoPostal;
            cmd.Parameters.Add("@cru", SqlDbType.VarChar).Value = obejto.Cruzamiento;
            cmd.Parameters.Add("@numin", SqlDbType.VarChar).Value = obejto.NumeroInterior;
            cmd.Parameters.Add("@numex", SqlDbType.VarChar).Value = obejto.NumeroExterior;
            cmd.Parameters.Add("@muni", SqlDbType.Int).Value = obejto.CodigoMunicipio;//--*/
            cmd.Parameters.Add("@des", SqlDbType.VarChar).Value = obejto.Descripcion;
              cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = obejto.Nombre;
              cmd.Parameters.Add("@cos", SqlDbType.Money).Value = obejto.costo; 
              cmd.Parameters.Add("@feaper", SqlDbType.Date).Value = obejto.FechaApertura.ToString("yyyy-MM-dd"); 
              cmd.Parameters.Add("@fecier", SqlDbType.Date).Value = obejto.FechaCierre.ToString("yyyy-MM-dd"); 
              cmd.Parameters.Add("@foto", SqlDbType.VarChar).Value = obejto.FotoPromocion;
            cmd.Parameters.Add("@ubicacion", SqlDbType.VarChar).Value = obejto.UbicacionGeografica;
            cmd.Parameters.Add("@lat", SqlDbType.VarChar).Value = obejto.latitud;
            cmd.Parameters.Add("@long", SqlDbType.VarChar).Value = obejto.longitud;
            cmd.Parameters.Add("@aprova", SqlDbType.VarChar).Value = obejto.aprovacion;
            cmd.Parameters.Add("@dirr", SqlDbType.Int).Value = obejto.CodigoDireccion;
            cmd.Parameters.Add("@cat", SqlDbType.Int).Value = obejto.CodigoCategoria;
            cmd.Parameters.Add("@codus", SqlDbType.Int).Value = obejto.CodigoUsuario;
            cmd.Parameters.Add("@visi", SqlDbType.Int).Value = obejto.visitas;
            cmd.CommandType = CommandType.Text;
           
              return conectar.EjecutarComando(cmd);
        }

       

        public DataSet buscar()
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO  
            SqlCommand cmd = new SqlCommand(" select * from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO;  ");
           

            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }
        public DataSet buscar_usuriounico(int valor)
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO  
            EventoBO objetito = new EventoBO();
            SqlCommand cmd = new SqlCommand(" select * from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO where u.CODIGO=@cod  ");

            cmd.Parameters.Add("@cod", SqlDbType.Int).Value = valor;
            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }

        public int eliminar(object eliminar)
        {
             EventoBO obejto = (EventoBO)eliminar;
            //eliminar galeria 
            SqlCommand galeria = new SqlCommand("delete  from GALERIA where GALERIA.IDEVENTO=@cod");
            galeria.Parameters.Add("@cod", SqlDbType.Int).Value = obejto.Codigo;
            galeria.CommandType = CommandType.Text;
            conectar.EjecutarComando(galeria);

            //eliminar horario

            SqlCommand horario = new SqlCommand("delete  from HORARIOS where  HORARIOS.EVENTO=@cod");
            horario.Parameters.Add("@cod", SqlDbType.Int).Value = obejto.Codigo;
            horario.CommandType = CommandType.Text;
            conectar.EjecutarComando(horario);


            //eliminar evento
            SqlCommand cmd = new SqlCommand("delete  from EVENTO where CODIGO=@cod");
            cmd.Parameters.Add("@cod", SqlDbType.Int).Value = obejto.Codigo;
            cmd.CommandType = CommandType.Text;

            int evento = conectar.EjecutarComando(cmd);
            //
            SqlCommand eliminardir = new SqlCommand("delete  from DIRECCION where CODIGO=@codi");

            eliminardir.Parameters.Add("@codi", SqlDbType.Int).Value = obejto.Codigo_dir;
            eliminardir.CommandType = CommandType.Text;
            int dirrecion = conectar.EjecutarComando(eliminardir);
            //
           
           

            int respuesta = ((dirrecion != 0) && (evento != 0)) ? 1 : 0;

            return respuesta;

        }

        public int modificar(object modificar)
        {
            EventoBO obejto = (EventoBO)modificar;
            SqlCommand cmd = new SqlCommand("update  EVENTO set DESCRIPCION=@des ,NOMBRE=@nom,COSTO=@cos ,FECHAAPERTURA=@feaper ,FECHACIERRE=@fecier,FOTOPROMOCION=@foto,UBICACIONGEOGRAFICA=@ubicacion,LATITUD=@lat,LONGITUD=@long,APROVACION=@aprova,DIRECCION=@dirr,CATEGORIA=@cat,USUARIO=@codus, VISITAS=@visi where CODIGO=@codigo");
            cmd.Parameters.Add("@codigo", SqlDbType.Int).Value = obejto.Codigo;
            cmd.Parameters.Add("@des", SqlDbType.VarChar).Value = obejto.Descripcion;
            cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = obejto.Nombre;
            cmd.Parameters.Add("@cos", SqlDbType.Money).Value = obejto.costo;
            cmd.Parameters.Add("@feaper", SqlDbType.Date).Value = obejto.FechaApertura.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@fecier", SqlDbType.Date).Value = obejto.FechaCierre.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@foto", SqlDbType.VarChar).Value = obejto.FotoPromocion;
            cmd.Parameters.Add("@ubicacion", SqlDbType.VarChar).Value = obejto.UbicacionGeografica;
            cmd.Parameters.Add("@lat", SqlDbType.VarChar).Value = obejto.latitud;
            cmd.Parameters.Add("@long", SqlDbType.VarChar).Value = obejto.longitud;
            cmd.Parameters.Add("@aprova", SqlDbType.VarChar).Value = obejto.aprovacion;
            cmd.Parameters.Add("@dirr", SqlDbType.Int).Value = obejto.Codigo_dir;
            cmd.Parameters.Add("@cat", SqlDbType.Int).Value = obejto.CodigoCategoria;
            cmd.Parameters.Add("@codus", SqlDbType.Int).Value = obejto.CodigoUsuario;
            cmd.Parameters.Add("@visi", SqlDbType.Int).Value = obejto.visitas;
            cmd.CommandType = CommandType.Text;

            int actualizar_evento = conectar.EjecutarComando(cmd);


            SqlCommand dire = new SqlCommand("update  DIRECCION set COLONIA=@col,CODIGOPOSTAL=@pos,CRUZAMIENTO=@cru,NUMEROINTERIOR=@numin,NUMEROEXTERIOR=@numex ,MUNICIPIO=@muni where CODIGO=@codi");
            dire.Parameters.Add("@codi", SqlDbType.Int).Value = obejto.Codigo_dir;
            dire.Parameters.Add("@col", SqlDbType.VarChar).Value = obejto.Colonia;
            dire.Parameters.Add("@pos", SqlDbType.Char).Value = obejto.CodigoPostal;
            dire.Parameters.Add("@cru", SqlDbType.VarChar).Value = obejto.Cruzamiento;
            dire.Parameters.Add("@numin", SqlDbType.VarChar).Value = obejto.NumeroInterior;
            dire.Parameters.Add("@numex", SqlDbType.VarChar).Value = obejto.NumeroExterior;
            dire.Parameters.Add("@muni", SqlDbType.Int).Value = obejto.CodigoMunicipio;
            dire.CommandType = CommandType.Text;

            int actualizar_dir = conectar.EjecutarComando(dire);
      
         

            int Respuesta = ((actualizar_dir != 0) && (actualizar_evento != 0)) ? 1 : 0;
            return Respuesta;
        }
        public DataSet buscar_categoria()
        {
            SqlCommand cmd = new SqlCommand("select * from CATEGORIA ");


            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }
        public DataSet buscar_municipio()
        {
            SqlCommand cmd = new SqlCommand("select * from MUNICIPIO ");


            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }

       

        public int modificaraprovacion(EventoBO oevento, string aprovacion)
        {
            SqlCommand comando = new SqlCommand("UPDATE EVENTO set APROVACION=@apro WHERE CODIGO=@id");
            comando.Parameters.Add("@apro", SqlDbType.VarChar).Value = aprovacion;
            comando.Parameters.Add("@id", SqlDbType.Int).Value = oevento.Codigo;
            //id ID

            return conectar.EjecutarComando(comando);
        }

        public DataSet buscar_noaprovados()
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO  
            SqlCommand cmd = new SqlCommand(" select * from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO where e.APROVACION='0' ;  ");


            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }
        public DataSet buscar_noaprovados12(string valor)
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO  
            SqlCommand cmd = new SqlCommand("   select * from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO where e.APROVACION='0' and  e.NOMBRE LIKE '%'+ @apro +'%'  ;  ");

            cmd.Parameters.Add("@apro", SqlDbType.VarChar).Value = valor;
            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }
        public DataSet buscar_noaprovados123(string valor)
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO  
            SqlCommand cmd = new SqlCommand("   select * from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO where e.APROVACION='1' and  e.NOMBRE LIKE '%'+ @apro +'%'  ;  ");

            cmd.Parameters.Add("@apro", SqlDbType.VarChar).Value = valor;
            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }


        public DataSet buscar_aprovados()
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO  
            SqlCommand cmd = new SqlCommand("select * from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO inner join CATEGORIA cat on cat.CODIGO=e.CATEGORIA where e.APROVACION='1'  order by e.CODIGO DESC  ");


            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }
        public int modificarVisistas(EventoBO oevento)
        {
            SqlCommand com = new SqlCommand("select VISITAS from EVENTO where CODIGO=@id");
            com.Parameters.Add("@id", SqlDbType.Int).Value = oevento.Codigo;

            DataRow row = conectar.EjecutarSentencia(com).Tables[0].Rows[fila];
            int suma = Convert.ToInt32(row[0].ToString());

            

            SqlCommand comando = new SqlCommand("UPDATE EVENTO set VISITAS=@vis WHERE CODIGO=@id");
            comando.Parameters.Add("@vis", SqlDbType.Int).Value = suma + 1;
            comando.Parameters.Add("@id", SqlDbType.Int).Value = oevento.Codigo;

            return conectar.EjecutarComando(comando);
        }
        public DataSet busca3()
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO  
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO  
            SqlCommand cmd = new SqlCommand("select MAX(CODIGO) from EVENTO;");


            DataRow row = conectar.EjecutarSentencia(cmd).Tables[0].Rows[fila];
            int val = Convert.ToInt32(row[0].ToString()) - 2;


            cmd.CommandType = CommandType.Text;

            SqlCommand coma = new SqlCommand("select * from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO where e.APROVACION='1' and e.CODIGO=@codi ");
            coma.Parameters.Add("@codi", SqlDbType.Int).Value = val;


            return conectar.EjecutarSentencia(coma);
        }
        public DataSet busca2()
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO  
            SqlCommand cmd = new SqlCommand("select MAX(CODIGO) from EVENTO;");


            DataRow row = conectar.EjecutarSentencia(cmd).Tables[0].Rows[fila];
            int val = Convert.ToInt32(row[0].ToString()) - 1;


            cmd.CommandType = CommandType.Text;

            SqlCommand coma = new SqlCommand("select * from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO where e.APROVACION='1' and e.CODIGO=@codi ");
            coma.Parameters.Add("@codi", SqlDbType.Int).Value = val;


            return conectar.EjecutarSentencia(coma);
        }
        int fila;
        public DataSet busca1()
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO  
            SqlCommand cmd = new SqlCommand("select MAX(CODIGO) from EVENTO;"); //tener cuidado cuando usen aprobacion correctamente
           
            
            DataRow row = conectar.EjecutarSentencia(cmd).Tables[0].Rows[fila];
            int val = Convert.ToInt32(row[0].ToString());
            

            cmd.CommandType = CommandType.Text;

            SqlCommand coma = new SqlCommand("select * from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO where e.APROVACION='1' and e.CODIGO=@codi ");
            coma.Parameters.Add("@codi", SqlDbType.Int).Value = val;


            return conectar.EjecutarSentencia(coma);
        }
        //buscar los eventos de danza
        public DataSet buscar_aprovados_danza()
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO  
            SqlCommand cmd = new SqlCommand("  select * from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO where e.APROVACION='1' and e.CATEGORIA=1 order by e.CODIGO DESC  ");

           
            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }
        //buscar los eventos de danza
        public DataSet buscar_aprovados_teatro()
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO   2
            SqlCommand cmd = new SqlCommand("  select * from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO where e.APROVACION='1' and e.CATEGORIA=3 order by e.CODIGO DESC  ");

            

            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }
        //buscar los eventos de danza
        public DataSet buscar_aprovados_musica()
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO  3
            SqlCommand cmd = new SqlCommand("  select * from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO where e.APROVACION='1' and e.CATEGORIA=2 order by e.CODIGO DESC ");

         
            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }


        public DataSet datoseventoselecionado(int id)
        {
            SqlCommand coma = new SqlCommand("  select  e.* , cat.NOMBRE as nombrecat  ,cat.CODIGO , d.*,u.*, mu.NOMBRE as muni from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO inner join CATEGORIA cat on  cat.CODIGO=e.CATEGORIA inner join MUNICIPIO mu on mu.CODIGO=d.MUNICIPIO where e.APROVACION='1' and e.CODIGO=@cod "
);
            coma.Parameters.Add("@cod", SqlDbType.Int).Value = id;
            coma.CommandType = CommandType.Text;



            return conectar.EjecutarSentencia(coma);
        }
        public DataSet MAPA()
        {
            SqlCommand coma = new SqlCommand("  select  e.* , cat.NOMBRE as nombrecat  ,cat.CODIGO , d.*,u.*, mu.NOMBRE as muni from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO inner join CATEGORIA cat on  cat.CODIGO=e.CATEGORIA inner join MUNICIPIO mu on mu.CODIGO=d.MUNICIPIO where e.APROVACION='1'  "
);


            coma.CommandType = CommandType.Text;
            return conectar.EjecutarSentencia(coma);
        }
        public DataSet top_3visitas()
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO   2
            SqlCommand cmd = new SqlCommand("   select  TOP 3 * from EVEnto where aprovacion=1 order by (visitas) desc   ");



            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }
        public DataSet top_3recientes()
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO   2
            SqlCommand cmd = new SqlCommand("   select  TOP 3 * from EVEnto where aprovacion=1 order by (CODIGO) desc   ");



            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }
        public DataSet top_recientes()
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO   2
            SqlCommand cmd = new SqlCommand("   select   * from EVEnto  where aprovacion=1  order by (visitas) desc   ");



            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }
        public DataSet galeria(int id)
        {
            SqlCommand cmd = new SqlCommand("select FOTO from GALERIA where IDEVENTO=@ID");
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            cmd.CommandType = CommandType.Text;
            return conectar.EjecutarSentencia(cmd);
        }
        public DataSet buscar_aprovadosdelmater(EventoBO fecha)
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO  
            SqlCommand cmd = new SqlCommand("select * from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO inner join CATEGORIA cat on cat.CODIGO=e.CATEGORIA where e.APROVACION='1' and e.NOMBRE LIKE '%'+ @nom +'%'  ");

            cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = fecha.Nombre ;
            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }
        public DataSet buscar_aprovadosdelmater1(EventoBO fecha)
        {
            // select * from EVENTO e inner join DIRECCION d on e.DIRECCION=d.CODIGO  
            SqlCommand cmd = new SqlCommand("select * from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO inner join CATEGORIA cat on cat.CODIGO=e.CATEGORIA where e.APROVACION='1' and  @fecha between e.FECHAAPERTURA AND FECHACIERRE  order by e.CODIGO DESC ");

            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.FechaApertura.ToString("yyyy-MM-dd"); ;
            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }

        public DataSet FILTRAR2(string Parametro2, DateTime Fecha2)
        {
            String Query = "";

            if (String.IsNullOrEmpty(Parametro2))
            {
                Query = "e.FECHAAPERTURA >= '" + Fecha2.ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                Query = "e.NOMBRE LIKE'%" + Parametro2 + "%' ";
            }
            SqlCommand cmd = new SqlCommand(" select * from EVENTO e  inner join DIRECCION d on e.DIRECCION=d.CODIGO inner join USUARIOS u on  u.CODIGO=e.USUARIO WHERE "+Query);


            cmd.CommandType = CommandType.Text;


            return conectar.EjecutarSentencia(cmd);
        }

    }












}
