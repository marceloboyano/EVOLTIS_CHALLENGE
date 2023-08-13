<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentation._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 <div class="row justify-content-center">
    <div class="col-6 mb-4">
        <div class="form-outline">
             <asp:TextBox ID="txtSearch" runat="server" class="form-control" AutoPostBack="true" OnTextChanged="TxtSearch_TextChanged" placeholder="Buscar..."></asp:TextBox>
        </div>
    </div> 
</div>


   
    <div class="row">
         <div class="col-12">
             <asp:GridView ID="GVEmployee" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                 <Columns>
                     <asp:BoundField DataField="Id" HeaderText="Id"/>
                     <asp:BoundField DataField="Name" HeaderText="Nombre"/>
                     <asp:BoundField DataField="LastName" HeaderText="Apellido"/>
                     <asp:BoundField DataField="Email" HeaderText="Correo Electrónico"/>
                     <asp:BoundField DataField="Salary" HeaderText="Salario"/>


                 <asp:TemplateField>
                     <ItemTemplate>
                       <div class="btn-group" role="group">
                         
                            <asp:LinkButton runat="server" 
                             OnClick="Create_Click" CssClass ="btn btn-sm btn-success"                             
                             >Agregar</asp:LinkButton> 

                         <asp:LinkButton runat="server" CommandArgument='<%# Eval("Id") %>'
                             OnClick="Update_Click" CssClass ="btn btn-sm btn-primary"                             
                             >Editar</asp:LinkButton> 
                         
                         <asp:LinkButton runat="server" CommandArgument='<%# Eval("Id") %>'
                             OnClick="Delete_Click" CssClass ="btn btn-sm btn-danger" OnClientClick="return confirm('¿Desea Eliminar?')"                        
                             >Eliminar</asp:LinkButton>
                        </div>
                     </ItemTemplate>
                 </asp:TemplateField>
                 </Columns>
             </asp:GridView>
         </div>
    </div>

</asp:Content>
