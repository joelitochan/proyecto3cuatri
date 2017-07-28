﻿<%@ Page Title="" Language="C#" MasterPageFile="~/administrador.Master" AutoEventWireup="true" CodeBehind="Pais.aspx.cs" Inherits="AdministradorGUI.Pais" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form id="form1" runat="server">
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ID País&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txt_IdPais" runat="server"></asp:TextBox>
        </p>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Nombre País&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="txt_NombrePais" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
  ControlToValidate="txt_NombrePais"
  ErrorMessage="No se puede dejar los campos vacios"
  ForeColor="Red">
</asp:RequiredFieldValidator>
            <br />
        </p>
        <p>

            <br />
        </p>
        <p>
    
            <asp:Button ID="btn_Nuevo" runat="server" Text="Nuevo"  CssClass="btn-primary col-md-2 col-lg-offset-1" OnClick="Accion" />

            <asp:Button ID="btn_Modificar" runat="server" Text="Modificar"  CssClass="btn-primary col-md-2 col-lg-offset-1" OnClick="Accion" />

            <asp:Button ID="btn_Eliminar" runat="server" Text="Eliminar"  CssClass="btn-primary col-md-2 col-lg-offset-1" OnClick="Accion"  />

            <asp:Button ID="btn_Buscar" runat="server" Text="Buscar"  CssClass="btn-primary col-md-2 col-lg-offset-1" OnClick="Accion" />
            </div>
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:GridView ID="dgv_Pais" runat="server" OnRowCommand="Seleccionar" CssClass="table-resposive table table-bordered" >
                <Columns>
                    <asp:ButtonField CommandName="dgvbtnSeleccionar" Text="Seleccionar" >
                    <ControlStyle CssClass="btn btn-primary" />
                    </asp:ButtonField>
                </Columns>
            </asp:GridView>
        </p>
    </form>
</asp:Content>
