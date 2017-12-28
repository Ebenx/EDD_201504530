<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="GrafoUsuarios.aspx.cs" Inherits="ClienteNW.GrafoUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table style="width: 100%">
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" ForeColor="Black">Grafo de Usuarios</asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">

                

                
                <img id="ImagenUsuario" runat="server" align="center" class="img-rounded" alt="Cinque Terre" />

                

            </td>
            <td class="auto-style1">
            </td>
        </tr>

 
         <tr>
                    <td class="auto-style7">
                &nbsp;</td>
                    <td class="auto-style8">
                        <img id="ImagenEpejo" runat="server" align="center" class="img-rounded" alt="Cinque Terre" />&nbsp;</td>
                    <td class="auto-style9">

                        &nbsp;</td>
                
                </tr>

        </table>
    
    
</asp:Content>
