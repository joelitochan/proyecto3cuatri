﻿<%@ Page Title="" Language="C#" MasterPageFile="~/administrador.Master" AutoEventWireup="true" CodeBehind="admi_organizadoresGUI.aspx.cs" Inherits="GUI.admi_listausuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #form1 {
            height: 125px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="css/estilo-usuario.css" rel="stylesheet" />
     
     
    <form  id="form1" runat="server">
      

    <h1>Control de los Organizadores</h1>
   <div class="container">


       <div class="row">
           <div class="col-md-12">

          <div class="form-group">
             
                 
                <label for="txt_nombre" class="">nombre:</label>
                  <div class="col-md-6">
                    <asp:TextBox ID="txt_nombre" runat="server" Text="" CssClass="form-control "></asp:TextBox>
                      </div>
                     <label for="txt_apellidos" class="">apellidos:</label>
                  <div class="col-md-6">
                    <asp:TextBox ID="txt_apellios" runat="server" Text="" CssClass="form-control "></asp:TextBox>
              </div>
              
                
             
          </div>
             
           
           <asp:Button ID="btn_eliminar" runat="server" Text="Eliminar" CssClass="btn-primary col-sm-push-4  " />
         
        <asp:Button ID="btn_modificar" runat="server" Text="Modificar" CssClass="btn-primary col-sm-push-4 " />
             <asp:Button ID="btn_agregar" runat="server" Text="agregar" CssClass="btn-primary col-sm-push-4  " />
         
        <asp:Button ID="btn_nuevo" runat="server" Text="nuevo" CssClass="btn-primary    col-sm-push-4 " />
              
         
        <asp:GridView ID="dgv_usuarios" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:ButtonField CommandName="dvg_btnSelecinar" Text="Selecionar" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
      
          
            
          
  
    </div>
      </div>      

</form>

           
</asp:Content>
