<%@ Page Title="" Language="C#" MasterPageFile="~/pifferi.master" AutoEventWireup="true" CodeFile="dettaglionews.aspx.cs" Inherits="_dettaglionews" %>

<%@ Register Src="uc/menu.ascx" TagName="menu" TagPrefix="uc1" %>
<%@ Register Src="uc/Appuntamenti.ascx" TagName="Appuntamenti" TagPrefix="uc2" %>
<%@ Register Src="uc/notizia.ascx" TagName="notizia" TagPrefix="uc3" %>
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
            <uc3:notizia ID="notizia1" runat="server" />
        </div>
    </div>
</asp:Content>

<asp:Content ID="right" runat="server" ContentPlaceHolderID="contentright">
    <div class="col-sm-6 col-md-4">
        <uc2:Appuntamenti ID="Appuntamenti1" runat="server" />
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
