<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Autos.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Proyecto_Ac.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cuerpoHTML" runat="server">


    <asp:GridView ID="GridAutos" 
        runat="server" 
        CellPadding="4" 
        ForeColor="#333333" 
        GridLines="None" 
        AutoGenerateColumns="False"
        DataKeyNames = "IDCARRO" 
        OnRowCommand="GridAutos_RowCommand" 
        OnRowEditing="GridAutos_RowEditing" 
        OnRowCancelingEdit="GridAutos_RowCancelingEdit" 
        OnRowUpdating="GridAutos_RowUpdating" 
        OnRowDeleting="GridAutos_RowDeleting" 
        ShowHeaderWhenEmpty="false"
        ShowFooter ="True"
        >
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />

        <Columns>
                    <asp:TemplateField HeaderText="MARCA">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("MARCA")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMARCA" Text='<%# Eval("MARCA")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtMARCAPie" Text='<%# Eval("MARCA")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="MODELO">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("MODELO")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMODELO" Text='<%# Eval("MODELO")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtMODELOPie" Text='<%# Eval("MODELO")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PAIS">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("PAIS")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPAIS" Text='<%# Eval("PAIS")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtPAISPie" Text='<%# Eval("PAIS")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="COSTO">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("COSTO")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCOSTO" Text='<%# Eval("COSTO")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCOSTOPie" Text='<%# Eval("COSTO")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                           <asp:ImageButton ImageUrl="~/Img/editar.png" runat="server" CommandName="Edit" ToolTip="Editar" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/Img/delete2.png" runat="server" CommandName="Delete" ToolTip="Borrar" Width="20px" Height="20px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Img/guardar.png" runat="server" CommandName="Update" ToolTip="Guardar" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/Img/cancel2.png"   runat="server" CommandName="Cancel" ToolTip="Cancelar" Width="20px" Height="20px" />                           
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/Img/nuevo.png"   runat="server" CommandName="AddNew" ToolTip="Nuevo" Width="20px" Height="20px" />                           
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
    </asp:GridView>

            <br/>
            <br/>
            <asp:Label runat="server" ID="lblExito" ForeColor="Green"></asp:Label>
            <asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label>

        


</asp:Content>
