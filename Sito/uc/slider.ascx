<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slider.ascx.cs"
    Inherits="uc.UcSlider" %>
<%@ Import Namespace="Business.Oggetti" %>

<asp:Repeater ID="repSlider" runat="server">
    <HeaderTemplate>
        <div id="full-width-slider" class="royalSlider heroSlider rsMinW">
    </HeaderTemplate>
    <ItemTemplate>
        <div class="rsContent">
            <%# GetUrlPhoto(((OggettoFoto)Container.DataItem), "w8", "rsImg") %>
            
            <div class="infoBlock infoBlockLeftBlack rsABlock" visible='<%# (DataBinder.Eval(Container.DataItem, "Titolo").ToString().Length > 0) %>' runat="server">
                <h3><%# DataBinder.Eval(Container.DataItem, "Titolo")%>&nbsp;</h3>
                <p><%# DataBinder.Eval(Container.DataItem, "SottoTitolo")%>&nbsp;</p>
            </div>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>

