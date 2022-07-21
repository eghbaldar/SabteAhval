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
using PNationalCard.Utility;

public partial class Page_SearchNID : System.Web.UI.Page
{
    protected NumericPad NumericKey
    {
        get
        {
            return  (NumericPad)this.ViewState["NumericPad"];
        }
        set
        {
            this.ViewState["NumericPad"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        NumericPad objNum = new NumericPad();
        objNum.CreateNumber();

        for (int i = 0; i < 10; i++)
        {
            (this.FindControl("td" + i.ToString()) as HtmlTableCell).InnerHtml = objNum.GetType().GetProperty("Num" + i.ToString()).GetValue(objNum, null).ToString();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.lblDescription.Text = "";
        this.lblDescription.ForeColor = System.Drawing.Color.Blue;
        this.txtNID1.Text = String.Empty;
        this.txtNID2.Text = String.Empty;
        this.txtNID3.Text = String.Empty;
        try
        {
            Convert.ToInt64(this.txtNID1.Text.Trim() + this.txtNID2.Text.Trim() + this.txtNID3.Text.Trim());
        }
        catch (Exception ex)
        {
            this.lblDescription.ForeColor = System.Drawing.Color.Red;
            this.lblDescription.Text = "شماره ملي را صحيح وارد نماييد.";
            return;
        }

        PNationalCard.Entity.Person objPerson = new PNationalCard.Entity.Person();
        objPerson.NationalID = Int64.Parse(this.txtNID1.Text.Trim() + this.txtNID2.Text.Trim() + this.txtNID3.Text.Trim());
        if (!objPerson.NationalIDValidate())
        {
            this.lblDescription.ForeColor = System.Drawing.Color.Red;
            this.lblDescription.Text = "شماره ملي معتبر نمي باشد.";
            return;
        }

        if (objPerson.Load())
        {
            if (objPerson.Status.StatusID == 1)
            {
                this.lblDescription.Text = objPerson.Status.StatusDesc + " " + objPerson.Office.OfficeName + " واقع در " + objPerson.Office.Address + " مراجعه فرماييد .";
            }
            else
            {
                this.lblDescription.Text = objPerson.Status.StatusDesc;
            }
        }
        else
        {
            this.lblDescription.Text = "اطلاعاتي ثبت نگرديده است.";
        }
        
    }
}
