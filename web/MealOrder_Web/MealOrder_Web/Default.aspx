<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MealOrder_Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>
    body{
    background-color:#b3f7f7; /*tüm arka plan*/
    font-family: 'Trebuchet MS',Arial,'Colonna MT';    
}

.giris{
    width:200px;
    height:200px;
    margin-left:700px;
    margin-top:300px;
    padding:17.5px;
    background-color: #fcc0c0;
}

</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="giris">
        <table>
            <tr>
                <td><asp:Label ID="lblmail"  runat="server" Text="Kullanıcı Adınız:" style="margin-top:15px;color:white;"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtmail" runat="server" Height="35px" Width="198px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblsifre" runat="server" Text="Şifreniz:" style="margin-top:15px;color:white;" ></asp:Label></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtsifre" runat="server" Height="40px" Width="195px"></asp:TextBox></td>
            </tr>
            <tr>
                <td> <asp:Button ID="btngiris" runat="server" Text="Login" Height="49px" Width="101px" style="background:#ff0000; color:white;margin-top:15px;margin-left:40px;" OnClick="btngiris_Click" /></td>
            </tr>
            <tr>
                <td> <asp:Label ID="lblsonuc" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
