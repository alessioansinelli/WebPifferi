<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="uc_menu" %>
<ul class="nav navbar-nav">
    <li class="mnuHome <% if (SelectedMenu == "mnuHome"){Response.Write("active");} %>"><a href="/">Home</a></li>
    <li class="mnuStoria <% if (SelectedMenu == "mnuStoria"){Response.Write("active");} %>"><a href="/storia">La nostra Storia</a></li>
    <li class="mnuStrumenti dropdown <% if (SelectedMenu == "mnuStrumenti") { Response.Write("active"); } %>">
        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Gli strumenti<span class="caret"></span></a>
        <ul class="dropdown-menu" role="menu">
            <li><a href="#">Panoramica</a></li>
            <li><a href="/strumenti/ilpiffero">La costruzione del Piffero</a></li>
            <li><a href="#">La costruzione del Tamburo</a></li>           
          </ul>
    </li>
    <li class="mnuNotizie <% if (SelectedMenu == "mnuNotizie"){Response.Write("active");} %>"><a href="/news">Notizie</a></li>
    <li class="mnuFotoVideo <% if (SelectedMenu == "mnuFotoVideo"){Response.Write("active");} %>"><a href="/fotovideo">Foto e Video</a></li>    
    <li class="mnuContatti <% if (SelectedMenu == "mnuContatti") { Response.Write("active"); } %>" ><a href="/contatti">Contatti</a></li>
</ul>
