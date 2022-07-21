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
using PNationalCard.Definition;

public partial class Convertor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetDefault();
        }
    }

    private void SetDefault()
    {
        //this.ddlOffice.DataSource = PNationalCard.Definition.NCollections.Offices.GetAll;
        //this.ddlOffice.DataBind();
        this.ddlOffice.Items.Clear();
        HNP.Security.Difinition.User user = (HNP.Security.Difinition.User)Session["User"];
        foreach (HNP.Security.Difinition.UserOffice objUOffice in HNP.Security.Difinition.SecurityCollections.UserOffice.GetAll)
        {
            if (objUOffice.User.UserID == user.UserID)
            {
                this.ddlOffice.Items.Add(new ListItem(objUOffice.Office.OfficeName, objUOffice.Office.OfficeID.ToString()));
            }
        }

        this.ddlStatus.DataSource = PNationalCard.Definition.NCollections.Status.GetAll;
        this.ddlStatus.DataBind();
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (this.Validation())
        {
            this.SaveAndConvert();
        }
        else
        {

            this.lblAlert.Visible = true;
            this.lblAlert.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void SaveAndConvert()
    {
        this.lblAlert.Text = "";
        this.lblAlert.Visible = false;
        this.lblAlert.ForeColor = System.Drawing.Color.Red;
        string mdbPath = "";
        try
        {
            String fileExtension = System.IO.Path.GetExtension(fuNationalCard.FileName).ToLower();
            string s_newfilename = DateTime.Now.Year.ToString() +
            DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + fileExtension;
            mdbPath = Server.MapPath(s_newfilename);
            fuNationalCard.PostedFile.SaveAs(mdbPath);

            PNationalCard.Entity.Person obj = new PNationalCard.Entity.Person();
            obj.Office = NCollections.Offices[short.Parse(this.ddlOffice.SelectedValue)];
            obj.Status = NCollections.Status[short.Parse(this.ddlStatus.SelectedValue)];

            if (obj.Convert(mdbPath))
            {
                if (obj.ErrMessage != String.Empty)
                {
                    this.lblAlert.Text += "<li>ارسال اطلاعات به صورت کامل انجام نگرفت</li>";
                    this.lblAlert.Text += "<li>" + obj.ErrMessage + "</li>";
                    this.lblAlert.Visible = true;
                    this.lblAlert.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    this.lblAlert.Text = "<li>اطلاعات با موفقيت ارسال گرديد</li>";
                    this.lblAlert.Visible = true;
                    this.lblAlert.ForeColor = System.Drawing.Color.Blue;
                }
            }
            else
            {
                this.lblAlert.Text += "<li>اشکال در ارسال اطلاعات رخ داد</li>";
                this.lblAlert.Text += "<li>" + obj.ErrMessage + "</li>";
                this.lblAlert.Visible = true;
                this.lblAlert.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            this.lblAlert.Text += "<li>" + ex.Message + "</li>";
            this.lblAlert.Visible = true;
            this.lblAlert.ForeColor = System.Drawing.Color.Red;
        }

    }

    private bool Validation()
    {
        FileUpload fu = fuNationalCard;

        bool validFile = false;
        if (fuNationalCard.HasFile)
        {
            String fileExtension = System.IO.Path.GetExtension(fuNationalCard.FileName).ToLower();
            String[] allowedExtensions = { ".mdb" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    validFile = true;
                }
            }
        }
        if (!validFile)
        {
            this.lblAlert.Text = "بانک انتخاب شده از نوع اکسس نمي باشد";
            validFile = false;
        }
        else
        {

            if (this.ddlOffice.SelectedIndex < 0)
            {
                this.lblAlert.Text = "اداره مربوطه را انتخاب نماييد.";
                validFile = false;
            }
        }
        return validFile;
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
