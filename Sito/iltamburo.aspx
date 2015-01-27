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
			<h1>La costruzione del tamburo</h1>
			<div class="pnewshome">
				<h3>Caratteristiche tecnico-costruttive del tamburo incordato</h3>
				<p>
					<img src="/images/strumenti/tamburo/tamburo-smontato.jpg" class="img-rounded img-responsive" />
				</p>
				<p>
					Il tamburo che viene attualmente utilizzato dal gruppo, salvo specifici aggiornamenti del caso, è parente stretto di quello in uso presso gli eserciti europei fin dal XVI, che lo contraddistingue dai suoi predecessori, detti “Imperiali”, da due importanti caratteristiche: la prima è da attribuire al tipo di suono emesso, che passa da un suono Muto ad uno Vibrato; questa particolare emissione sonora, viene  generata dall’applicazione, sulla pelle inferiore, di una piccola “Corda” di origine animale, che ha diametro di un paio di millimetri, detta “Cordiera” o “Timbro”.
				</p>
				<p>
					Va da se, che per ridurre il peso e aumentarne la praticità, rispetto al suo predecessore, le dimensioni in altezza sono state drasticamente ridotte. Se si fossero state mantenute le stesse dimensioni con l’affusto in ottone, si sarebbero superati i 5Kg, mentre con un’altezza di circa 28-30 cm, il peso corrisponde a 2,3Kg.<br />
					Descriviamo qui di seguito, le parti che compongono il tamburo usato dal nostro Gruppo.
				</p>
				<h3>Affusto o Cassa</h3>
				<p>
					Come già anticipato in precedenza,  la cassa del tamburo attualmente utilizzato è formato da una lamiera d’ottone di uno spessore di 0,6 mm, e un’altezza di 28-30 cm; la lamiera così dimensionata, subisce un operazione di “rullatura”, fino ad ottenere un diametro di 35,2 cm, e quindi saldata a stagno. Questa misura consente di montare “Pelli sintetiche” normalmente in commercio, con il diametro di 14” (circa 35,6 cm). 
					<br>
					Nel 1984, si decise di costruire dei nuovi tamburi, per rendere uniformi le dimensioni in altezza,  e migliorare volume e qualità del suono. Le dimensioni del nuovo Affusto, furono rilevate da tamburi utilizzati fino ad allora, eccetto un piccolo ritocco al diametro.<br />
				</p>
				<p>
					<img src="/images/strumenti/tamburo/fusto.jpg" class="img-rounded img-responsive" />
				</p>
				<p>
					L’Affusto, viene preparato praticando un foro di circa 6-8 mm in una posizione poco visibile, con lo scopo di consentire la fuoriuscita dell’aria quando la pelle superiore viene percossa dalle bacchette. Altri tre fori dal diametro di 4 mm in posizione prestabilita, permettono l’ancoraggio del gruppo di “Tensionamento” della Cordiera o Timbro.
				</p>
				<h3>Pelle</h3>
				<p>
					La pelle inizialmente naturale, viene poi necessariamente sostituita da quella “Sintetica” anche perché, a partire dagl’anni 70, risultò sempre più difficile reperire sul mercato pelle naturale, preparata con una “concia” fatta a regola d’arte. In altre parole, le pelli “naturali” duravano a mala pena qualche Carnevale, e in alcuni casi si rompevano rapidamente.
					<br />
					Va anche considerato che, oltre ad una durata ridotta, sostituire una pelle naturale richiedeva una procedura molto dispendiosa in termini di tempo; occorreva infatti bagnare la nuova pelle, per renderne possibile il montaggio arrotolandola, con l’ausilio di un particolare attrezzo sull’apposito cerchietto e successivamente, imbastirla sul tamburo. Terminate queste operazioni, bisognava aspettare pazientemente l’asciugatura della pelle per almeno due giorni, mettendo a rischio l’uso dello strumento nei giorni di carnevale. Al contrario, la sostituzione della pelle sintetica risulta decisamente più pratica e veloce (20 min.) e il suo utilizzo porta altri vantaggi come poter suonare anche sotto la poggia senza cali di prestazione, grazie alla proprietà di non assorbire l’umidità. L’unico svantaggio è che il suono risulta più metallico.
				</p>
				<h3>Cordiera o Timbro</h3>
				<p>
					Si tratta di un cordino intrecciato di materiale organico (in Budello o Nervo), lungo circa un metro e con un diametro di 2 mm, che viene montato a contatto della pelle inferiore del tamburo, ed ancorato su un apposita “Meccanica”.
					<br />
					La “Meccanica”, che è stata costruita su un progetto interno al gruppo, posiziona e tiene la cordiera a contatto della pelle inferiore ed è costituita da un “Pomello” filettato, che agisce su un asta esagonale scorrevole, il cui movimento, permette di regolare la tensione della Cordiera, determinando il suono più o meno vibrato. Percuotendo infatti la pelle superiore del tamburo, si ottiene una conseguente flessione o movimento della pelle inferiore, dovuta alla spinta dell’aria all’nterno dell’affusto, che fa vibrare la Cordiera generando il suono “Vibrato”. 
				</p>
				<p>
					<img src="/images/strumenti/tamburo/meccanica.jpg" class="img-rounded img-responsive" />
				</p>
				<h3>Cerchio</h3>
				<p>
					È costituito da tre sottili listelli di faggio incollati fra di loro che determinano uno spessore totale di 8-9 mm, per un’altezza di 4 cm 
					ed un diametro interno di 35,7 cm.
				</p>
				<p>
					<img src="/images/strumenti/tamburo/cerchi1.jpg" class="img-rounded img-responsive" />
				</p>
				<p>
					Sul tamburo ne vengono montati due, uno sulla pelle superiore ed uno su quella inferiore. I cerchi vengono preparati 
					con dieci fori equidistanti fra loro, con un diametro di 9 mm.  Al cerchio inferiore,  vengono aggiunti due orifizi rettangolari a 180 gradi, che permettono
					 il passaggio della Cordiera. I due cerchi così preparati, possono accogliere la corda che servirà a tendere le due pelli montate sul tamburo.  
				</p>
				<p>
					<img src="/images/strumenti/tamburo/cerchi2.jpg" class="img-rounded img-responsive" />
				</p>
				<h3>Corda</h3>
				<p>
					In origine era di canapa, purtroppo non è più reperibile sul mercato, almeno quella a “quattro principi”  con un diametro di 8 mm. 
					<br />
					La corda che viene utilizzata attualmente, è in “Poliestere”, e ne servono circa dodici metri per completare un tamburo. 
				</p>
				<p>
					<img src="/images/strumenti/tamburo/corda.jpg" class="img-rounded img-responsive" />
				</p>
				<p>
					Essa va preparata come segue: ad una estremità si crea un “occhiello”,  formato e legato con un sottilissimo cordino di Nylon Cerato, all’altra estremità, “intestata”,
					 fissandola con il cordino in Nylon, ad evitare che si scomponga.
				</p>
				<h3>Passante</h3>
				<p>
					E’ un particolare in cuoio di forma trapezoidale, che ha un’altezza di circa 6 cm ed assume la forma di “tubetto” dopo averne cucito i due lembi.
				</p>
				<p>
					<img src="/images/strumenti/tamburo/passante.jpg" class="img-rounded img-responsive" />
				</p>
				<p>
					Sul tamburo attualmente in dotazione al gruppo, ne servono dieci, in cui viene passata la corda che tiene uniti i cerchi su tutta la circonferenza della cassa del tamburo.<br />
					La loro funzione, é quella di tendere ulteriormente la corda che assembla il tamburo, e di conseguenza anche le due pelli. 
				</p>
				<p>Il peso del tamburo assemblato con tutti i particolari descritti, è di circa 4 Kg.</p>
				<h3>La Grancassa</h3>
				<p>
					E’ lo strumento che completa la caratteristica armonica del nostro Gruppo.
				</p>
				<p>
					<img src="/images/strumenti/tamburo/grancassa.jpg" class="img-rounded img-responsive" />
				</p>
				<p>
					Attualmente viene utilizzato uno strumento acquistato da un artigiano specializzato nella costruzione di ogni tipo di strumento a percussione che originariamente era dotata di  una meccanica di  “Tensionamento “ delle pelli (Sintetiche) da 22”, in acciaio.
					<br />
					Al fine di alleggerire il più possibile lo strumento e per renderlo più simile allo stile dei tamburi, si è deciso di eliminare questa meccanica, adottando lo stesso tipo di tiraggio delle pelli, con corda e passanti. 
				</p>
				<p>
					<img src="/images/strumenti/tamburo/grancassa.jpg" class="img-rounded img-responsive" />
				</p>
				<p>
					Il peso dello strumento è di 5,6 Kg con l’incordatura tradizionale, rispetto ai 7,8 Kg di prima. 
				</p>
			</div>
		</div>
	</div>
</asp:Content>

<asp:Content ID="right" runat="server" ContentPlaceHolderID="contentright">
	<div class="col-sm-6 col-md-4">
		<ul class="nav nav-pills nav-stacked mnu-strumenti">
			<li class="mnu-right"><a href="/strumenti/ilpiffero">La costruzione del Piffero</a></li>
			<li class="mnu-right active"><a href="/strumenti/iltamburo">La costruzione del Tamburo</a></li>
		</ul>
		<edtRepeater:EditorialRepeater runat="server" ID="strumentiRepeater" Count="4" Titolo="Video" TipoOggetto="Video" />
	</div>
</asp:Content>

<asp:Content ID="script" runat="server" ContentPlaceHolderID="addScript">
</asp:Content>
