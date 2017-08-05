﻿
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="AdministradorGUI.Reporte" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


    

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtbuscar" runat="server"></asp:TextBox>
            
            <% 
                String tipo = (String)Session["Tipo"];
            %>
            
            <% if (tipo == "Evento" || tipo == "Usuario")
                { %>
             <asp:TextBox ID="txtfecha" runat="server" CssClass="form-control" type="date"  Width="300px" Height="32px"></asp:TextBox>
            <%} %>
            <asp:Button ID="btnbuscar" runat="server" Text="Buscar" OnClick="Accion"/>
        </div>
    <div>
    
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" Height="500px" Width="350px"  HasCrystalLogo="False" HasToggleGroupTreeButton="False"/>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
