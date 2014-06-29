<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="be_uc_menu" %>
<ul class="nav navbar-nav">
    <li class="mnuNews <% if (SelectedMenu == "Notizie") { Response.Write("active"); } %>"><a href="/be/news.aspx">Gestione Notizie</a></li>
    <li class="mnuNews <% if (SelectedMenu == "PhotoGallery") { Response.Write("active"); } %>"><a href="/be/photogallery.aspx">Gestione Photogallery</a></li>
    <li class="mnuNews <% if (SelectedMenu == "Video") { Response.Write("active"); } %>"><a href="/be/video.aspx">Gestione Video</a></li>
</ul>
