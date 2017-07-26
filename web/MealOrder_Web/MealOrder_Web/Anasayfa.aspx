<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits="MealOrder_Web.Anasayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 166px;
        }
        .auto-style3 {
            width: 263px;
        }
        .auto-style4 {
            width: 84px;
        }
        .auto-style5 {
            width: 72px;
        }
        .auto-style6 {
            width: 73px;
        }
        .auto-style7 {
            width: 166px;
            height: 72px;
        }
        .auto-style8 {
            height: 72px;
        }
        .auto-style9 {
            width: 263px;
            height: 72px;
        }
        .auto-style10 {
            width: 84px;
            height: 72px;
        }
        .auto-style11 {
            width: 73px;
            height: 72px;
        }
        .auto-style12 {
            width: 72px;
            height: 72px;
        }
        .auto-style13 {
            width: 166px;
            height: 55px;
        }
        .auto-style14 {
            width: 263px;
            height: 55px;
        }
        .auto-style15 {
            width: 84px;
            height: 55px;
        }
        .auto-style16 {
            width: 73px;
            height: 55px;
        }
        .auto-style17 {
            width: 72px;
            height: 55px;
        }
        .auto-style18 {
            height: 55px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style6">
                    <asp:Label ID="Label2" runat="server" Text="Hoşgeldiniz"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                    <%=Session["m_adi"]%>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Panel ID="Panel1" runat="server">
                        <a href="Sepetim.aspx">Sepetim</a>
                    </asp:Panel>
                </td>
                <td class="auto-style6">
                    <asp:Panel ID="Panel2" runat="server">
                        <a href="Siparisim.aspx">Siparisim</a>
                    </asp:Panel>
                </td>
                <td class="auto-style5">
                    <asp:Panel ID="Panel3" runat="server">
                        <a href="Default.aspx">Çıkıs</a>
                    </asp:Panel>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                 <td class="auto-style13">
                    <asp:Label ID="Label5" runat="server" Text="Restoran Seç"></asp:Label>
                </td>
                <td class="auto-style13">
                    <asp:Label ID="Label1" runat="server" Text="Kategori Seç"></asp:Label>
                </td>
                <td class="auto-style13">
                    <asp:Label ID="Label4" runat="server" Text="Opsiyon Seç"></asp:Label>
                </td>
                <td class="auto-style14"></td>
                <td class="auto-style15"></td>
                <td class="auto-style16"></td>
                <td class="auto-style17"></td>
                <td class="auto-style18"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:DropDownList ID="DropDownList3" runat="server" Height="23px" Width="151px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                    </asp:DropDownList>
                     
                </td>
                <td class="auto-style7">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" Width="151px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                     
                </td>
                <td class="auto-style8"><asp:DropDownList ID="DropDownList2" runat="server" Height="23px" Width="151px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td class="auto-style9"></td>
                <td class="auto-style10"></td>
                <td class="auto-style11"></td>
                <td class="auto-style12"></td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" Width="470px" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AlternatingRowStyle-BackColor="White">
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#594B9C" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#33276A" />


                        <Columns>


                             <asp:TemplateField>

                                <ItemTemplate>
                                   <a href="SepeteEkle.aspx?UrunID=<%#Eval("yemekid") %>"> 
                                Sepete Ekle</a><br />
                                </ItemTemplate>
                            </asp:TemplateField>




                         

                            <asp:BoundField DataField="y_adi" HeaderText="UrunAdi" SortExpression="y_adi" />

                            <asp:BoundField DataField="y_aciklama" HeaderText="Aciklama" SortExpression="y_aciklama" />
                            <asp:BoundField DataField="y_fiyati" HeaderText="Fiyat" SortExpression="y_fiyati" />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    TL
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField>
                                
                                <ItemTemplate>
                                    <asp:Image ID="Resim" runat="server" ImageUrl='<%# Eval("y_resmi") %>'    Height="160px"  Width="160px"/>
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>



                    </asp:GridView>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    
    </form>
</body>
</html>
