<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Photogallery.ascx.cs"
    Inherits="uc_Photogallery" %>
<%  if (!HideTitle)
    { %>
<div class="newsdate vertical">
    <span class="giorno"><% = Giorno %></span>
    <span class="mese"><% = Mese %></span>
    <span class="anno"><% = Anno %></span>
</div>
<h1><% = _TitoloGallery %></h1>
<div class="testo"><% = _SottoTitoloGallery%></div>
<% }  
%>
<div class="photogallery">
    <asp:Repeater ID="repFoto" runat="server">
        <HeaderTemplate>
            <div id="full-width-gallery-slider" class="royalSlider heroSlider rsMinW">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="rsContent">
                <a class="rsImg" href="<%# Utility.getPathPhoto(((Oggetti.OggettoFoto)Container.DataItem), "w12") %>">
                    <img src="<%# Utility.getPathPhoto(((Oggetti.OggettoFoto)Container.DataItem), "w3") %>" class="rsTmb" />
                </a>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</div>
<% if (!HideTitle)
   { %>
<div id="divPaginazione" runat="server" class="pagfoto"></div>

<div class="testo"><% = _TestoGallery%></div>
<% } %>

