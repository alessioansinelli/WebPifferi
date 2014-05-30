<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Photogallery.ascx.cs"
    Inherits="uc_Photogallery" %>
<% if (ShowOnlyPhoto != true)
   {%>
<% if (TipoOggetto != TipoOggetto.News)
   { %>
<h1><% = _TitoloGallery %></h1>
<div class="gallerydate">
    <span>Pubblicata : <% = _DataPubblicazione %></span>
    <% if (ShowShare == true)
       { %>
    <a class="share" href="http://www.facebook.com/sharer.php?u=www.mercenari.it/<% = _ShowShareUrl %>=<% = Request["id"].ToString() %>&amp;t=<% = _TitoloGallery %>" target="blank">
        <img src="/images/facebook_share.png" alt="condividi su facebook" /></a>
    <% } %>
</div>

<div><% = _SottoTitoloGallery%></div>
<div><% = _TestoGallery%></div>
<% }
   else if (Galleria.Foto.Length > 0)
   { %>
<h2>Immagini Collegate</h2>
<% }
   }
%>
<asp:Repeater ID="repFoto" runat="server">
    <HeaderTemplate>
        <headertemplate>
            <div id="full-width-gallery-slider" class="royalSlider heroSlider rsMinW">
        </headertemplate>
    </HeaderTemplate>
    <ItemTemplate>
        <div class="rsContent">
            <a class="rsImg" href="<%# Utility.getPathPhoto(((Oggetti.OggettoFoto)Container.DataItem), "w12") %>">image description<img src="<%# Utility.getPathPhoto(((Oggetti.OggettoFoto)Container.DataItem), "w3") %>" class="rsTmb" /></a>
            <%--<div class="infoBlock infoBlockLeftBlack rsABlock">
                <h3><%# DataBinder.Eval(Container.DataItem, "Titolo")%></h3>
                <p><%# DataBinder.Eval(Container.DataItem, "SottoTitolo")%></p>
            </div>--%>
        </div>
    </ItemTemplate>

    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>
<div id="divPaginazione" runat="server" class="pagfoto">
</div>

