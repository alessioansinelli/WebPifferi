<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucimage.ascx.cs" Inherits="be_uc_ucimage" %>
<div>
    <h2><% = TitoloOggettoParent %></h2>
</div>
<div>
    <span><b>Titolo Immagine</b></span><br />
    <asp:TextBox ID="txtTitoloImmagine" runat="server" CssClass="txtTitolo"></asp:TextBox>
</div>
<div>
    <span><b>Sotto Titolo :</b></span><br />
    <asp:TextBox ID="txtSottoTitoloImmagine" runat="server" Rows="3" TextMode="MultiLine" CssClass="txtSottoTitolo"></asp:TextBox>
</div>
<div>
    <span><b>Seleziona File Immagine :</b></span><br />
    <asp:FileUpload ID="uplImage" runat="server" />
</div>
<div class="btnControllo">
<asp:Button title="Salva" runat="server" ID="btnSalva" Text="Salva" OnClick="btnSalva_Click" CssClass="bottone" />
<asp:Button title="Annulla" runat="server" ID="btnAnnulla" Text="Annulla" onclick="btnAnnulla_Click"  CssClass="bottone" />
</div>
<div>
    <asp:GridView ID="grdImmagini" runat="server" 
    EmptyDataText="Non sono presenti notizie" AutoGenerateColumns="False" 
    DataKeyNames="ID" onrowcommand="RowCommand">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" />
        <asp:ButtonField ButtonType="Link" CommandName="up" HeaderText="Su" ShowHeader="True" Text="Su" ItemStyle-HorizontalAlign="Center" >
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:ButtonField>
        <asp:ButtonField ButtonType="Link" CommandName="down" HeaderText="Giù" ShowHeader="True" Text="Giù" ItemStyle-HorizontalAlign="Center" >
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:ButtonField>
        <asp:BoundField DataField="Titolo" HeaderText="TITOLO" />
        <asp:BoundField DataField="SottoTitolo"  HeaderText="SOTTO TITOLO" />
        <asp:BoundField DataField="DataInserimento"  HeaderText="DATA CREAZIONE" />
        <asp:ButtonField ButtonType="Link" CommandName="elimina" HeaderText="Elimina" ShowHeader="True" Text="Elimina" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="eliminanews">
<ControlStyle CssClass="eliminanews"></ControlStyle>

            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:ButtonField>
        <asp:TemplateField HeaderText="Anteprima">
            <ItemTemplate><img src="<% = ResolveUrl(Business.ConstWrapper.CartellaFoto) %><%# DataBinder.Eval(Container.DataItem, "Percorso").ToString() %>w2<%# DataBinder.Eval(Container.DataItem, "Estensione").ToString() %>" alt="<%# DataBinder.Eval(Container.DataItem, "Titolo").ToString() %>"/></ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</div>
