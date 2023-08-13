<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Presentation.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblTitle" runat="server" CssClass="fs-4 fw-bold"></asp:Label>

    <div class="mb-3">
        <label class="form-label">Nombre</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
            ErrorMessage="El nombre es requerido." CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revName" runat="server" ControlToValidate="txtName"
            ErrorMessage="Solo se permiten letras." ValidationExpression="^[a-zA-Z ]*$" CssClass="text-danger"></asp:RegularExpressionValidator>
   
    </div>

    <div class="mb-3">
        <label class="form-label">Apellido</label>
        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
            ErrorMessage="El apellido es requerido." CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revLastName" runat="server" ControlToValidate="txtLastName"
            ErrorMessage="Solo se permiten letras." ValidationExpression="^[a-zA-Z ]*$" CssClass="text-danger"></asp:RegularExpressionValidator>
    </div>

    <div class="mb-3">
        <label class="form-label">Correo Electrónico</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
            ErrorMessage="El email es requerido." CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
            ErrorMessage="Ingrese una dirección de correo electrónico válida." ValidationExpression="^[\w\.-]+@[\w-]+\.\w{2,4}$" CssClass="text-danger"></asp:RegularExpressionValidator>
    </div>

    <div class="mb-3">
        <label class="form-label">Salario</label>
        <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvSalary" runat="server" ControlToValidate="txtSalary"
            ErrorMessage="El salario es requerido." CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revSalary" runat="server" ControlToValidate="txtSalary"
            ErrorMessage="Ingrese un salario válido, solo se permite 2 decimales y 10 digitos en total." ValidationExpression="^\d{1,8}([,.]\d{1,2})?$" CssClass="text-danger"></asp:RegularExpressionValidator>
    </div>

    <asp:Button ID="btnSubmit" runat="server" Text="Enviar" CssClass="btn btn-sm btn-primary" OnClick="btnSubmit_Click" />

    <asp:LinkButton runat="server" PostBackUrl="~/Default.aspx" CssClass="btn btn-sm btn-warning" CausesValidation="false">Volver</asp:LinkButton>

</asp:Content>
