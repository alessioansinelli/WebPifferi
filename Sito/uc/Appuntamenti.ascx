<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Appuntamenti.ascx.cs"
    Inherits="uc_Appuntamenti" %>
<asp:Repeater ID="repEventi" runat="server">
    <HeaderTemplate>
        <h1>Notizie</h1>
        <ul class="appuntamenti">
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <h2><%# DataBinder.Eval(Container.DataItem, "Titolo")%></h2>
            <%# Utility.getUrlPhoto(((Oggetti.Oggetto)Container.DataItem).Foto, "w4") %>
            <div class="newsappuntamenti">
                <%# DataBinder.Eval(Container.DataItem, "SottoTitolo")%>
            </div>
            <div class="leggitutto"><a href="dettaglionews.aspx?id=<%# DataBinder.Eval(Container.DataItem, "ID")%>">Leggi tutto &raquo;</a></div>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
