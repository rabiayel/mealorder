<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sepetim.aspx.cs" Inherits="MealOrder_Web.Sepetim" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Sepetteki Ürünler"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" Width="550px" DataKeyNames="UrunID" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating">
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
                            
                            
                            <asp:TemplateField HeaderText="UrunID" Visible="True">
                                <ItemTemplate>
                                <asp:Label ID="lblUrunID"  runat="server" Text='<%#Eval("yemekid") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="UrunAdi" Visible="true">
                                <ItemTemplate>
                                   <asp:Label ID="lblUrunAdi"  runat="server" Text='<%#Eval("y_adi") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                          <asp:TemplateField HeaderText="Adet">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Width="40px" 
                        Text='<%# Eval("Adet") %>'></asp:TextBox>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update">Güncelle</asp:LinkButton>
                </ItemTemplate>

                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Width="40px" 
                        Text='<%# Eval("Adet") %>'></asp:TextBox>

                              </EditItemTemplate>
            </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Fiyat" Visible="true">
                                <ItemTemplate>
                                  <asp:Label ID="lblFiyat"  runat="server" Text='<%#Eval("Fiyat") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                          <asp:TemplateField>
                                <ItemTemplate>
                                    TL
                                </ItemTemplate>
                            </asp:TemplateField>
                       <asp:TemplateField>
                           <ItemTemplate>
                               <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete">Ürünü Kaldır</asp:LinkButton>
                           </ItemTemplate>
                       </asp:TemplateField>



                 </Columns>

                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Toplam tutar"></asp:Label>
&nbsp;=
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Alışverişe devam et" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Siparişi Onayla" />
                </td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    
   
    </form>
</body>
</html>
