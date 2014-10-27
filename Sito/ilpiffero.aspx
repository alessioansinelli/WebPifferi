<%@ Page Title="" Language="C#" MasterPageFile="~/pifferi.master" AutoEventWireup="true" CodeFile="ilpiffero.aspx.cs" Inherits="_ilpiffero" %>

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
            <h1>La costruzione del piffero</h1>
            <div class="pnewshome">
                <h3>La costruzione del piffero canavesano, come nasce la musica del Carnevale.</h3>
                <p>
                    La costruzione del piffero canavesano ha subìto nel corso del tempo profondi mutamenti, soprattutto a livello tecnologico per quanto riguarda macchinari e utensili necessari, 
                    tuttavia le operazioni fondamentali sono rimaste invariate. <br />
                    Prenderemo pertanto in considerazione le principali fasi costruttive, facendo il confronto tra passato e presente.
                </p>
                <h3>I tipi di legname e la loro scelta:</h3>
                <p>
                    il bosso ed il corniolo erano in ordine di importanza i materiali utilizzati per la costruzione dei pifferi e venivano reperiti sul territorio,
                     con il sambuco solitamente si costruivano strumenti giocattolo, oppure per i principianti. 
                    A volte si utilizzavano anche tubi in metallo. 
                    Oggi abbiamo la possibilità di disporre di una ampia gamma di tipi di essenze, reperibili in magazzini specializzati, da quelle esotiche (ebani, palissandri) alle più comuni e locali (bosso europeo, ciliegio, pero, sorbo).
                </p>
                <h3>La stagionatura:</h3>
                <p> prima di procedere con le lavorazioni era necessario far stagionare il legno
                    tagliato in listelli di sezione quadrata, il periodo ottimale si aggirava da cinque a dieci anni, questo 
                    per consentire che i movimenti del legno, una volta lavorato, si riducessero al minimo. Oggi come 
                    allora questa fase ricopre un’importanza di grande rilievo.
                </p>
                <h3>Le fasi della lavorazione:</h3>
                <p>le varie fasi della costruzione possono essere riassunte nell’immagine che segue.</p>
                <p>
                    <img src="images/strumenti/piffero/fasi.png" class="img-rounded img-responsive" />
                </p>
                <p>La foratura e la tornitura venivano effettuate con il tornio a pedale.</p>
                <p><img src="images/strumenti/piffero/tornio.jpg" class="img-rounded img-responsive" /></p>
                <p>
                    Gli utensili che si utilizzavano erano semplici mecchie o punte ad elica, spesso di lunghezza non 
                    sufficiente per forare il piffero in un'unica passata, spesso generavano problemi di scarico della 
                    polvere con conseguente surriscaldamento sia dell’utensile sia del legno, che portava spesso alla rottura dello stesso.<br />
                    Al termine della foratura si passava un tampone rovente all’interno per eliminare i residui e le eventuali pelurie lasciate dal passaggio dell’utensile.
                </p>
                <p><img src="images/strumenti/piffero/punteieri.jpg" class="img-rounded img-responsive" /></p>
                <p>
                    Attualmente la moderna tecnologia ci permette di usare, su un tornio di precisione, punte speciali e 
                    completamente differenti, chiamate “punte a cannone” che utilizzano il passaggio al loro interno di un getto di aria compressa che permette
                    di forare il legno ad una temperatura relativamente bassa e in una sola unica passata.
                </p>
                <p><img src="images/strumenti/piffero/puntemoderne.jpg" class="img-rounded img-responsive" /></p>
                <p>Terminata la fase di foratura interna si procede col creare la sede per gli anelli laterali di ottone che
                    servono, oltre che per un aspetto estetico, a rinforzare e proteggere le estremità del piffero.</p>  
                <p><img src="images/strumenti/piffero/anello.jpg" class="img-rounded img-responsive" /></p>
                <p>
                    Di seguito si procede col dare la forma allo strumento, questa lavorazione si effettua a mano oggi 
                    come in passato e di conseguenza, fa si che ogni piffero sia un pezzo unico, caratteristica questa che 
                    ben si addice a questi singolari prodotti artigianali. Gli utensili necessari a svolgere tale operazione 
                    sono rimasti invariati col passare del tempo e sono sgorbie e coltelli di svariate forme. <br />
                    Una volta raggiunte le dimensioni volute, si provvede a rifinire e lucidare la superficie esterna, 
                    a questo punto si potranno eseguire i sette fori che sono necessari allo strumento: uno di 
                    insufflazione, dove si appoggerà il labbro del suonatore e sei di melodia che verranno chiusi dai 
                    polpastrelli delle dita.
                </p>   
                <p><img src="images/strumenti/piffero/foratura.jpg" class="img-rounded img-responsive" /></p>
                <p> 
                    Infine, il piccolo tappo di sughero, che i pifferi chiamano “natin” sarà collocato internamente, 
                    vicino al foro di insufflazione e a questo punto lo strumento è terminato.</p>
                <p><img src="images/strumenti/piffero/natin.jpg" class="img-rounded img-responsive" /></p>
                <p> Dopo un breve collaudo 
                    verrà marchiato, trattato con olio protettivo e finalmente sarà pronto per essere suonato.</p>
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
