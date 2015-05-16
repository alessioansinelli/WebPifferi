<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucoggetto.ascx.cs" Inherits="be.uc.BeUcUcoggetto" %>
<%@ Register Assembly="Moxiecode.TinyMCE" Namespace="Moxiecode.TinyMCE.Web" TagPrefix="TinyMCE" %>
<%@ Register Src="ucimage.ascx" TagName="ucimage" TagPrefix="uc1" %>
<div id="dettaglionews" runat="server">
    <div>
        <h2>Gestione <% = TipoOggetto %></h2>
    </div>
    <div>
        <ul><asp:LinkButton runat="server" ID="insImmagine" Text="Gestisci Immagini" OnClick="insImmagine_Click"></asp:LinkButton></ul>
    </div>
    <div class="form-group">
        <label for="txtTitolo"><b>Titolo :</b></label>
        <asp:TextBox ID="txtTitolo" runat="server" CssClass="txtTitolo form-control" placeholder="Inserisci il titolo..." AutoPostBack="True" OnTextChanged="TitoloChanged"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="slug">Slug :</label>
        <asp:TextBox ID="txtSlug" runat="server" CssClass="txtSlug form-control" placeholder="Inserisci slug..."></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtSottoTitolo"><b>Sotto Titolo :</b></label>
        <asp:TextBox ID="txtSottoTitolo" runat="server" Rows="5" TextMode="MultiLine" CssClass="txtSottoTitolo form-control"></asp:TextBox>
    </div>
    <div class="form-group txtContainer">
        <span><b>Testo :</b></span>
        <TinyMCE:TextArea ID="txtTesto" runat="server" theme="advanced" theme_advanced_toolbar_location="top" theme_advanced_toolbar_align="left" theme_advanced_statusbar_location="bottom" theme_advanced_resizing="true" Height="400px" CssClass="form-control" />
    </div>
    <div class="btnControllo">
        <asp:Button title="Salva" runat="server" ID="btnSalva" Text="Salva" OnClick="btnSalva_Click" CssClass="bottone btn btn-default" />
        <asp:Button title="Annulla" runat="server" ID="btnAnnulla" Text="Annulla" OnClick="btnAnnulla_Click" CssClass="bottone btn btn-default" />
    </div>
</div>
<div id="gestioneimmagini" runat="server" visible="false">
    <uc1:ucimage ID="imgNotizia" runat="server" />
</div>
