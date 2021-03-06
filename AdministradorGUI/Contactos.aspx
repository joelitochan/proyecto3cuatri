﻿<%@ Page Title="" Language="C#" MasterPageFile="~/administrador.Master" AutoEventWireup="true" CodeBehind="Contactos.aspx.cs" Inherits="AdministradorGUI.Contactos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .auto-style1 {
            height: 483px;
            width: 667px;
        }
        .auto-style2 {
            position: relative;
            min-height: 1px;
            width: 55%;
            top: 17px;
            left: 126px;
            height: 213px;
            padding-left: 15px;
            padding-right: 15px;
        }
        .auto-style3 {
            position: relative;
            min-height: 1px;
            width: 77%;
            top: 6px;
            left: 75px;
            height: 81px;
            padding-left: 15px;
            padding-right: 15px;
        }
        .auto-style4 {
            margin-left: 14px;
        }
        .auto-style5 {
            width: 586px;
            margin-left: 62px;
            margin-right: -15px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <div class="panel panel-primary" style="width:1160px !important;height:1000px;">
         <div class="panel-heading " style="text-align:center !important; ">Contacto</div>
     <form id="form1" runat="server" class="auto-style1">
       <div class="row">
		<div class="auto-style2 primary" style="left: 61px; top: 17px; width: 80%">
			<div role="form" class="form-inline" >
				<div class="form-group">
					<asp:Label ID="Label1" runat="server" Text="ID" CssClass="text-primary"  ></asp:Label><br />
                    <asp:TextBox ID="txtID" runat="server" Width="505px" Height="30px" Enabled="False"></asp:TextBox>
				</div><br />
				<div class="form-group">
					 <asp:Label ID="Label2" runat="server" Text="Telefono" CssClass="text-primary"></asp:Label><br />
                    <asp:TextBox ID="txtTelefono" runat="server" Width="505px" Height="30px"></asp:TextBox>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
  ControlToValidate="txtTelefono"
  ErrorMessage="No se puede dejar los campos vacios"
  ForeColor="Red">
</asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="txtTelefono" ErrorMessage="*Ingrese Valores Numericos"
                            ForeColor="Red"
                            ValidationExpression="^[0-9]*">
</asp:RegularExpressionValidator>
                    <br />

				</div>
			</div>
		</div>
	<div class="row">
		<div class="auto-style3">
			<asp:Button ID="btnAgregar" Text="Agregar" runat="server" CssClass="btn btn-dropbox" Width="100px" OnClick="Accion"  /> 
            <asp:Button ID="btnModificar" Text="Modificar" runat="server" CssClass="btn btn-dropbox" Width="100px" OnClick="Accion"   />
            <asp:Button ID="btnEliminar" Text="Eliminar" runat="server" CssClass="btn btn-dropbox" Width="100px" OnClick="Accion"  />
            <asp:Button ID="btnNuevo" Text="Nuevo" runat="server" CssClass="btn btn-dropbox" Width="100px" />
       <div style="display:none"><asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="btn btn-dropbox" Width="100px" /></div>     

		</div>
	</div><br />
           <div class="row">
           <div class="auto-style5">
               <div class="form-group">
                   <asp:GridView ID="dtgContactos" runat="server" CssClass="table-resposive table table-bordered" Width="590px" OnRowCommand="Selecionar" OnRowCreated="dtgContactos_RowCreated" >
                       <Columns>
                           
                           <asp:ButtonField CommandName="dgvbtnSeleccionar" Text="Seleccionar" />
                           
                       </Columns>
                   </asp:GridView>
               </div>
           </div>
               </div>
    </div>
    </form>
          </div>
</asp:Content>
