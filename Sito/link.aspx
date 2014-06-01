<%@ Page Title="" Language="C#" MasterPageFile="~/pifferi.master" AutoEventWireup="true" CodeFile="link.aspx.cs" Inherits="_link" %>

<%@ Register src="uc/menu.ascx" tagname="menu" tagprefix="uc1" %>
<%@ Register src="uc/contenuto.ascx" tagname="contenuto" tagprefix="uc2" %>

<%-- Aggiungere qui i controlli del contenuto --%>
<asp:Content ID="menu" runat="server" ContentPlaceHolderID="menu">
	<uc1:menu ID="menu1" runat="server" SelectedMenu="link" />
</asp:Content>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="addheadcontent">
    <title>Associazione Aranceri Mercenari - Link</title>
    <link rel="stylesheet" type="text/css" href="/css/link.css" />
    <meta name="description" content="Link raccolti nel sito Associazione Aranceri Mercenari. Siti inerenti il Carnevale di Ivrea e gli Amici della Associazione."  />
</asp:Content>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="content">
    <div class="link">
        <div class="titolo grid_12"><img src="images/stemmi/stella_30.png" alt="Stella Mercenari" /></div>        
        <div class="grid_8">
            <h1>Carnevale</h1>
            <ul class="link linkpage">
                <li>
                    <a href="http://www.carnevalediivrea.it/" title="Sito Ufficiale Storico Carnevale di Ivrea" target="_blank">
                    <img src="images/link/carnevale.png" alt="Storico Carnevale di Ivrea" /></a>
                    <h3 class="c">Storico Carnevale di Ivrea</h3>
                </li>
                <li>
                    <a href="http://www.occhiocrepato.com/bastauntiro/" title="Sito Ufficiale dell'Ombrellone dei Mercenari" target="_blank">
                    <img src="images/link/bastauntiro.png" alt="L'Ombrellone dei Mercenari" /></a>
                    <h3 class="c">L'Ombrellone dei Mercenari</h3>
                </li>
                <li>
                    <a href="http://www.assodipicche.it" title="Associazione Aranceri Asso di Picche" target="_blank">
                    <img src="images/link/picche.png" alt="Associazione Aranceri Asso di Picche" /></a>
                    <h3 class="c">Aranceri Asso di Picche</h3>
                </li>
                <li>
                    <a href="http://www.arancerimorte.it" title="Associazione Aranceri della Morte" target="_blank">
                    <img src="images/link/morte.png" alt="Associazione Aranceri della Morte" /></a>
                    <h3 class="c">Aranceri della Morte</h3>
                </li>
                <li>
                    <a href="http://www.tuchini.it" title="Associazione Aranceri Tuchini del Borghetto" target="_blank">
                    <img src="images/link/tuchini.png" alt="Associazione Aranceri Tuchini del Borghetto" /></a>
                    <h3 class="c">Aranceri Tuchini del Borghetto</h3>
                    </li>
                <li><a href="http://www.scorpionidarduino.it/" title="Associazione Aranceri Scorpioni d'Arduino" target="_blank">
                    <img src="images/link/arduini.png" alt="Associazione Aranceri Scorpioni d'Arduino" /></a>
                    <h3 class="c">Aranceri Scorpioni d'Arduino</h3></li>
                <li><a href="http://www.aranceriscacchi.it/" title="Associazione Aranceri Scacchi" target="_blank">
                    <img src="images/link/scacchi.png" alt="Associazione Aranceri Scacchi" /></a>
                    <h3 class="c">Aranceri Scacchi</h3></li>
                <li><a href="http://www.aranceripanteranera.com" title="Aranceri Pantera Nera" target="_blank">
                        <img src="images/link/pantere.png" alt="Associazione Aranceri Pantera Nera" /></a>
                    <h3 class="c">Aranceri Pantera Nera</h3>
                    </li>
               <li>
                    <a href="http://www.diavoliaranceri.com/" title="Associazione Diavoli Aranceri" target="_blank">
                        <img src="images/link/diavoli.png" alt="Associazione Diavoli Aranceri" />
                    </a>
                    <h3 class="c">Diavoli Aranceri</h3></li>
                <li>
                    <a href="http://www.credendariaranceri.it" title="Associazione Credendari Aranceri" target="_blank">
                        <img src="images/link/credendari.png" alt="Associazione Credendari Aranceri" />
                    </a>
                    <h3 class="c">Credendari Aranceri</h3>
                </li>
            </ul>
            <h1>Amici</h1>
            <ul class="link linkpage">
                <li>
                    <a href="http://www.ivrearugby.it/" title="Ivrea Rugby Club" target="_blank">
                    <img src="images/link/ivrearugby.png" alt="Ivrea Rugby Club" /></a>
                    <h3 class="c">Ivrea Rugby Club</h3>
                </li>
                <!--<li>
                    <a href="http://www.misterwireless.it/" title="Mr. Wireless" target="_blank">
                    <img src="images/link/mrwireless.png" alt="Mr. Wireless" /></a>
                    <h3 class="c">Mr. Wireless</h3>
                </li>-->
                <li>
                    <a href="http://www.associazionemiscela.it/" title="Associazione Miscela" target="_blank">
                    <img src="images/link/miscela.png" alt="Associazione Miscela" /></a>
                    <h3 class="c">Associazione Miscela</h3>
                </li>
            </ul>
        </div>
        <div class="grid_4 right">
            
            
        </div>        
    </div>
</asp:Content>