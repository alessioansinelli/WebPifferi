<%@ Page Title="" Language="C#" MasterPageFile="~/pifferi.master" AutoEventWireup="true"
    CodeFile="programma.aspx.cs" Inherits="_programma" %>

<%@ Register Src="uc/menu.ascx" TagName="menu" TagPrefix="uc1" %>
<%@ Register Src="uc/contenuto.ascx" TagName="contenuto" TagPrefix="uc2" %>
<%@ Register src="uc/Appuntamenti.ascx" tagname="Appuntamenti" tagprefix="uc3" %>
<%-- Aggiungere qui i controlli del contenuto --%>
<asp:Content ID="menu" runat="server" ContentPlaceHolderID="menu">
    <uc1:menu ID="menu1" runat="server" SelectedMenu="programma" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="addheadcontent">
    <link rel="stylesheet" type="text/css" href="/css/programma.css" />
    <title>Associazione Aranceri Mercenari - Programma Carnevale 2014</title>
    <meta name="description" content="Programma degli appuntamenti Associazione Aranceri Mercenari. Feste e ritrovi per i giorni di Carnevale."  />
</asp:Content>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="content">
    <form id="form1" runat="server">
    <div class="programma">
        <div class="titolo grid_12">
            <img src="images/stemmi/stella_30.png" alt="Stella Mercenari" /></div>
        <div class="j grid_8 left">
            <h2>Domenica 6 Gennaio 2014 - Ore 09.00</h2>
            <p>
                E' ora. Con l'uscita dal Civico Palazzo di buon mattino dei Pifferi e Tamburi,
                inizia il tanto atteso Carnevale. Dopo la classica passeggiata per le vie di Ivrea
                allietata dalle note carnascialesche, i Mercenari si trovano per il tradizionale
                pranzo, che dà inizio ai festeggiamenti per il Carnevale imminente.
            </p>
            <h2>Domenica 23 Febbraio 2014 - Ore 10.00-17.30</h2>
            <p>
                Seconda uscita del generale in divisa ed alzata degli Abbà. <br />
                Noi Mercenari saremo presenti alla mostra/mercatino dell'Arancere 
                che si svolge dalle 10.00 alle 17.30 in piazza Ottinetti.
                La giornata sarà l'ultima data disponibile per iscriversi all'associazione per l'anno 2014, 
                ritardatari avanti.
                In occasione del Quarantenario dei Mercenari il nostro stand sarà sicuramente d'eccezione, passate a scooprirlo!
            </p>
            <h2>Giovedì grasso 27 Febbraio 2014 - Ore 21.30</h2>
            <p>
                Presentazione del Generale e prima uscita a cavallo del Brillante Stato Maggiore.
                Dalle 21.30...La festa continua: alla rotonda giallo-viola dei giardinetti 
                inizieremo a scaldare i pentoloni di vin brulè fumante.
                Con questa serata il Carnevale Giallo Viola entra nel vivo, è l'inizio della settimana più 
                emozionante dell'anno eporediese.                
            </p>
            <h2>Venerdì 28 Febbraio 2014 - Ore 21.30</h2>
            <p>
                Alla rotonda giallo-viola dei giardini pubblici bissiamo la folle festa di giovedì grasso;                
            </p>
            <h2>Sabato 01 Marzo 2014 - Ore 18.30</h2>
            <p>
                Appuntamento alla rotonda giallo-viola: radunata di tutti i Mercenari per accodarsi alla sfilata 
                in onore della Vezzosa Mugnaia, eroina del nostro Carnevale.
                Al termine della sfilata, mega festa giallo-viola per sciogliere i 
                nervi in attesa della cruenta imminente battaglia.
            </p>
            <h2>Domenica 02 Marzo 2014 - Ore 12.00</h2>
            <p>
                Pranzo giallo-viola in piazza del Rondolino aspettando la battaglia.<br />
                Bicchieri in alto che è ora di tirare!
            </p>
            <h2>Lunedì 03 Marzo 2014 - Ore 12.00</h2>
            <p>
				Pranzo giallo-viola in piazza del Rondolino aspettando la battaglia.
            </p>
            <h2>Martedì 04 Marzo 2014 - Ore 12.00</h2>
            <p>
				Pranzo giallo-viola in piazza del Rondolino aspettando la battaglia. 
				Forza Mercenari che è l'ultimo!
            </p>
            <h2>Sabato 16 Marzo 2014</h2>
            <p>
				Grandiosa cena di chiusura Carnevale.<br />
				Durante la cena verranno premiati gli aranceri e i soci che si sono contraddistinti durante le giornate di Carnevale.<br />
            </p>
        </div>
        <div class="grid_4">
        
            <uc3:Appuntamenti ID="Appuntamenti1" runat="server" />
        
        </div>
    </div>
</form>
</asp:Content>
