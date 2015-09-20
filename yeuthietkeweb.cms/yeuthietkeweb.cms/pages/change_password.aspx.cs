using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yeuthietkeweb.cms.pages
{
    public partial class change_password : System.Web.UI.Page
    {
        private UserRepo _UserRepo = new UserRepo();
        private UserTypeRepo _UserTypeRepo = new UserTypeRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
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
                    btnBack.Visible = false;
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
                //item.Username = txtTendangnhap.Value;
                string saft = Security.CreateSalt();
                string password = Security.Encrypt(txtMatkhau.Value, saft);
                item.Saft = saft;
                item.Password = password;
                
                _UserRepo.Update(item);
            }
            //Response.Redirect("~/pages/users.aspx");
            lbMessage.Text = "Đổi mật khẩu thành công!";
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