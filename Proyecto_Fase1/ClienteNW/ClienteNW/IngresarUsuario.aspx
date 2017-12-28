<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="IngresarUsuario.aspx.cs" Inherits="ClienteNW.IngresarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 86px;
            height: 26px;
        }
        .auto-style2 {
            width: 149px;
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
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
                <asp:TextBox ID="TextNick" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5">
                <asp:Label ID="Label1" runat="server" ForeColor="Black">Password</asp:Label>
            </td>
            <td class="auto-style6">
                <asp:TextBox ID="TextPass" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5">
                <asp:Label ID="Label4" runat="server" ForeColor="Black">Email</asp:Label>
            </td>
            <td class="auto-style6">
                <asp:TextBox ID="TextEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5">
                <asp:Label ID="Label3" runat="server" ForeColor="Black">Conectado</asp:Label>
            </td>
            <td class="auto-style6">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="1">SI</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
 
         <tr>
                    <td class="auto-style7">
                &nbsp;</td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td class="auto-style9">

                        <asp:Button ID="Button1" runat="server" Text="Crear" OnClick="Button1_Click" />
                    </td>
                
                </tr>

        </table>
</asp:Content>
