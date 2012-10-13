<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Divisiones.aspx.cs" Inherits="Web.Divisiones"  MasterPageFile="~/moebiusWeb.Master"%>
<asp:Content ContentPlaceHolderID="cphPrincipal" ID="DivisionesPH" runat="server">    
    <div>
    
        <h1>Itinerarios</h1>
        
        <br>                   
        Divisi&oacute;n:
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
        &nbsp;&nbsp;<asp:LinkButton ID="lnkExportExcel" Text="Exportar a Excel"  runat="server" onclick="Exportar_Click"></asp:LinkButton>         
        <br /><br />
        
        <asp:GridView ID="grdDivision" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" 
            GridLines="Horizontal" Height="70px"  Width="70%">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="Zona" HeaderText="Zona" ReadOnly="True" SortExpression="idDivisionCflex" />
                <asp:BoundField DataField="Desde" HeaderText="Desde" ReadOnly="True" SortExpression="idDivisionCflex" />
                <asp:BoundField DataField="Hasta" HeaderText="Hasta" ReadOnly="True" SortExpression="idDivisionCflex" />
            </Columns>
        </asp:GridView>
        
        <br />
        <asp:GridView ID="grdDivisionDetalle" runat="server" BackColor="White" 
            BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Horizontal" AutoGenerateColumns="False" Width="70%">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="Estacion" HeaderText="Estación" ReadOnly="True" SortExpression="idDivisionCflex" />
                <asp:BoundField DataField="ProgresivaPoste" HeaderText="ProgresivaPoste" 
                    ReadOnly="True" SortExpression="idDivisionCflex" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="ProgresivaDivision" HeaderText="Progresiva división" 
                    ReadOnly="True" SortExpression="idDivisionCflex" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Disntacia" HeaderText="Distancia" ReadOnly="True" 
                    SortExpression="idDivisionCflex" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Tiempo" HeaderText="Tiempo min. carga" 
                    ReadOnly="True" SortExpression="idDivisionCflex" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Long" HeaderText="Long. vía segunda" ReadOnly="True" 
                    SortExpression="idDivisionCflex" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="ComNavegacion" HeaderText="Comunicación navegación" 
                    ReadOnly="True" SortExpression="idDivisionCflex" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="ComBase" HeaderText="Comunicación base" 
                    ReadOnly="True" SortExpression="idDivisionCflex" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="EstacionCflex" HeaderText="Estacion Cflex" ReadOnly="True" SortExpression="idDivisionCflex" />
                <asp:BoundField DataField="EstacionSap" HeaderText="Estacion Sap" ReadOnly="True" SortExpression="idDivisionCflex" />
            </Columns>
        </asp:GridView>
    
        <asp:LinqDataSource ID="linqDivisionDetalle" runat="server" 
            ContextTypeName="Datos.DC" 
            Select="new (ProgresivaPoste, ProgresivaDivision, Estaciones, TiempoCarga, ComunicacionNavegacion, ComunicacionBase, Distancia)" 
            TableName="Divisiones_Detalle" Where="idDivision == @idDivision" 
            OrderBy="ProgresivaDivision">
            <WhereParameters>
                <asp:ControlParameter ControlID="ddlDivisiones" Name="idDivision" 
                    PropertyName="SelectedValue" Type="Int32" />
            </WhereParameters>
        </asp:LinqDataSource>
    
        <br />
        
        <asp:DetailsView ID="dtvObservaciones" runat="server" AutoGenerateRows="False" 
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" 
            GridLines="Horizontal" Height="50px" Width="125px">            
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Fields>
                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" ReadOnly="True" SortExpression="idDivisionCflex" />
                <asp:BoundField DataField="Reglamento" HeaderText="Reglamento" ReadOnly="True" SortExpression="idDivisionCflex" />
            </Fields>
            
        </asp:DetailsView>
        <br />
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" DataSourceID="linqCirculaciones" GridLines="Horizontal"  Width="70%">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <Columns>
                <asp:BoundField DataField="ProgresivaDesde" HeaderText="Progresiva Desde" 
                    ReadOnly="True" SortExpression="ProgresivaDesde" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="ProgresivaHasta" HeaderText="Progresiva Hasta" 
                    ReadOnly="True" SortExpression="ProgresivaHasta" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripci&oacute;n" 
                    ReadOnly="True" SortExpression="Descripcion" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
        <asp:LinqDataSource ID="linqCirculaciones" runat="server" 
            ContextTypeName="Datos.DC" 
            Select="new (ProgresivaDesde, ProgresivaHasta, Descripcion)" 
            TableName="Circulaciones" Where="idDivision == @idDivision" 
            OrderBy="ProgresivaDesde">
            <WhereParameters>
                <asp:ControlParameter ControlID="ddlDivisiones" Name="idDivision" 
                    PropertyName="SelectedValue" Type="Int32" />
            </WhereParameters>
        </asp:LinqDataSource>
    </div>
</asp:Content>