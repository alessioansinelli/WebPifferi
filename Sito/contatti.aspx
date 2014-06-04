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
        <div class="contatti">
            <p>
            </p>
        </div>
    </div>
    <div class="col-sm-6 col-md-4">
        <edtRep:EditorialRepeater ID="rightContatti" runat="server" TipoOggetto="PhotoGallery" Count="5" Titolo="Foto" />
    </div>
</asp:Content>
