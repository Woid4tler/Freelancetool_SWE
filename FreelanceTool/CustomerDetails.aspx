<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerDetails.aspx.cs" Inherits="FreelanceTool.CustomerDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="styles.css" />
    <link href='https://fonts.googleapis.com/css?family=Roboto:400,700,300' rel='stylesheet' type='text/css' />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="header">
           <h1 class="header__headline">Kundendetails</h1>
        </div>
        <div class="content">
            <asp:Label ID="lblError" CssClass="error" runat="server" Font-Bold="True"></asp:Label>
            <asp:Button ID="btnToCustomer" runat="server" Text="zur Kundenübersicht" CssClass="right" OnClick="btnToCustomer_Click" CausesValidation="False"/><br /><br />
            <h2>Kunde</h2>
            <asp:Table runat="server" cellspacing="0">
                <asp:TableRow>
                    <asp:TableCell CssClass="labelCell">
                        <asp:Label runat="server" Text="Name:"></asp:Label><br />
                        <asp:Label runat="server" Text="Tel:"></asp:Label><br />
                        <asp:Label runat="server" Text="E-Mail:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtNameCustomer" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" CssClass="errorMessages" runat="server" ControlToValidate="txtNameCustomer" ErrorMessage="Name fehlt"></asp:RequiredFieldValidator><br />
                        <asp:TextBox ID="txtTelCustomer" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="Dynamic" CssClass="errorMessages" ID="regexPhoneValid" runat="server" ValidationExpression="\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1)\d{1,14}$" ControlToValidate="txtTelCustomer" ErrorMessage="keine gültige Telefonnummer!"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator Display="Dynamic" CssClass="errorMessages" runat="server" ControlToValidate="txtTelCustomer" ErrorMessage="Telefonnummer fehlt"></asp:RequiredFieldValidator><br />
                        <asp:TextBox ID="txtMailCustomer" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="Dynamic" CssClass="errorMessages" ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtMailCustomer" ErrorMessage="keine gültige Mail Adresse!"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator Display="Dynamic" CssClass="errorMessages" runat="server" ControlToValidate="txtMailCustomer" ErrorMessage="Mail Adresse fehlt"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                    <asp:TableCell CssClass="buttonRow">
                        <asp:Button ID="btnSaveCustomer" runat="server" Text="Speichern" OnClick="btnSaveCustomer_Click"/><br />
                        <asp:Button CausesValidation="False" ID="btnCancel" runat="server" Text="Abbrechen" OnClick="btnCancel_Click" /><br />
                        <asp:Button ID="btnDeleteCustomer" runat="server" Text="Löschen" OnClick="btnDeleteCustomer_Click"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <hr />
            <asp:GridView ID="GVAdresses" runat="server"
                AutoGenerateColumns="False"
                EmptyDataText="Keine Adressen gespeichert" OnRowDeleting="GVAdresses_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="street" HeaderText="Straße" ItemStyle-CssClass="street"/>
                    <asp:BoundField DataField="nr" HeaderText="Nummer"  ItemStyle-CssClass="number"/>
                    <asp:BoundField DataField="zip" HeaderText="PLZ" ItemStyle-CssClass="zip" />
                    <asp:BoundField DataField="city" HeaderText="Ort" />
                    <asp:ButtonField CommandName="Delete" text="Löschen" ItemStyle-CssClass="buttonRow"/>
                </Columns>
            </asp:GridView><hr /><br />
            <asp:Table runat="server" ID="tblNewAdress" cellspacing="0">
                <asp:TableRow>
                    <asp:TableHeaderCell CssClass="street">Straße</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="number">Nummer</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="zip">PLZ</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Ort</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="buttonRow"></asp:TableHeaderCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="street"><asp:TextBox   ID="txtStreet" runat="server"></asp:TextBox></asp:TableCell>
                    <asp:TableCell CssClass="number"><asp:TextBox  ID="txtStreetnumber"  runat="server"></asp:TextBox></asp:TableCell>
                    <asp:TableCell CssClass="zip"><asp:TextBox ID="txtZip" runat="server"></asp:TextBox></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtCity" runat="server"></asp:TextBox></asp:TableCell>
                    <asp:TableCell CssClass="buttonRow"><asp:Button ID="btnNewAddress" runat="server" Text="Hinzufügen" OnClick="btnNewAddress_Click" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
