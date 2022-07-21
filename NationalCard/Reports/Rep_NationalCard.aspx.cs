using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Reports_Rep_NationalCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ddlStatus.DataSource = PNationalCard.Definition.NCollections.Status.GetAll;
            this.ddlStatus.DataBind();

            this.ddlOffice.DataSource = PNationalCard.Definition.NCollections.Offices.GetAll;
            this.ddlOffice.DataBind();
        }
    }
    protected void rdbStatus_CheckedChanged(object sender, EventArgs e)
    {
        this.ddlOffice.Enabled = false;
        this.ddlStatus.Enabled = true;
    }
    protected void rdbOffice_CheckedChanged(object sender, EventArgs e)
    {
        this.ddlOffice.Enabled = true;
        this.ddlStatus.Enabled = false;
    }

    protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        PNationalCard.Entity.PersonCollection obj = new PNationalCard.Entity.PersonCollection();
        if (rdbOffice.Checked)
        {
            obj.LoadByOffice(short.Parse(this.ddlOffice.SelectedValue));
        }
        else
        {
            obj.LoadByStatus(short.Parse(this.ddlStatus.SelectedValue));
        }

        this.dgNationalCard.DataSource = obj.GetAll;
        this.dgNationalCard.DataBind();
    }

    protected void btnExit_Click(object sender, ImageClickEventArgs e)
    {
        Session.Remove("User");
        Response.Redirect("~/Login.aspx");
    }

    protected void btnHome_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/SettingPanel.aspx");
    }

}
