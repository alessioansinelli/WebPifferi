<%@ Control Language="C#" AutoEventWireup="true" CodeFile="notizia.ascx.cs" Inherits="uc.UcNotizia" %>
<%@ Register Src="~/uc/slider.ascx" TagPrefix="uc1" TagName="slider" %>

<div class="newsdate vertical">
    <span class="giorno"><% = Giorno %></span>
    <span class="mese"><% = Mese %></span>    
    <span class="anno"><% = Anno %></span>        
</div>
<h1><% = TitoloNotizia %></h1>
<div class="sottotitolo"><% = SottoTitolo %></div>
<uc1:slider runat="server" ID="slider" />
<div class="testo"><% = TestoNotizia %></div>