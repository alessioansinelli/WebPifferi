<%@ Page Title="" Language="C#" MasterPageFile="~/pifferi.master" AutoEventWireup="true" CodeFile="iltamburo.aspx.cs" Inherits="_iltamburo" %>

<%@ Register Src="uc/menu.ascx" TagName="menu" TagPrefix="uc1" %>
<%@ Register Src="~/uc/EditorialRepeater.ascx" TagName="EditorialRepeater" TagPrefix="edtRepeater" %>


<%-- Aggiungere qui i controlli del contenuto --%>
<asp:Content ID="menu" runat="server" ContentPlaceHolderID="menu">
    <uc1:menu ID="menu1" runat="server" SelectedMenu="mnuStrumenti" />
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="addheadcontent">
    <title>Il piffero - Pifferi e Tamburi Ivrea</title>
</asp:Content>

<asp:Content ID="top" runat="server" ContentPlaceHolderID="top">
</asp:Content>

<asp:Content ID="divcontenuto" runat="server" ContentPlaceHolderID="content">
    <div class="col-sm-6 col-md-8">
        <div class="strumenti news">
            <h1>Gli strumenti</h1>
            <div class="pnewshome">
                <p>
                    Gli strumenti utilizzati dal gruppo sono:
            <em>il piffero</em> (un piccolo flauto traverso generalmente in legno di bosso), <em>il tamburo</em> e la <em>grancassa</em>.<br />
                    Questi sono gli unici strumenti impiegati e ancora oggi vengono realizzati artigianalmente su 
            precise indicazioni degli stessi componenti del gruppo.<br />
                    Il piffero, simbolo indiscusso del Carnevale, designa curiosamente, nel contempo, sia lo strumento 
            suonato che il soggetto suonatore. Normalmente è costruito in bosso o corniolo, ha canneggio 
            interno cilindrico e sei fori oltre, ovviamente, ad un’imboccatura (è simile, come forma, ad un 
            ottavino ma senza le chiavi).
                <br />
                    Il prodotto artigianale finito è un pezzo unico, difficilmente riproducibile soprattutto nelle sue 
            qualità sonore.
                <br />
                    Infatti, le caratteristiche della compattezza del legno e della struttura anatomica del 
            labbro di ogni suonatore, non garantiscono la stessa intonazione.
                </p>
                <p>
                    Il tamburo, almeno quello in uso due generazioni or sono, presentava una cassa di ottone, più 
            alta di quelle proprie degli strumenti civili, munita di timbro o "cordiera", ed era, e viene tutt’ora 
            affiancato dalla grancassa (la "timbala"), anch'essa in dotazione ai corpi musicali sabaudi.
                </p>
                <p>
                    La timbala, è uno strumento determinante nel gruppo Pifferi e Tamburi. Ha il compito di tenere 
            il tempo e da essa ne trae beneficio tutto il gruppo; detta le velocità delle marce ed evita o decide 
            l'accelerare o il rallentare delle stesse. È costruita in legno, con pelli naturali, con incordatura a 
            corde di canapa.
                </p>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="right" runat="server" ContentPlaceHolderID="contentright">
    <div class="col-sm-6 col-md-4">
        <edtRepeater:EditorialRepeater runat="server" ID="strumentiRepeater" Count="4" Titolo="Video" TipoOggetto="Video" />
    </div>
</asp:Content>

<asp:Content ID="script" runat="server" ContentPlaceHolderID="addScript">
</asp:Content>
