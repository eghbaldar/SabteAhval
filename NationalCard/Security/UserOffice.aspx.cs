using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using HNP.Security.Difinition;
using PNationalCard.Definition;

public partial class UserOffice : System.Web.UI.Page
{
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.pageStatus = HNP.Base.Enum.PageStatus.None;

            this.drpOffice.DataSource = NCollections.Offices.GetAll;
            this.drpOffice.DataBind();

            this.drpUser.DataSource = SecurityCollections.User.GetAll;
            this.drpUser.DataBind();

            this.LoadData();
        }
        this.RefreshPageStatus(this.pageStatus);
    }

    protected void gvMaster_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Select":
                this.SetSelect(e.Item.ItemIndex);
                break;
            case "Edit":
                this.SetEdit(e.Item.ItemIndex);
                break;
            case "Delete":
                this.SetDelete(e.Item.ItemIndex);
                break;
        }
    }

    protected void gvMaster_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
    }

    protected void gvMaster_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        this.gvMaster.CurrentPageIndex = e.NewPageIndex;
        this.LoadData();
    }

    protected void BtnAppend_Click(object sender, EventArgs e)
    {
        this.SetNew();
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        this.SetSave();
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        this.SetCancel();
    }
    #endregion

    #region Methods
    private void SetSelect(int ItemIndex)
    {
        try
        {
            this.gvMaster.SelectedIndex = ItemIndex;
            this.gvMaster.UpdateAfterCallBack = true;
            this.gvMaster.AutoUpdateAfterCallBack = true;
            this.loadControls(Int16.Parse(this.gvMaster.DataKeys[gvMaster.SelectedIndex].ToString()));
        }
        catch
        {
            this.gvMaster.SelectedIndex = -1;
        }
    }

    private void SetNew()
    {
        if (this.pageStatus == HNP.Base.Enum.PageStatus.Edit || this.pageStatus == HNP.Base.Enum.PageStatus.New)
            return;
        this.lblUserOfficeID.Enabled = true;
        this.lblUserOfficeID.Text = "";
        this.drpUser.Enabled = true;
        this.drpOffice.Enabled = true;
        this.pageStatus = HNP.Base.Enum.PageStatus.New;
        this.RefreshPageStatus(this.pageStatus);
    }

    private void SetEdit(int ItemIndex)
    {
        if (this.pageStatus == HNP.Base.Enum.PageStatus.Edit || this.pageStatus == HNP.Base.Enum.PageStatus.New)
            return;
        this.SetSelect(ItemIndex);
        this.lblUserOfficeID.Enabled = true;
        this.drpUser.Enabled = true;
        this.drpOffice.Enabled = true;
        this.pageStatus = HNP.Base.Enum.PageStatus.Edit;
        this.RefreshPageStatus(this.pageStatus);
    }

    private void SetCancel()
    {
        this.lblUserOfficeID.Enabled = false;
        this.drpUser.Enabled = false;
        this.drpOffice.Enabled = false;
        this.pageStatus = HNP.Base.Enum.PageStatus.None;
        this.RefreshPageStatus(this.pageStatus);
        this.loadControls();
    }

    private void SetDelete(int ItemIndex)
    {
        if (this.pageStatus == HNP.Base.Enum.PageStatus.Edit || this.pageStatus == HNP.Base.Enum.PageStatus.New)
            return;
        else
        {
            Int16 key;
            key = Int16.Parse(this.gvMaster.DataKeys[ItemIndex].ToString());
            HNP.Security.Difinition.UserOffice obj;
            obj = HNP.Security.Difinition.SecurityCollections.UserOffice[key];
            if (obj != null)
                if (obj.Delete())
                {
                    LoadData();
                }
        }
    }

    private void SetSave()
    {
        if (this.pageStatus == HNP.Base.Enum.PageStatus.Edit || this.pageStatus == HNP.Base.Enum.PageStatus.New)
        {
            if (this.pageStatus == HNP.Base.Enum.PageStatus.New)
            {
                HNP.Security.Difinition.UserOffice obj = new HNP.Security.Difinition.UserOffice();
                this.ReadControlsValue(obj);
                if (obj.Insert())
                {
                    this.lblRecStatus.Text = "آيتم جديد با موفقيت ثبت شد.";
                    this.LoadData();
                    this.SetCancel();
                }
            }
            else
            {
                Int16 key;
                key = Int16.Parse(this.gvMaster.DataKeys[gvMaster.SelectedIndex].ToString());
                HNP.Security.Difinition.UserOffice obj = HNP.Security.Difinition.SecurityCollections.UserOffice[key];
                this.ReadControlsValue(obj);
                if (obj.Update())
                {
                    this.lblRecStatus.Text = "آيتم مورد نظر با موفقيت تغيير يافت.";
                    this.LoadData();
                    this.SetCancel();
                }
            }
        }
        else
            return;
    }

    private void ReadControlsValue(HNP.Security.Difinition.UserOffice obj)
    {
        if (pageStatus != HNP.Base.Enum.PageStatus.New)
            obj.UserOfficeID = Int16.Parse(this.lblUserOfficeID.Text);

        obj.User = SecurityCollections.User[Int16.Parse(this.drpUser.SelectedValue)];
        obj.Office = NCollections.Offices[Int16.Parse(this.drpOffice.SelectedValue)];
    }

    private void LoadData()
    {
        this.gvMaster.DataSource = HNP.Security.Difinition.SecurityCollections.UserOffice.GetAll;
        this.gvMaster.DataBind();
        this.SetSelect(0);
    }

    private void loadControls(Int16 key)
    {
        HNP.Security.Difinition.UserOffice obj;
        obj = HNP.Security.Difinition.SecurityCollections.UserOffice[key];
        if (obj != null)
        {
            this.lblUserOfficeID.Text = obj.UserOfficeID.ToString();
            this.drpUser.SelectedValue = obj.User.UserID.ToString();
            this.drpOffice.SelectedValue = obj.Office.OfficeID.ToString();
        }
    }

    private void loadControls()
    {
        if (this.gvMaster.SelectedIndex == -1) return;
        Int16 key;
        key = Int16.Parse(this.gvMaster.DataKeys[gvMaster.SelectedIndex].ToString());
        HNP.Security.Difinition.UserOffice obj;
        obj = HNP.Security.Difinition.SecurityCollections.UserOffice[key];
        if (obj != null)
        {
            this.lblUserOfficeID.Text = obj.UserOfficeID.ToString();
            this.drpUser.SelectedValue = obj.User.UserID.ToString();
            this.drpOffice.SelectedValue = obj.Office.OfficeID.ToString();
        }
    }

    private void RefreshPageStatus(HNP.Base.Enum.PageStatus status)
    {
        switch (status)
        {
            case HNP.Base.Enum.PageStatus.View:
                this.lblRecStatus.Text = "نمايش";
                this.BtnAppend.Visible = true;
                this.BtnCancel.Visible = false;
                this.BtnSave.Visible = false;
                break;
            case HNP.Base.Enum.PageStatus.None:
                this.lblRecStatus.Text = "عادي";
                this.BtnAppend.Visible = true;
                this.BtnCancel.Visible = false;
                this.BtnSave.Visible = false;
                break;
            case HNP.Base.Enum.PageStatus.New:
                this.lblRecStatus.Text = "جديد";
                this.BtnAppend.Visible = false;
                this.BtnCancel.Visible = true;
                this.BtnSave.Visible = true;
                break;
            case HNP.Base.Enum.PageStatus.Edit:
                this.lblRecStatus.Text = "ويرايش";
                this.BtnAppend.Visible = false;
                this.BtnCancel.Visible = true;
                this.BtnSave.Visible = true;
                break;
        }
    }
    #endregion

    #region Property
    private HNP.Base.Enum.PageStatus pageStatus
    {
        get
        {
            return (HNP.Base.Enum.PageStatus)this.ViewState["pageStatus"];
        }
        set
        {
            this.ViewState["pageStatus"] = value;
        }
    }
    #endregion
    
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
