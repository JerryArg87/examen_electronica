<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ELEC.WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-12">

            <asp:Button runat="server" OnClick="Nuevo_Click" CssClass="btn btn-sm btn-success" Text="Nuevo" />
        </div>              
    </div>
    <div class="row">
        <div class="col-12">
            <asp:GridView ID="GVProductos" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="NombreProducto" HeaderText="Producto" />
                    <asp:BoundField DataField="IdCategoria.NombreCategoria" HeaderText="Categoria" />
                    <asp:BoundField DataField="FechaAlta" HeaderText="Fecha alta" />
                    <asp:BoundField DataField="FechaBaja" HeaderText="Fecha baja" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("idProducto") %>'
                            OnClick="Editar_click" CssClass="btn btn-sm btn-primary"   
                            >Editar</asp:LinkButton>

                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("idProducto") %>'
                            OnClick="Eliminar_click" CssClass="btn btn-sm btn-danger" 
                            OnClientClick="return confirm('¿Esta seguro quiere borrar el producto?')"  
                            >Eliminar</asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>              
    </div>

</asp:Content>
