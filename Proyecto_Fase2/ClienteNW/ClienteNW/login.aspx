<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ClienteNW.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 



     <body>
        <div class="row-top">
            <div id="includedContent"></div>
        </div>


        <div class="body"></div>
        <div class="grad">
            
            
         
         </div>
        <div class="header">
            <div>Naval<span>Wars</span></div>
        </div>
        <br>
        <div class="login">
            <form  name="formulario" method="get" >
                <asp:TextBox ID="TextUser" runat="server" placeholder="nickname*" required></asp:TextBox><br>
                <asp:TextBox ID="TextPass" runat="server" placeholder="pass*" required></asp:TextBox><br>
                
                <asp:Button ID="Button1" runat="server" Text="Ingresar" OnClick="Button1_Click" />
                    </form>
            <form action="registrarUsuario.jsp" name="formRegistro" method="get" >
                 
            </form>
        </div>



    </body>



</asp:Content>
