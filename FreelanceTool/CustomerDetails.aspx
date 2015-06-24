<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerDetails.aspx.cs" Inherits="FreelanceTool.CustomerDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Freelancetool - Projektdetails</h1>
            <asp:Button ID="btnToCustomer" runat="server" Text="Kundenverwaltung"/><br /><br />
            <h2>Kunde:</h2>
            <asp:Label runat="server" Text="Name:"></asp:Label> <asp:TextBox ID="txtNameCustomer" runat="server"></asp:TextBox><br />
            <asp:Label runat="server" Text="Tel:"></asp:Label> <asp:TextBox ID="txtTelCustomer" runat="server"></asp:TextBox><br />
            <asp:Label runat="server" Text="E-Mail:"></asp:Label> <asp:TextBox ID="txtMailCustomer" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnSaveCustomer" runat="server" Text="Speichern" /><br /><hr />
            <asp:GridView ID="GridViewAdresses" runat="server"
                AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="city" HeaderText="Ort" />
                    <asp:BoundField DataField="zip" HeaderText="PLZ" />
                    <asp:BoundField DataField="street" HeaderText="Straße" />
                    <asp:BoundField DataField="nr" HeaderText="Nummer" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDeleteTask" runat="server" Text="X" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView><hr />
            <h3>neue Adresse:</h3>
            <asp:Label runat="server" Text="Ort:"></asp:Label> <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><br />
            <asp:Label runat="server" Text="PLZ:"></asp:Label> <asp:TextBox ID="txtZip" runat="server"></asp:TextBox><br />
            <asp:Label runat="server" Text="Straße:"></asp:Label> <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox><br />
            <asp:Label runat="server" Text="Nr:"></asp:Label> <asp:TextBox ID="txtStreetnumber" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnNewAddress" runat="server" Text="Adresse speichern" />
    </div>
    </form>
</body>
</html>
