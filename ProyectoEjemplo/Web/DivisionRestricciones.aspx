<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DivisionRestricciones.aspx.cs" Inherits="Web.DivisionRestricciones" MasterPageFile="~/moebiusWeb.Master" %>
<asp:Content ContentPlaceHolderID="cphPrincipal" ID="DivisionRestriccionesPH" runat="server">    
    <h1>Tramos de velocidad y PAN</h1>
    <br>
    <div>
        <table><tr>
        <td><b>Divisi&oacute;n:</b> &nbsp;
            <asp:DropDownList ID="ddlDivisiones" runat="server" 
                DataSourceID="linqDivisiones" DataTextField="Nombre" 
                DataValueField="idDivision" 
                onselectedindexchanged="ddlDivisiones_SelectedIndexChanged" 
                AutoPostBack="True" AppendDataBoundItems="true">
                <asp:ListItem Text="Seleccione" Value="0" Selected="True"></asp:ListItem>
            </asp:DropDownList>
            <asp:LinqDataSource ID="linqDivisiones" runat="server" 
                ContextTypeName="Datos.DC" TableName="Divisiones" OrderBy="Nombre">
            </asp:LinqDataSource>
        </td><td>
            <asp:LinkButton ID="lnkExcel" runat="server" onclick="lnkExcel_Click" Enabled="false">Exportar a excel</asp:LinkButton></td></tr></table>
        <br />
        <br /><h3>Velocidades:</h3>
        <br />
        <asp:GridView ID="grdVelocidades" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" DataKeyNames="idVelocidad" DataSourceID="linqVelocidades" 
            GridLines="Horizontal" Width="700px">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <EmptyDataTemplate>No hay informaci&oacute;n cargada</EmptyDataTemplate>
            <Columns>
                <asp:BoundField DataField="ProgresivaDesde" HeaderText="Progresiva Desde" 
                    SortExpression="ProgresivaDesde" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="ProgresivaHasta" HeaderText="Progresiva Hasta" 
                    SortExpression="ProgresivaHasta" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="VelocidadPasajeros" 
                    HeaderText="Velocidad con Pasajeros" SortExpression="VelocidadPasajeros" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="VelocidadCarga" HeaderText="Velocidad con Carga" 
                    SortExpression="VelocidadCarga" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Motivo" HeaderText="Motivo" 
                    SortExpression="Motivo" />
                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" 
                    SortExpression="Observaciones" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        
        </asp:GridView>    
        <asp:LinqDataSource ID="linqVelocidades" runat="server" 
            ContextTypeName="Datos.DC" TableName="Velocidades" 
            
            Where="idDivision == @idDivision &amp;&amp; idTipoRestriccion == @idTipoRestriccion" 
            OrderBy="ProgresivaDesde">
            <WhereParameters>
                <asp:ControlParameter ControlID="ddlDivisiones" Name="idDivision" 
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="idTipoRestriccion" Type="Int32" />
            </WhereParameters>
        </asp:LinqDataSource>
        <br />
        <h3>Pasos a Nivel:</h3>
        <br />
        <asp:GridView ID="grdPAN" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" DataSourceID="linqPAN" GridLines="Horizontal"  Width="700px">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <EmptyDataTemplate>No hay informaci&oacute;n cargada</EmptyDataTemplate>
            <Columns>
                <asp:BoundField DataField="ProgresivaDesde" HeaderText="ProgresivaDesde" 
                    ReadOnly="True" SortExpression="ProgresivaDesde" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="ProgresivaHasta" HeaderText="ProgresivaHasta" 
                    ReadOnly="True" SortExpression="ProgresivaHasta" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="VelocidadPasajeros" HeaderText="VelocidadPasajeros" 
                    ReadOnly="True" SortExpression="VelocidadPasajeros" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="VelocidadCarga" HeaderText="VelocidadCarga" 
                    ReadOnly="True" SortExpression="VelocidadCarga" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Motivo" HeaderText="Motivo" ReadOnly="True" 
                    SortExpression="Motivo" />
                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" 
                    ReadOnly="True" SortExpression="Observaciones" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
        <asp:LinqDataSource ID="linqPAN" runat="server" ContextTypeName="Datos.DC" 
            Select="new (ProgresivaDesde, ProgresivaHasta, VelocidadPasajeros, VelocidadCarga, Motivo, Observaciones)" 
            TableName="Velocidades" 
            
            Where="idDivision == @idDivision &amp;&amp; idTipoRestriccion == @idTipoRestriccion" 
            OrderBy="ProgresivaDesde">
            <WhereParameters>
                <asp:ControlParameter ControlID="ddlDivisiones" Name="idDivision" 
                    PropertyName="SelectedValue" Type="Int32" DefaultValue="0" />
                <asp:Parameter DefaultValue="2" Name="idTipoRestriccion" Type="Int32" />
            </WhereParameters>
        </asp:LinqDataSource>
        <br />
        <h3>Remolque y frenado:</h3>
        <br />
        <asp:GridView ID="grdRemolqueFrenado" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" DataSourceID="linqRemolqueyFrenado" GridLines="Horizontal"  Width="700px">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C"/>
            <EmptyDataTemplate>No hay informaci&oacute;n cargada</EmptyDataTemplate>
            <Columns>
                <asp:TemplateField HeaderText="Desde">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Estaciones.Nombre") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                    
                <asp:TemplateField HeaderText="Hasta">
                    <ItemTemplate>
                        <asp:Label ID="Label12" runat="server" Text='<%# Eval("Estaciones1.Nombre") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>            
                <asp:BoundField DataField="RemolqueAscendente" HeaderText="Remolque ascendente" 
                    ReadOnly="True" SortExpression="RemolqueAscendente" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="FrenadoAscendente" HeaderText="Frenado ascendente" 
                    ReadOnly="True" SortExpression="FrenadoAscendente" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="RemolqueDescendente" 
                    HeaderText="Remolque descendente" ReadOnly="True" 
                    SortExpression="RemolqueDescendente" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="FrenadoDescendente" HeaderText="Frenado descendente" 
                    ReadOnly="True" SortExpression="FrenadoDescendente" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
        <asp:LinqDataSource ID="linqRemolqueyFrenado" runat="server" 
            ContextTypeName="Datos.DC" 
            Select="new (RemolqueAscendente, FrenadoAscendente, RemolqueDescendente, FrenadoDescendente, Estaciones, Estaciones1)" 
            TableName="Remolque_Frenado" Where="idDivision == @idDivision" 
            OrderBy="idEstacionDesde">
            <WhereParameters>
                <asp:ControlParameter ControlID="ddlDivisiones" Name="idDivision" 
                    PropertyName="SelectedValue" Type="Int32" />
            </WhereParameters>
        </asp:LinqDataSource>
    </div>
</asp:Content>