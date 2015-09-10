<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="FreelanceTool.ProjectDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Freelancetool</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Freelancetool - Projektdetails</h1>
            <asp:Button ID="btnToDefault" runat="server" Text="Projekteverwaltung" OnClick="btnToDefault_Click"/><br /><br />
            <h2>Projekt:</h2>
            <asp:Label runat="server" Text="Name:"></asp:Label> <asp:TextBox ID="txtNameProject" runat="server"></asp:TextBox><br />
            <asp:Label runat="server" Text="Kunde:"></asp:Label> <asp:DropDownList ID="drdCustomer" runat="server"></asp:DropDownList><br />
            <asp:Button ID="btnSaveProject" runat="server" Text="Speichern" /><br /><hr />
            <asp:Label runat="server" Text="Neuer Task:"></asp:Label> <asp:TextBox ID="txtNewTask" runat="server"></asp:TextBox>
            <asp:Button ID="btnNewTask" runat="server" Text="Speichern" /><br /><hr />
            <asp:GridView ID="GridViewTasks" runat="server"
                AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="KommentarText" HeaderText="Tasks" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:GridView ID="GridViewKommentare" runat="server"
                                AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="text" HeaderText="Kommentare" />
                                </Columns>
                            </asp:GridView>
                            <asp:TextBox ID="txtNewComment" runat="server"></asp:TextBox><asp:Button ID="btnNewComment" runat="server" Text="Speichern" />
                            <asp:Button ID="btnDeleteTask" runat="server" Text="X" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
    </div>
    </form>
</body>
</html>
