using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PNationalCard.Entity;
using PNationalCard.Definition;

public partial class Person : System.Web.UI.Page
{
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.pageStatus = HNP.Base.Enum.PageStatus.None;
            this.drpOfficeID.DataSource = PNationalCard.Definition.NCollections.Offices.GetAll;
            this.drpOfficeID.DataBind();

            this.drpStatusID.DataSource = PNationalCard.Definition.NCollections.Status.GetAll;
            this.drpStatusID.DataBind();

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
            this.loadControls(Int64.Parse(this.gvMaster.DataKeys[gvMaster.SelectedIndex].ToString()));
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
        this.txtNationalID.Enabled = true;
        this.txtNationalID.Text = "";
        this.drpOfficeID.Enabled = true;
        this.drpStatusID.Enabled = true;
        this.pageStatus = HNP.Base.Enum.PageStatus.New;
        this.RefreshPageStatus(this.pageStatus);
    }

    private void SetEdit(int ItemIndex)
    {
        if (this.pageStatus == HNP.Base.Enum.PageStatus.Edit || this.pageStatus == HNP.Base.Enum.PageStatus.New)
            return;
        this.SetSelect(ItemIndex);
        this.txtNationalID.Enabled = false;
        this.drpOfficeID.Enabled = true;
        this.drpStatusID.Enabled = true;
        this.pageStatus = HNP.Base.Enum.PageStatus.Edit;
        this.RefreshPageStatus(this.pageStatus);
    }

    private void SetCancel()
    {
        this.txtNationalID.Enabled = false;
        this.drpOfficeID.Enabled = false;
        this.drpStatusID.Enabled = false;
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
            Int64 key;
            key = Int64.Parse(this.gvMaster.DataKeys[ItemIndex].ToString());
            PNationalCard.Entity.Person obj;
            obj = this.Persons[key];
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
                PNationalCard.Entity.Person obj = new PNationalCard.Entity.Person();
                this.ReadControlsValue(obj);
                if (!obj.NationalIDValidate())
                {
                    this.lblRecStatus.Text = "شماره ملي وارد شده معتبر نيست";
                    return;
                }
                if (obj.Insert())
                {
                    this.lblRecStatus.Text = "آيتم جديد با موفقيت ثبت شد.";
                    this.LoadData();
                    this.SetCancel();
                }
            }
            else
            {
                Int64 key;
                key = Int64.Parse(this.gvMaster.DataKeys[gvMaster.SelectedIndex].ToString());
                PNationalCard.Entity.Person obj = this.Persons[key];
                this.ReadControlsValue(obj);
                if (!obj.NationalIDValidate())
                {
                    this.lblRecStatus.Text = "شماره ملي وارد شده معتبر نيست";
                    return;
                }
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

    private void ReadControlsValue(PNationalCard.Entity.Person obj)
    {
        obj.NationalID = Int64.Parse(this.txtNationalID.Text);
        obj.Office = NCollections.Offices[Int16.Parse(this.drpOfficeID.SelectedValue)];
        obj.Status = NCollections.Status[short.Parse(this.drpStatusID.SelectedValue)];
    }

    private void LoadData()
    {
        this.gvMaster.DataSource = this.Persons.GetAll;
        this.gvMaster.DataBind();
        this.SetSelect(0);
    }

    private void loadControls(Int64 key)
    {
        PNationalCard.Entity.Person obj;
        obj = this.Persons[key];
        if (obj != null)
        {
            this.txtNationalID.Text = obj.NationalID.ToString();
            this.drpOfficeID.SelectedValue = obj.Office.OfficeID.ToString();
            this.drpStatusID.SelectedValue = obj.Status.StatusID.ToString();
        }
    }

    private void loadControls()
    {
        if (this.gvMaster.SelectedIndex == -1) return;
        Int64 key;
        key = Int64.Parse(this.gvMaster.DataKeys[gvMaster.SelectedIndex].ToString());
        PNationalCard.Entity.Person obj;
        obj = this.Persons[key];
        if (obj != null)
        {
            this.txtNationalID.Text = obj.NationalID.ToString();
            this.drpOfficeID.SelectedValue = obj.Office.OfficeID.ToString();
            this.drpStatusID.SelectedValue = obj.Status.StatusID.ToString();
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

    private PersonCollection Persons
    {
        get
        {
            PersonCollection obj = new PersonCollection();
            obj.Load();
            return obj;
        }
    }

    #endregion
    protected void drpStatusID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((sender as DropDownList).SelectedIndex != -1)
        {
            this.lblStatusDesc.Text = PNationalCard.Definition.NCollections.Status[short.Parse(this.drpStatusID.SelectedValue)].StatusDesc;
        }
    }
}
