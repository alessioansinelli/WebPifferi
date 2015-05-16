<%@ Page Title="" Language="C#" MasterPageFile="~/pifferi.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Default" %>
<%@ Import Namespace="Business.Oggetti" %>
<%@ Register Src="uc/menu.ascx" TagName="menu" TagPrefix="uc1" %>

<%-- Aggiungere qui i controlli del contenuto --%>
<asp:Content ID="menu" runat="server" ContentPlaceHolderID="menu">
    <uc1:menu ID="menu1" runat="server" SelectedMenu="mnuHome" />
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="addheadcontent">
    <title>Home Page - Pifferi e Tamburi Ivrea</title>
    <link rel="stylesheet" href="/css/homepage.css" type="text/css" />
</asp:Content>


<asp:Content ID="top" runat="server" ContentPlaceHolderID="top">
    <!-- Home page slider -->
    <div class="col-md-12 homepage">
        <asp:Repeater ID="repSliderHome" runat="server">
            <HeaderTemplate>
                <div id="full-width-slider" class="royalSlider heroSlider rsMinW">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="rsContent">
                    <%# GetUrlPhoto(((Oggetto)Container.DataItem).Foto, "w12", "rsImg") %>
                    <div class="infoBlock infoBlockLeftBlack rsABlock">
                        <h3><%# DataBinder.Eval(Container.DataItem, "Titolo")%></h3>
                        <p><%# DataBinder.Eval(Container.DataItem, "SottoTitolo")%></p>
                        <div class="leggitutto"><a href="/news/<%# DataBinder.Eval(Container.DataItem, "slug")%>">Leggi tutto &raquo;</a></div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

<asp:Content ID="divcontenuto" runat="server" ContentPlaceHolderID="content">
    <div class="col-sm-6 col-md-4">
        <div class="homestoria box">
            <figure>
                <a href="/storia">
                    <img src="/images/layout/lanostrastoriathumb.jpg" />
                </a>
                <figcaption>
                    <a href="/storia"><span>La nostra Storia</span></a>
                </figcaption>
            </figure>
        </div>
    </div>
    <div class="col-sm-6 col-md-4">
        <div class="homestrumenti box">
            <figure>
                <a href="/strumenti">
                    <img src="/images/glistrumentithumb.jpg" />
                </a>
                <figcaption><a href="/strumenti"><span>Gli strumenti</span></a></figcaption>
            </figure>
        </div>
    </div>
    <div class="col-sm-6 col-md-4">
        <div class="homefotovideo box">
            <figure>
                <a href="/fotovideo">
                    <img src="/images/fotovideo.jpg" />
                </a>
                <figcaption>
                    <a href="/fotovideo.aspx">
                        <span>Foto e Video</span>
                    </a>
                </figcaption>
            </figure>
        </div>
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
                autoScaleSliderWidth: 960,*/
                autoScaleSliderHeight: 750,
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

