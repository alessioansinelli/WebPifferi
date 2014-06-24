<%@ Page Title="" Language="C#" MasterPageFile="~/be/be.master" AutoEventWireup="true" CodeFile="Video.aspx.cs" Inherits="be_video" %>
<%@ Register Assembly="Moxiecode.TinyMCE" Namespace="Moxiecode.TinyMCE.Web" TagPrefix="TinyMCE" %>
<%@ Register Src="~/be/uc/menuvideo.ascx" TagName="menuvideo" TagPrefix="uc1" %>
<%@ Register Src="uc/menu.ascx" TagName="menu" TagPrefix="uc2" %>
<asp:Content id="mnu" ContentPlaceHolderID="menu" runat="server">
    <uc2:menu ID="mnu1" runat="server"  SelectedMenu="Video"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server" id="frmNews">
        <uc1:menuvideo ID="menuvideo" runat="server" />
        <asp:GridView ID="grdNews" runat="server"
            EmptyDataText="Non sono presenti notizie" AutoGenerateColumns="False"
            DataKeyNames="ID" OnRowCommand="RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:ButtonField ButtonType="Link" CommandName="up" HeaderText="Su" ShowHeader="True" Text="Su" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Link" CommandName="down" HeaderText="Giù" ShowHeader="True" Text="Giù" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:ButtonField>
                <asp:BoundField DataField="Titolo" HeaderText="TITOLO" />
                <asp:BoundField DataField="SottoTitolo" HeaderText="SOTTO TITOLO" />
                <asp:BoundField DataField="DataInserimento" HeaderText="DATA CREAZIONE" />
                <asp:BoundField DataField="DataModifica" HeaderText="DATA MODIFICA" />
                <asp:ButtonField ButtonType="Link" CommandName="modifica" HeaderText="Modifica" ShowHeader="True" Text="Modifica" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Link" CommandName="elimina" HeaderText="Elimina" ShowHeader="True" Text="Elimina" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="eliminanews">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
    </form>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('.eliminanews').click(function () {
                return (confirm('Eliminare definitivamente l\'elemento?'));
            });
        });
    </script>
</asp:Content>

