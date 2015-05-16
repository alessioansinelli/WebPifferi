<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Photogallery.ascx.cs"
    Inherits="uc.UcPhotogallery" %>
<%@ Import Namespace="Business.Oggetti" %>
<%@ Import Namespace="Business" %>
<%  if (!HideTitle)
    { %>
<div class="newsdate vertical">
    <span class="giorno"><% = Giorno %></span>
    <span class="mese"><% = Mese %></span>
    <span class="anno"><% = Anno %></span>
</div>
<h1><% = Galleria.Titolo %></h1>
<div class="testo"><% = Galleria.SottoTitolo%></div>
<% }  
%>
<div class="photogallery">
    <asp:Repeater ID="repFoto" runat="server">
        <HeaderTemplate>
            <div id="full-width-gallery-slider" class="royalSlider heroSlider rsMinW">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="rsContent">
                <a class="rsImg" href="<%# Utility.GetPathPhoto(((OggettoFoto)Container.DataItem), "w12") %>">
                    <img src="<%# Utility.GetPathPhoto(((OggettoFoto)Container.DataItem), "w3") %>" class="rsTmb" />
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

<div class="testo"><% = TestoGallery %></div>
<% } %>

