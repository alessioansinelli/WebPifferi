<%@ Page Title="" Language="C#" MasterPageFile="~/be/be.master" AutoEventWireup="true" CodeFile="VideoEdit.aspx.cs" Inherits="be_videoEdit" ValidateRequest="false" %>

<%@ Register Src="uc/menunews.ascx" TagName="menunews" TagPrefix="uc1" %>
<%@ Register Src="uc/ucoggetto.ascx" TagName="ucoggetto" TagPrefix="uc2" %>
<%@ Register Src="uc/menu.ascx" TagName="menu" TagPrefix="uc2" %>

<asp:Content ID="mnu" ContentPlaceHolderID="menu" runat="server">
    <uc2:menu ID="mnu1" runat="server" SelectedMenu="Video" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server" id="frmNews">
        <uc2:ucoggetto ID="ucnews1" runat="server" TipoOggetto="Video" />
    </form>
</asp:Content>
