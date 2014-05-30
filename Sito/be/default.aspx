<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="be_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
			<fieldset>
				<legend>Effettua l'accesso per accedere alla gestione dei contenuti</legend>
				<asp:TextBox ID="txtNomeUtente" runat="server"></asp:TextBox>
				<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
				<asp:Button runat="server" ID="btnSubmit" Text="Accedi" ToolTip="Accedi" 
					onclick="btnSubmit_Click" />
			</fieldset>
    </div>
    </form>
</body>
</html>
