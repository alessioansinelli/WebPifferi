<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slider.ascx.cs"
    Inherits="uc_slider" %>

<asp:Repeater ID="repSlider" runat="server">
    <HeaderTemplate>
        <div id="full-width-slider" class="royalSlider heroSlider rsMinW">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="rsContent">
            <%# getUrlPhoto(((Oggetti.OggettoFoto)Container.DataItem), "w8", "rsImg") %>
            <%--<div class="infoBlock infoBlockLeftBlack rsABlock">
                <h3><%# DataBinder.Eval(Container.DataItem, "Titolo")%></h3>
                <p><%# DataBinder.Eval(Container.DataItem, "SottoTitolo")%></p>
                <div class="leggitutto"><a href="dettaglionews.aspx?id=<%# DataBinder.Eval(Container.DataItem, "ID")%>">Leggi tutto &raquo;</a></div>
            </div>--%>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>

