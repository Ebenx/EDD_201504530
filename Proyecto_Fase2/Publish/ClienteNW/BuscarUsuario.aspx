<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="BuscarUsuario.aspx.cs" Inherits="ClienteNW.BuscarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

                        <asp:Button ID="Button2" runat="server" Text="Buscar" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5">
                &nbsp;</td>
            <td class="auto-style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">
                <asp:Label ID="Label4" runat="server" ForeColor="Black">Nickname</asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextNickname2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">
                <asp:Label ID="Label1" runat="server" ForeColor="Black">Password</asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextPass" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5">
                <asp:Label ID="Label5" runat="server" ForeColor="Black">Email</asp:Label>
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

                        &nbsp;</td>
                
                </tr>

        </table>
    </asp:Content>
