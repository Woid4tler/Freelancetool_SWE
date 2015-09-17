using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_FreelanceTool;

namespace FreelanceTool
{
    public partial class CustomerDetails : System.Web.UI.Page
    {
        string currentID;
        Customers currentCustomer;
        List<Adresses> allAdresses;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                currentID = (string)Session["id"]; //wurde beim Aufruf übertragen
                if (currentID != "")
                {
                    //Objekt laden und Werte setzen
                    currentCustomer = Main.getCustomerByID(currentID);

                    if (currentCustomer != null)
                    {
                        //kopiere die Properties des Objekts in die Felder der Maske
                        //lblID.Text = currentProject.id;
                        txtNameCustomer.Text = currentCustomer.name;
                        txtTelCustomer.Text = currentCustomer.phone;
                        txtMailCustomer.Text = currentCustomer.mail;
                        Session["Customer"] = currentCustomer; //Projektobjekt in Session speichern
                        btnDeleteCustomer.Visible = true;
                        tblNewAdress.Visible = true;
                    }
                    else
                    {
                        lblError.Text = "Kunde nicht gefunden - Sie können einen neuen Kunden anlegen!";
                        btnDeleteCustomer.Visible = false;
                        tblNewAdress.Visible = false;
                        Session["Customer"] = Main.newCustomer(); //neues leeres Kundenobjekt
                    }
                }
                else
                {
                    //leere ID? Dann ist das ein neuer Kunde
                    btnDeleteCustomer.Visible = false;
                    tblNewAdress.Visible = false;
                    currentCustomer = Main.newCustomer();
                    Session["Customer"] = currentCustomer; //neues leeres Projektobjekt
                }
            }
            else
                currentCustomer = (Customers)Session["Customer"];

            if (currentCustomer != null)
            {
                allAdresses = currentCustomer.getAdresses;
                GVAdresses.DataSource = allAdresses;
                GVAdresses.DataBind(); //dadurch wirds angezeigt
            }

  

        }

        //Button zur Kundenverwaltung
        protected void btnToCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomersOverview.aspx"); //Redirect zur Kundenverwaltungseite
        }

        protected void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (currentCustomer != null)
            {
                //Feldwerte in das Objekt laden
                currentCustomer.name = txtNameCustomer.Text;
                currentCustomer.phone = txtTelCustomer.Text;
                currentCustomer.mail = txtMailCustomer.Text;
                if (currentCustomer.save())
                {
                    lblError.Text = "Kunde wurde gespeichert!";
                    btnDeleteCustomer.Visible = true;
                    tblNewAdress.Visible = true;
                }
                else lblError.Text = "Speichern fehlgeschlagen";
            }
            else lblError.Text = "Kunde existiert nicht mehr in der Datenbank!";


        }
        protected void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (currentCustomer.delete()) Response.Redirect("CustomersOverview.aspx");
            else lblError.Text = "Löschen nicht möglich";
        }
        

        protected void btnNewAddress_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (currentCustomer != null &&
                txtCity.Text != "" &&
                txtZip.Text != "" &&
                txtStreet.Text != "" &&
                txtStreetnumber.Text != "")
            {
                Adresses newAdress = new Adresses();
                newAdress.city = txtCity.Text;
                newAdress.zip = txtZip.Text;
                newAdress.street = txtStreet.Text;
                newAdress.nr = txtStreetnumber.Text;
                newAdress.addToCustomer(currentCustomer.id);
                newAdress.save();
                txtCity.Text = "";
                txtZip.Text = "";
                txtStreet.Text = "";
                txtStreetnumber.Text = "";
                //liste neu laden
                GVAdresses.DataSource = currentCustomer.getAdresses;
                GVAdresses.DataBind();
            }
            else {
                lblError.Text = "Adresse kann nicht gespeichert werden! Bitte alle Felder ausfüllen!";
            }
        }

        protected void GVAdresses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblError.Text = "";
            Adresses adressToDelete = allAdresses[e.RowIndex];
            if (adressToDelete.delete())
            {
                GVAdresses.DataSource = currentCustomer.getAdresses;
                GVAdresses.DataBind();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerOverview.aspx"); //ohne Speichern zur Kundenübersicht
        }

    }
}