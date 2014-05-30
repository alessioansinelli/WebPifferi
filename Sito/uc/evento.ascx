<%@ Control Language="C#" AutoEventWireup="true" CodeFile="evento.ascx.cs" Inherits="uc_evento" %>
<%@ Register src="Photogallery.ascx" tagname="Photogallery" tagprefix="uc1" %>
<h1><% = TitoloNotizia %></h1>
<div class="newsdate">Pubblicata : <% = DataInserimento %></div>
<div class="sottotitolo"><% = SottoTitolo %></div>
<div class="testo"><% = TestoNotizia %></div>
<div class="pgnews">
<uc1:Photogallery ID="Photogallery1" runat="server" TipoOggetto="Eventi" />
</div>