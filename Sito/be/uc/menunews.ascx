<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menunews.ascx.cs" Inherits="be_uc_menu_news" %>
<ul class="menunotizia">
    <li><a href="/be/newsedit.aspx">Inserisci Notizia</a></li>
    <li><asp:LinkButton ID="lnkPulisciCache" runat="server" Text="Pulisci Cache" 
            onclick="lnkPulisciCache_Click"></asp:LinkButton></li>
</ul>