<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="cargaMasiva.aspx.cs" Inherits="ClienteNW.cargaMasiva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
        .auto-style2 {
            height: 15px;
        }
        .auto-style3 {
            height: 21px;
        }
    .auto-style4 {
        height: 28px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" ForeColor="Black">Nickname</asp:Label>
            </td>
            <td class="auto-style3">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2">
                </td>
            <td class="auto-style2">
                </td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style3">
            </td>
            <td class="auto-style3">

                        <asp:Button ID="Button1" runat="server" Text="Cargar Usuarios" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style1">

                        <asp:Button ID="Button2" runat="server" Text="Cargar Juego Actual" OnClick="Button2_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style4">
                </td>
            <td class="auto-style4">

                        <asp:Button ID="Button3" runat="server" Text="Cargar Lista Juegos" OnClick="Button3_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style1">

                        <asp:Button ID="Button4" runat="server" Text="Cargar Tablero" OnClick="Button4_Click" />
            </td>
        </tr>
 
         <tr>
                    <td class="auto-style7">
                &nbsp;</td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td class="auto-style9">

                        &nbsp;</td>
                
                </tr>

        </table>
</asp:Content>
