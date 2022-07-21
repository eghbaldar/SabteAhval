using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using HNP.Security.Difinition;

public partial class ActivityGroup : System.Web.UI.Page
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

            this.ddlActivity.DataSource = SecurityCollections.Activity.GetAll;
            this.ddlActivity.DataBind();

            this.ddlATA.DataSource = SecurityCollections.ActivityTypeAction.GetAll;
            this.ddlATA.DataBind();

            this.ddlGroup.DataSource = SecurityCollections.Group.GetAll;
            this.ddlGroup.DataBind();

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
        this.lblActivityGroupID.Enabled = true;
        this.lblActivityGroupID.Text = "";
        this.ddlActivity.Enabled = true;
        this.ddlATA.Enabled = true;
        this.ddlGroup.Enabled = true;
        this.pageStatus = HNP.Base.Enum.PageStatus.New;
        this.RefreshPageStatus(this.pageStatus);
    }

    private void SetEdit(int ItemIndex)
    {
        if (this.pageStatus == HNP.Base.Enum.PageStatus.Edit || this.pageStatus == HNP.Base.Enum.PageStatus.New)
            return;
        this.SetSelect(ItemIndex);
        this.lblActivityGroupID.Enabled = true;
        this.ddlActivity.Enabled = true;
        this.ddlATA.Enabled = true;
        this.ddlGroup.Enabled = true;
        this.pageStatus = HNP.Base.Enum.PageStatus.Edit;
        this.RefreshPageStatus(this.pageStatus);
    }

    private void SetCancel()
    {
        this.lblActivityGroupID.Enabled = false;
        this.ddlActivity.Enabled = false;
        this.ddlATA.Enabled = false;
        this.ddlGroup.Enabled = false;
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
            HNP.Security.Difinition.ActivityGroup obj;
            obj = HNP.Security.Difinition.SecurityCollections.ActivityGroup[key];
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
                HNP.Security.Difinition.ActivityGroup obj = new HNP.Security.Difinition.ActivityGroup();
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
                HNP.Security.Difinition.ActivityGroup obj = HNP.Security.Difinition.SecurityCollections.ActivityGroup[key];
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

    private void ReadControlsValue(HNP.Security.Difinition.ActivityGroup obj)
    {
        if (pageStatus != HNP.Base.Enum.PageStatus.New)
            obj.ActivityGroupID = Int16.Parse(this.lblActivityGroupID.Text);
        obj.Activity = SecurityCollections.Activity[Int16.Parse(this.ddlActivity.SelectedValue)];
        obj.ATA = SecurityCollections.ActivityTypeAction[Int16.Parse(this.ddlATA.SelectedValue)];
        obj.Group = SecurityCollections.Group[short.Parse(this.ddlGroup.SelectedValue)];
    }

    private void LoadData()
    {
        this.gvMaster.DataSource = HNP.Security.Difinition.SecurityCollections.ActivityGroup.GetAll;
        this.gvMaster.DataBind();
        this.SetSelect(0);
    }

    private void loadControls(Int16 key)
    {
        HNP.Security.Difinition.ActivityGroup obj;
        obj = HNP.Security.Difinition.SecurityCollections.ActivityGroup[key];
        if (obj != null)
        {
            this.lblActivityGroupID.Text = obj.ActivityGroupID.ToString();
            this.ddlActivity.SelectedValue = obj.Activity.ActivityID.ToString();
            this.ddlATA.SelectedValue = obj.ATA.ATAID.ToString();
            this.ddlGroup.SelectedValue = obj.Group.GroupID.ToString();
        }
    }

    private void loadControls()
    {
        if (this.gvMaster.SelectedIndex == -1) return;
        Int16 key;
        key = Int16.Parse(this.gvMaster.DataKeys[gvMaster.SelectedIndex].ToString());
        HNP.Security.Difinition.ActivityGroup obj;
        obj = HNP.Security.Difinition.SecurityCollections.ActivityGroup[key];
        if (obj != null)
        {
            this.lblActivityGroupID.Text = obj.ActivityGroupID.ToString();
            this.ddlActivity.SelectedValue = obj.Activity.ActivityID.ToString();
            this.ddlATA.SelectedValue = obj.ATA.ATAID.ToString();
            this.ddlGroup.SelectedValue = obj.Group.GroupID.ToString();
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
