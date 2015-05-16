<%@ Page Title="" Language="C#" MasterPageFile="~/pifferi.master" AutoEventWireup="true" CodeFile="photogallery.aspx.cs" Inherits="Photogallery" %>

<%@ Register Src="uc/menu.ascx" TagName="menu" TagPrefix="uc1" %>
<%@ Register Src="uc/contenuto.ascx" TagName="contenuto" TagPrefix="uc2" %>

<%@ Register Src="uc/Photogallery.ascx" TagName="Photogallery" TagPrefix="uc3" %>

<%-- Aggiungere qui i controlli del contenuto --%>
<asp:Content ID="menu" runat="server" ContentPlaceHolderID="menu">
    <uc1:menu ID="menu1" runat="server" SelectedMenu="foto" />
</asp:Content>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="addheadcontent">
    <title>
        <asp:Literal runat="server" ID="TitleTag"></asp:Literal>
    </title>
</asp:Content>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="content">
    <div class="col-md-12">
        <div class="foto">
            <uc3:Photogallery ID="Photogallery1" runat="server" TipoOggetto="Photogallery" AllowPagination="true" ShowShare="true" ShowShareUrl="photogallery.aspx?id" />
        </div>
    </div>
</asp:Content>

<asp:Content ID="scriptBottom" ContentPlaceHolderID="addScript" runat="server">
    <script type="text/javascript">
        $(document).ready(function ($) {
            $('#full-width-gallery-slider').royalSlider({
                fullscreen: {
                    enabled: true,
                    nativeFS: true
                },
                controlNavigation: 'thumbnails',
                autoScaleSlider: true,
                autoScaleSliderWidth: 960,
                autoScaleSliderHeight: 600,
                loop: true,
                imageScaleMode: 'fit-if-smaller',
                navigateByClick: true,
                numImagesToPreload: 2,
                arrowsNav: true,
                arrowsNavAutoHide: true,
                arrowsNavHideOnTouch: true,
                keyboardNavEnabled: true,
                fadeinLoadedSlide: true,
                globalCaption: true,
                globalCaptionInside: false,
                thumbs: {
                    appendSpan: true,
                    firstMargin: true,
                    paddingBottom: 4
                }
            });
        });
    </script>
</asp:Content>
