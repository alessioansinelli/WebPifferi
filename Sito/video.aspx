<%@ Page Title="" Language="C#" MasterPageFile="~/pifferi.master" AutoEventWireup="true" CodeFile="video.aspx.cs" Inherits="_video" %>

<%@ Register Src="uc/menu.ascx" TagName="menu" TagPrefix="uc1" %>
<%@ Register Src="uc/EditorialRepeater.ascx" TagName="EditorialRepeater" TagPrefix="edtRepeater" %>
<%@ Register Src="uc/video.ascx" TagName="video" TagPrefix="video" %>
<%@ Register Src="~/uc/slider.ascx" TagPrefix="uc1" TagName="slider" %>


<%-- Aggiungere qui i controlli del contenuto --%>
<asp:Content ID="menu" runat="server" ContentPlaceHolderID="menu">
    <uc1:menu ID="menu1" runat="server" SelectedMenu="notizie" />
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="addheadcontent">
    <title runat="server"><% = TitoloPagina %> - Pifferi e Tamburi Ivrea - Notizie</title>
</asp:Content>

<asp:Content ID="divcontenuto" runat="server" ContentPlaceHolderID="content">
    <div class="col-sm-6 col-md-8">
        <div class="news">
            <video:video ID="notizia1" runat="server" />
        </div>
    </div>
</asp:Content>

<asp:Content ID="right" runat="server" ContentPlaceHolderID="contentright">
    <div class="col-sm-6 col-md-4">
        <edtRepeater:EditorialRepeater ID="repDettaglioVideo" runat="server" Titolo="Foto" TipoOggetto="Photogallery" Count="3" />
    </div>
</asp:Content>

<asp:Content ID="script" runat="server" ContentPlaceHolderID="addScript">
    <script type="text/javascript">
        $(document).ready(function ($) {
            $('#full-width-slider').royalSlider({
                arrowsNav: true,
                loop: true,
                keyboardNavEnabled: true,
                controlsInside: false,
                imageScaleMode: 'fill',
                arrowsNavAutoHide: false,
                /*autoScaleSlider: true,
                autoScaleSliderWidth: 960,
                autoScaleSliderHeight: 350,*/
                controlNavigation: 'bullets',
                thumbsFitInViewport: false,
                navigateByClick: true,
                startSlideId: 0,
                autoPlay: false,
                transitionType: 'move',
                globalCaption: true,
                deeplinking: {
                    enabled: true,
                    change: false
                }/*, size of all images http://help.dimsemenov.com/kb/royalslider-jquery-plugin-faq/adding-width-and-height-properties-to-images 
                imgWidth: 1140,
                imgHeight: 800*/
            });
        });
    </script>
</asp:Content>
