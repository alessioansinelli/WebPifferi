<%@ Page Title="" Language="C#" MasterPageFile="~/pifferi.master" AutoEventWireup="true" CodeFile="fotovideo.aspx.cs" Inherits="_fotoVideo" %>

<%@ Register Src="uc/menu.ascx" TagName="menu" TagPrefix="uc1" %>
<%@ Register Src="uc/contenuto.ascx" TagName="contenuto" TagPrefix="uc2" %>

<%-- Aggiungere qui i controlli del contenuto --%>
<asp:Content ID="menu" runat="server" ContentPlaceHolderID="menu">
    <uc1:menu ID="menu1" runat="server" SelectedMenu="mnuFotoVideo" />
</asp:Content>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="addheadcontent">
    <title>Le Foto - Pifferi e Tamburi di Ivrea </title>
    <meta name="description" content="Raccolte fotografiche dei Pifferi e Tamburi di Ivrea" />
</asp:Content>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="content">
    <div class="col-md-12">
        <h1>Le nostre foto</h1>
    </div>
    <div class="foto">
        <asp:Repeater ID="repFoto" runat="server">
            <ItemTemplate>
                <div class="col-md-4">
                    <div class="box">
                        <figure>
                            <a href="/gallery/<%# DataBinder.Eval(Container.DataItem, "slug")%>">
                                <%# Utility.getUrlPhoto(((Oggetti.Oggetto)Container.DataItem).Foto, "w6") %>
                            </a>
                            <figcaption><a href="/gallery/<%# DataBinder.Eval(Container.DataItem, "slug")%>"><span><%# DataBinder.Eval(Container.DataItem, "Titolo")%></span></a></figcaption>
                        </figure>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="col-md-12">
        <h1>I nostri video</h1>
    </div>
    <div class="video">
        <asp:Repeater ID="repVideo" runat="server">
            <ItemTemplate>
                <div class="col-md-4">
                    <div class="box">
                        <figure>
                            <a href="/video/<%# DataBinder.Eval(Container.DataItem, "slug")%>">
                                <%# Utility.getUrlPhoto(((Oggetti.Oggetto)Container.DataItem).Foto, "w6") %>
                            </a>
                            <figcaption><a href="/video/<%# DataBinder.Eval(Container.DataItem, "slug")%>"><span><%# DataBinder.Eval(Container.DataItem, "Titolo")%></span></a></figcaption>
                        </figure>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
<asp:Content ID="right" ContentPlaceHolderID="contentright" runat="server">

</asp:Content>
