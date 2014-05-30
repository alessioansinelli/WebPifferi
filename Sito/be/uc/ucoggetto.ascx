<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucoggetto.ascx.cs" Inherits="be_uc_ucoggetto" %>
<%@ Register Assembly="Moxiecode.TinyMCE" Namespace="Moxiecode.TinyMCE.Web" TagPrefix="TinyMCE" %>
<%@ Register src="ucimage.ascx" tagname="ucimage" tagprefix="uc1" %>
<div id="dettaglionews" runat="server">
<div>
  <ul><asp:LinkButton runat="server" ID="insImmagine" Text="Gestisci Immagini" onclick="insImmagine_Click"></asp:LinkButton></ul>
</div>
<div>
  <h2>Gestione <% = TipoOggetto %></h2>
</div>
<div>
  <span><b>Titolo :</b></span><br />
  <asp:TextBox ID="txtTitolo" runat="server" CssClass="txtTitolo"></asp:TextBox>
</div>
<div>
  <span><b>Sotto Titolo :</b></span><br />
  <asp:TextBox ID="txtSottoTitolo" runat="server" Rows="3" TextMode="MultiLine" CssClass="txtSottoTitolo"></asp:TextBox>
</div>
<div class="txtContainer">
    <span><b>Testo :</b></span><br />
    <TinyMCE:TextArea ID="txtTesto" runat="server" theme="advanced" theme_advanced_toolbar_location="top"
        theme_advanced_toolbar_align="left" theme_advanced_statusbar_location="bottom"
        theme_advanced_resizing="true" width="550px" height="250px" />
</div>
	<div class="btnControllo">
		<asp:Button title="Salva" runat="server" ID="btnSalva" Text="Salva" OnClick="btnSalva_Click" CssClass="bottone" />
		<asp:Button title="Annulla" runat="server" ID="btnAnnulla" Text="Annulla" onclick="btnAnnulla_Click"  CssClass="bottone" />
	</div>
</div>
<div id="gestioneimmagini" runat="server" visible="false">
    <uc1:ucimage ID="imgNotizia" runat="server"  />
</div>
