<%@ Page Title="" Language="C#" MasterPageFile="~/be/be.master" AutoEventWireup="true" CodeFile="NewsEdit.aspx.cs" Inherits="be.BeNewsEdit" ValidateRequest="false" %>
<%@ Register Src="uc/menu.ascx" TagName="menu" TagPrefix="uc2" %>
<%@ Register Src="uc/ucoggetto.ascx" TagName="ucoggetto" TagPrefix="uc2" %>
<asp:Content ID="mnu" ContentPlaceHolderID="menu" runat="server">
    <uc2:menu ID="mnu1" runat="server" SelectedMenu="Notizie" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server" id="frmNews">
        <uc2:ucoggetto ID="ucnews1" runat="server" TipoOggetto="News" />
    </form>
</asp:Content>
