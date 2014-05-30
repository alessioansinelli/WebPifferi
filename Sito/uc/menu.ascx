<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="uc_menu" %>
<ul class="nav navbar-nav">
    <li class="mnuHome <% if (SelectedMenu == "mnuHome"){Response.Write("active");} %>"><a href="/">Home</a></li>
    <li class="mnuStoria <% if (SelectedMenu == "mnuStoria"){Response.Write("active");} %>"><a href="/lanostrastoria.aspx">La nostra Storia</a></li>
    <li class="mnuStrumenti <% if (SelectedMenu == "mnuStrumenti") { Response.Write("active"); } %>"><a href="/strumenti.aspx">Gli strumenti</a></li>
    <li class="mnuNotizie <% if (SelectedMenu == "mnuNotizie"){Response.Write("active");} %>"><a href="/news.aspx">Notizie</a></li>
    <li class="mnuFotoVideo <% if (SelectedMenu == "mnuFotoVideo"){Response.Write("active");} %>"><a href="/fotovideo.aspx">Foto e Video</a></li>    
    <li class="mnuContatti <% if (SelectedMenu == "mnuContatti") { Response.Write("active"); } %>" ><a href="/contatti.aspx">Contatti</a></li>
</ul>
