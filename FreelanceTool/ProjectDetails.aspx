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
        <div class="header">
           <h1 class="header__headline">Projektdetails</h1>
        </div>
        <div class="content">
            <asp:Button ID="btnToProjectsOverview" runat="server" CssClass="right" Text="zur Projektübersicht" OnClick="btnToProjectsOverview_Click"/><br /><br />
            <h2>PROJEKT <asp:Label runat="server" ID="lblProjekttitle"></asp:Label></h2>
            <asp:Table runat="server" border="1" cellspacing="0">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server" Text="Name:"></asp:Label><br />
                        <asp:Label runat="server" Text="Kunde:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtNameProject" runat="server"></asp:TextBox><br />
                        <asp:DropDownList ID="ddlCustomer" runat="server"></asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell CssClass="buttonRow"><asp:Button ID="btnSaveProject" runat="server" Text="Speichern" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <hr />
            <asp:Table runat="server" border="1" cellspacing="0">
                <asp:TableRow>
                    <asp:TableCell><asp:Label runat="server" Text="Neuer Task:"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtNewTask" runat="server"></asp:TextBox></asp:TableCell>
                    <asp:TableCell CssClass="buttonRow"><asp:Button ID="btnNewTask" runat="server" Text="Hinzufügen" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <hr />
            <asp:GridView ID="GVTasks" runat="server"
                AutoGenerateColumns="False"
                EmptyDataText="Keine Tasks gespeichert" 
                onrowdatabound="GVTasks_BoundComments">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Tasks" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:GridView ID="GVComments" runat="server"
                                AutoGenerateColumns="False"
                                EmptyDataText="Keine Kommentare gespeichert">
                                <Columns>
                                    <asp:BoundField DataField="text" HeaderText="Kommentare" />
                                    <asp:TemplateField ItemStyle-CssClass="buttonRow">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDeleteComment" runat="server" Text="Löschen" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView><br />
                            <asp:Table runat="server" border="1" cellspacing="0">
                                <asp:TableRow>
                                    <asp:TableCell><asp:TextBox ID="txtNewComment" runat="server"></asp:TextBox></asp:TableCell>
                                    <asp:TableCell CssClass="buttonRow"><asp:Button ID="btnNewComment" runat="server" Text="Speichern" /></asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="buttonRow">
                        <ItemTemplate>
                            <asp:Button ID="btnDeleteTask" runat="server" Text="Löschen"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
