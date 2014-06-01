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
                Un luogo importantissimo per la vita della squadra è sicuramente la "SEDE", dove
                i Mercenari si incontrano per le riunioni, che servono per organizzare principalmente
                il nostro Carnevale, e tutte le iniziative che oramai si dipanano durante tutto
                l'anno. Sono ormai lontani gli anni della culla di Bajo Dora, e della storica Stella
                di Italia; da parecchio tempo la sede dell'Associazione Aranceri Mercenari si trova
                presso il <strong>Circolo ARCI di San Bernardo di Ivrea</strong>, dove i gestori
                con la loro gentilezza e ospitalità fanno sentire i Mercenari a casa propria.
                <br />
                A partire dal 6 Gennaio e fino a Carnevale ci si trova, in allegria, tra amici che
                condividono la passione per la battaglia delle arance e per la magnifica festa qual'è
                lo Storico Carnevale di Ivrea. Per gli iscritti o per i semplici avventori di passaggio,
                sarà sempre immancabile del buon vino condito con l'atmosfera e lo spirito che da
                sempre contraddistingue i Mercenari e il loro modo di vivere il Carnevale.
            </p>
            <p>
                In sede, si svolgono anche le <a href="/iscrizioni.aspx">iscrizioni</a> per partecipare
                al Carnevale ed alla battaglia delle arance
            </p>
        </div>
    </div>
    <div class="col-sm-6 col-md-4">
        <edtRep:EditorialRepeater ID="rightContatti" runat="server" TipoOggetto="PhotoGallery" Count="5" Titolo="Foto" />
    </div>
</asp:Content>
