using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yeuthietkeweb.cms.pages
{
    public partial class index : System.Web.UI.Page
    {
        private dbShopDataContext db = new dbShopDataContext();
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
                        liGiaonhan.Visible = true;
                        liKetoanvien.Visible = true;
                        liQuanly.Visible = true;
                        liTaikhoan.Visible = true;
                        break;
                    case "QUANLY":
                        liGiaonhan.Visible = true;
                        liKetoanvien.Visible = true;
                        liQuanly.Visible = true;
                        liTaikhoan.Visible = false;
                        break;
                    case "KETOANVIEN":
                        liGiaonhan.Visible = true;
                        liKetoanvien.Visible = true;
                        liQuanly.Visible = false;
                        liTaikhoan.Visible = false;
                        break;
                    case "GIAONHAN":
                        liGiaonhan.Visible = true;
                        liKetoanvien.Visible = false;
                        liQuanly.Visible = false;
                        liTaikhoan.Visible = false;
                        break;
                    default:
                        liGiaonhan.Visible = false;
                        liKetoanvien.Visible = false;
                        liQuanly.Visible = false;
                        liTaikhoan.Visible = false;
                        break;
                }
            }
            if (!IsPostBack)
            {
                LoadCount();
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
        private void LoadCount()
        {
            //var list = db.Customers.ToList();
            //if (list != null && list.Count > 0)
            //{
            //    lbCountCustomer.Text = list.Count.ToString();
            //}
            //var list2 = db.CustomerSetups.ToList();
            //if (list2 != null && list2.Count > 0)
            //{
            //    lbCountCustomerSetups.Text = list2.Count.ToString();
            //}
            //var list3 = db.Users.ToList();
            //if (list3 != null && list3.Count > 0)
            //{
            //    lbCountUser.Text = list3.Count.ToString();
            //}
        }
    }
}