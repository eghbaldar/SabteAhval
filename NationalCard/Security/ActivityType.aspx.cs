using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class ActivityType : System.Web.UI.Page
{
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null || Session["User"].GetType().FullName != "HNP.Security.Difinition.User")
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            this.pageStatus = HNP.Base.Enum.PageStatus.None;
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
            this.loadControls(short.Parse(this.gvMaster.DataKeys[gvMaster.SelectedIndex].ToString()));
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
        this.lblActivityTypeID.Enabled = true;
        this.lblActivityTypeID.Text = "";
        this.txtActivityTypeName.Enabled = true;
        this.txtActivityTypeName.Text = "";
        this.pageStatus = HNP.Base.Enum.PageStatus.New;
        this.RefreshPageStatus(this.pageStatus);
    }

    private void SetEdit(int ItemIndex)
    {
        if (this.pageStatus == HNP.Base.Enum.PageStatus.Edit || this.pageStatus == HNP.Base.Enum.PageStatus.New)
            return;
        this.SetSelect(ItemIndex);
        this.lblActivityTypeID.Enabled = true;
        this.txtActivityTypeName.Enabled = true;
        this.pageStatus = HNP.Base.Enum.PageStatus.Edit;
        this.RefreshPageStatus(this.pageStatus);
    }

    private void SetCancel()
    {
        this.lblActivityTypeID.Enabled = false;
        this.txtActivityTypeName.Enabled = false;
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
            short key;
            key = short.Parse(this.gvMaster.DataKeys[ItemIndex].ToString());
            HNP.Security.Difinition.ActivityType obj;
            obj = HNP.Security.Difinition.SecurityCollections.ActivityType[key];
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
              HNP.Security.Difinition.ActivityType obj = new HNP.Security.Difinition.ActivityType();
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
                short key;
                key = short.Parse(this.gvMaster.DataKeys[gvMaster.SelectedIndex].ToString());
                HNP.Security.Difinition.ActivityType obj = HNP.Security.Difinition.SecurityCollections.ActivityType[key];
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

    private void ReadControlsValue(HNP.Security.Difinition.ActivityType obj)
    {
        if (pageStatus != HNP.Base.Enum.PageStatus.New)
            obj.ActivityTypeID = short.Parse(this.lblActivityTypeID.Text);
        obj.ActivityTypeName = this.txtActivityTypeName.Text;
    }

    private void LoadData()
    {
        this.gvMaster.DataSource = HNP.Security.Difinition.SecurityCollections.ActivityType.GetAll;
        this.gvMaster.DataBind();
        this.SetSelect(0);
    }

    private void loadControls(short key)
    {
        HNP.Security.Difinition.ActivityType obj;
        obj = HNP.Security.Difinition.SecurityCollections.ActivityType[key];
        if (obj != null)
        {
        this.lblActivityTypeID.Text = obj.ActivityTypeID.ToString();
        this.txtActivityTypeName.Text = obj.ActivityTypeName.ToString();
        }
    }

    private void loadControls()
    {
    if (this.gvMaster.SelectedIndex == -1) return;
        short key;
        key = short.Parse(this.gvMaster.DataKeys[gvMaster.SelectedIndex].ToString());
        HNP.Security.Difinition.ActivityType obj;
        obj = HNP.Security.Difinition.SecurityCollections.ActivityType[key];
        if (obj != null)
        {
        this.lblActivityTypeID.Text = obj.ActivityTypeID.ToString();
        this.txtActivityTypeName.Text = obj.ActivityTypeName.ToString();
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
