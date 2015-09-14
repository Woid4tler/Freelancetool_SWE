<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerDetails.aspx.cs" Inherits="FreelanceTool.CustomerDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
           <h1 class="header__headline">Kundendetails</h1>
        </div>
        <div class="content">
            <asp:Button ID="btnToCustomer" runat="server" Text="zur Kundenübersicht" CssClass="right" OnClick="btnToCustomer_Click"/><br /><br />
            <h2>Kunde:</h2>
            <asp:Table runat="server" border="1" cellspacing="0">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server" Text="Name:"></asp:Label><br />
                        <asp:Label runat="server" Text="Tel:"></asp:Label><br />
                        <asp:Label runat="server" Text="E-Mail:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtNameCustomer" runat="server"></asp:TextBox><br />
                         <asp:TextBox ID="txtTelCustomer" runat="server"></asp:TextBox><br />
                         <asp:TextBox ID="txtMailCustomer" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="buttonRow">
                        <asp:Button ID="btnSaveCustomer" runat="server" Text="Speichern" OnClick="btnSaveCustomer_Click"/>
                        <asp:Button ID="btnDeleteCustomer" runat="server" Text="Löschen" OnClick="btnDeleteCustomer_Click"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <hr />
            <asp:GridView ID="GVAdresses" runat="server"
                AutoGenerateColumns="False"
                EmptyDataText="Keine Adressen gespeichert">
                <Columns>
                    <asp:BoundField DataField="street" HeaderText="Straße" ItemStyle-CssClass="street"/>
                    <asp:BoundField DataField="nr" HeaderText="Nummer"  ItemStyle-CssClass="number"/>
                    <asp:BoundField DataField="zip" HeaderText="PLZ" ItemStyle-CssClass="zip" />
                    <asp:BoundField DataField="city" HeaderText="Ort" />
                    <asp:TemplateField ItemStyle-CssClass="buttonRow">
                        <ItemTemplate>
                            <asp:Button ID="btnDeleteAdress" runat="server" Text="Löschen" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Table runat="server" border="1" cellspacing="0">
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
