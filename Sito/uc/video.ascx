<%@ Control Language="C#" AutoEventWireup="true" CodeFile="video.ascx.cs" Inherits="uc.UcVideo" %>
<%@ Register src="Photogallery.ascx" tagname="Photogallery" tagprefix="uc1" %>
<%@ Register Src="~/uc/slider.ascx" TagPrefix="uc1" TagName="slider" %>

<div class="newsdate vertical">
    <span class="giorno"><% = Giorno %></span>
    <span class="mese"><% = Mese %></span>    
    <span class="anno"><% = Anno %></span>        
</div>
<h1><% = TitoloNotizia %></h1>
<div class="videoWrapper" id="video">
    <% = SottoTitolo %>
</div>
<div class="testo"><% = TestoNotizia %></div>