using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yeuthietkeweb.cms.pages
{
    public partial class edit_user : System.Web.UI.Page
    {
        private UserRepo _UserRepo = new UserRepo();
        private UserTypeRepo _UserTypeRepo = new UserTypeRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserType();
                LoadInfo();
            }
        }
        private void LoadUserType()
        {
            var list = _UserTypeRepo.GetAll();
            ddlUserType.DataSource = list;
            ddlUserType.DataBind();
        }
        private void LoadInfo()
        {
            int id = Utils.CIntDef(Request.QueryString["id"], 0);
            _UserRepo = new UserRepo();
            User item = _UserRepo.GetById(id);
            if (item != null)
            {
                txtTendangnhap.Disabled = true;
                txtTendangnhap.Value = item.Username;
                txtFullname.Value = item.Fullname;
                txtPhone.Value = item.Phone;
                txtAddress.Value = item.Address;
                ddlUserType.SelectedValue = Utils.CStrDef(item.UserTypeID, "");
                ddlKichhoat.SelectedIndex = Utils.CBoolDef(item.IsActive, false) ? 0 : 1;
            }
            User user = (User)Session["user"];
            if (user != null)
            {
                //ADMIN
                //KETOANVIEN
                //QUANLY
                //GIAONHAN
                string code = getUserTypeCode(user.UserTypeID);
                if (code != "ADMIN")
                {
                    ddlUserType.Enabled = false;
                    btnBack.Visible = false;
                    if (item == null)
                    {
                        Response.Write("<script>alert('Bạn không có quyền truy cập trang này!');location.href='login.aspx'</script>");
                    }
                }
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = Utils.CIntDef(Request.QueryString["id"], 0);
            _UserRepo = new UserRepo();
            User item = _UserRepo.GetById(id);
            if (item != null)
            {
                item.Fullname = txtFullname.Value;
                item.Phone = txtPhone.Value;
                item.Address = txtAddress.Value;
                item.UserTypeID = Utils.CIntDef(ddlUserType.SelectedValue, 0);
                item.IsActive = (ddlKichhoat.SelectedItem.Value == "1") ? true : false;
                _UserRepo.Update(item);
            }
            //Response.Redirect("~/pages/users.aspx");
            lbMessage.Text = "Lưu thành công!";
        }
        public string formatDate(object date)
        {
            return string.Format("{0:dd/MM/yyyy}", date);
        }
        public string getUserTypeCode(object userTypeId)
        {
            int typeid = Utils.CIntDef(userTypeId, 0);
            var userType = _UserTypeRepo.GetById(typeid);
            if (userType != null)
            {
                return userType.Code;
            }
            return "";
        }
    }
}