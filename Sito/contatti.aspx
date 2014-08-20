<%@ Page Title="" Language="C#" MasterPageFile="~/pifferi.master" AutoEventWireup="true"
    CodeFile="contatti.aspx.cs" Inherits="_contatti" %>

<%@ Register Src="uc/menu.ascx" TagName="menu" TagPrefix="uc1" %>
<%@ Register Src="uc/contenuto.ascx" TagName="contenuto" TagPrefix="uc2" %>
<%@ Register Src="uc/EditorialRepeater.ascx" TagName="EditorialRepeater" TagPrefix="edtRep" %>
<%-- Aggiungere qui i controlli del contenuto --%>
<asp:Content ID="menu" runat="server" ContentPlaceHolderID="menu">
    <uc1:menu ID="menu1" runat="server" SelectedMenu="mnuContatti" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="addheadcontent">
    <title>Contatti - Pifferi e Tamburi di Ivrea</title>
    <link rel="stylesheet" type="text/css" href="/css/sede.css" />
    <meta name="description" content="" />
</asp:Content>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="content">
    <div class="col-sm-6 col-md-8">
        <h1>Contatti</h1>
        <div class="contatti box">
                <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
                <div style="overflow:hidden;height:100%;width:auto;"><div id="gmap_canvas"></div>
                    <style>#gmap_canvas img{max-width:none!important;background:none!important}</style>
                </div><script type="text/javascript"> function init_map(){var myOptions = {zoom:16,center:new google.maps.LatLng(45.4630108,7.875959200000011),mapTypeId: google.maps.MapTypeId.ROADMAP};map = new google.maps.Map(document.getElementById("gmap_canvas"), myOptions);marker = new google.maps.Marker({map: map,position: new google.maps.LatLng(45.4630108, 7.875959200000011)});infowindow = new google.maps.InfoWindow({content:"<b>Pifferi e Tamburi di Ivrea</b><br/>Via Dora Baltea<br/>10015 IVREA" });google.maps.event.addListener(marker, "click", function(){infowindow.open(map,marker);});infowindow.open(map,marker);}google.maps.event.addDomListener(window, 'load', init_map);</script>
        </div>
    </div>
    <div class="col-sm-6 col-md-4">
        <edtRep:EditorialRepeater ID="rightContatti" runat="server" TipoOggetto="PhotoGallery" Count="5" Titolo="Foto" />
    </div>
</asp:Content>
