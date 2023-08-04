<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ELEC.WebForm.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblTitulo" runat="server" CssClass="fs-4 fw-bold"></asp:Label>

    <div class="mb-3">
        <label class="form-label">Producto</label>
        <asp:TextBox ID="txtNombreProducto" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label class="form-label">Categorias</label>
        <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>

    <div class="mb-3">
        <label class="form-label">Fecha Alta</label>
        <asp:TextBox ID="txt_fechaAlta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label class="form-label">Fecha Baja</label>
        <asp:TextBox ID="txt_fechaBaja" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>

    <asp:Button ID="btnSubmit" runat="server" Text="Guardar" CssClass="btn btn-sm btn-primary" OnClick="btnSubmit_Click"/>
    <asp:LinkButton runat="server" PostBackUrl="~/Default.aspx" CssClass="btn btn-sm btn-warning"><< Regresar</asp:LinkButton>
</asp:Content>
