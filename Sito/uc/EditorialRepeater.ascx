<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditorialRepeater.ascx.cs"
    Inherits="uc_EditorialRepeater" %>
<asp:Repeater ID="repEventi" runat="server">
    <HeaderTemplate>
        <h1><% = Titolo %></h1>
    </HeaderTemplate>
    <ItemTemplate>
        <div class="box">
            <figure>
                <a href="<%# Utility.GetBaseUrlByObjectType((TipoOggetto)DataBinder.Eval(Container.DataItem, "TipoOggetto"))  %>?id=<%# DataBinder.Eval(Container.DataItem, "ID")%>">
                    <%# Utility.getUrlPhoto(((Oggetti.Oggetto)Container.DataItem).Foto, "w6") %>
                </a>
                <figcaption><a href="photogallery.aspx?id=<%# DataBinder.Eval(Container.DataItem, "ID")%>"><span><%# DataBinder.Eval(Container.DataItem, "Titolo")%></span></a></figcaption>
            </figure>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
