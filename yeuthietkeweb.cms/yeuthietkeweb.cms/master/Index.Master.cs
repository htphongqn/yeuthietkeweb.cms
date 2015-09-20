using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yeuthietkeweb.cms.master
{
    public partial class Index : System.Web.UI.MasterPage
    {
        private UserTypeRepo _UserTypeRepo = new UserTypeRepo();
        public static int UserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/pages/login.aspx");
            }
            UserID = ((User)Session["user"]).ID;

            User user = (User)Session["user"];
            if (user != null)
            {
                //ADMIN
                //KETOANVIEN
                //QUANLY
                //GIAONHAN
                string code = getUserTypeCode(user.UserTypeID);
                switch (code)
                {
                    case "ADMIN":
                        liBangdieukhien.Visible = true;
                        liGiaonhan.Visible = true;
                        liKetoanvien.Visible = true;
                        liQuanly.Visible = true;
                        liTaikhoan.Visible = true;
                        break;
                    case "QUANLY":
                        liBangdieukhien.Visible = false;
                        liGiaonhan.Visible = true;
                        liKetoanvien.Visible = true;
                        liQuanly.Visible = true;
                        liTaikhoan.Visible = false;
                        break;
                    case "KETOANVIEN":
                        liBangdieukhien.Visible = false;
                        liGiaonhan.Visible = true;
                        liKetoanvien.Visible = true;
                        liQuanly.Visible = false;
                        liTaikhoan.Visible = false;
                        break;
                    case "GIAONHAN":
                        liBangdieukhien.Visible = false;
                        liGiaonhan.Visible = true;
                        liKetoanvien.Visible = false;
                        liQuanly.Visible = false;
                        liTaikhoan.Visible = false;
                        break;
                    default:
                        liBangdieukhien.Visible = false;
                        liGiaonhan.Visible = false;
                        liKetoanvien.Visible = false;
                        liQuanly.Visible = false;
                        liTaikhoan.Visible = false;
                        break;
                }
            }
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