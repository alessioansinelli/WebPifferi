<%@ Page Title="" Language="C#" MasterPageFile="~/pifferi.master" AutoEventWireup="true"
    CodeFile="news.aspx.cs" Inherits="_news" %>

<%@ Register Src="uc/menu.ascx" TagName="menu" TagPrefix="uc1" %>
<%@ Register Src="uc/EditorialRepeater.ascx" TagName="EditorialRepeater" TagPrefix="edtRep" %>
<%-- Aggiungere qui i controlli del contenuto --%>
<asp:Content ID="menu" runat="server" ContentPlaceHolderID="menu">
    <uc1:menu ID="menu1" runat="server" SelectedMenu="mnuNotizie" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="addheadcontent">
    <title>Notizie - Pifferi e Tamburi Ivrea</title>
</asp:Content>
<asp:Content ID="divcontenuto" runat="server" ContentPlaceHolderID="content">
    <div class="col-sm-6 col-md-8">
        <div class="newslist">
            <asp:Repeater ID="repnews" runat="server">
                <HeaderTemplate>
                    <h1>Notizie</h1>
                    <ul class="notizie">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <a href="/news/<%# DataBinder.Eval(Container.DataItem, "slug")%>">
                            <figure class="imgList">
                                <%# Utility.getUrlPhoto(((Oggetti.Oggetto)Container.DataItem).Foto, "w2") %>
                            </figure>
                            <div class="newsdetail">
																<h4 class="newstitledate"><%# ((Oggetti.Oggetto)Container.DataItem).DataInserimento.ToString("dd MMM yyyy", new System.Globalization.CultureInfo("it-IT")) %></h4>
                                <h2 class="newstitle"><%# DataBinder.Eval(Container.DataItem, "Titolo")%></h2>
                                <div class="divnews">
                                    <%# DataBinder.Eval(Container.DataItem, "SottoTitolo")%>
                                </div>
                            </div>
                        </a>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
            <div id="divPaginazione" runat="server" class="pagnews"></div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="right" runat="server" ContentPlaceHolderID="contentright">
    <div class="col-sm-6 col-md-4">
        <edtRep:EditorialRepeater ID="rightNews" runat="server" TipoOggetto="PhotoGallery" Count="3" Titolo="Foto" />
    </div>
</asp:Content>
