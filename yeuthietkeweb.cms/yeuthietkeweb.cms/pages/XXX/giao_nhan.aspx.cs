using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace yeuthietkeweb.cms.pages
{
    public partial class giao_nhan : System.Web.UI.Page
    {
        private CongtyRepo _CongtyRepo = new CongtyRepo();
        private UploadRepo _UploadRepo = new UploadRepo();
        private FileRepo _FileRepo = new FileRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadNam();
            }
        }
        private void loadNam()
        {
            for (int i = 2000; i <= DateTime.Now.Year; i++)
            {
                ddlNam.Items.Add(new ListItem(i.ToString(), i.ToString()));   
            }
            ddlNam.Text = DateTime.Now.Year.ToString();
        }
        protected void txtMasothue_TextChanged(object sender, EventArgs e)
        {
            if (txtMasothue.Text == "")
            {
                Response.Write("<script>alert('Chưa nhập mã số thuế!')</script>");
                return;
            }
            var item = _CongtyRepo.GetByMasothue(txtMasothue.Text);
            if (item != null)
            {
                txtTencongty.Value = item.TENCONGTY;
                txtAddress.Value = item.DIACHI;
                lbMessage.Text = "<span style='color:red'> Mã số thuế đã có trong database!</span>";
            }
            else
            {
                lbMessage.Text = "<span style='color:red'> Mã số thuế mới!</span>";
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/pages/login.aspx");
            }
            int UserID = ((User)Session["user"]).ID;
            var item = _CongtyRepo.GetByMasothue(txtMasothue.Text);
            if (item != null)
            {
                var upload = new Upload();
                upload.CongtyID = item.ID;
                upload.NAM = Utils.CIntDef(ddlNam.SelectedItem.Value, 0);
                upload.KY = Utils.CIntDef(ddlKy.SelectedItem.Value, 0);
                upload.NGAYTAO = DateTime.Now;
                upload.UserID = UserID;

                _UploadRepo.Create(upload);

                string pathfile = Server.MapPath("/Files/" + item.MASOTHUE);
                if (!Directory.Exists(pathfile))
                {
                    Directory.CreateDirectory(pathfile);
                }
                HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        string filename = System.IO.Path.GetFileName(hpf.FileName);
                        string fullpathfile = pathfile + "/" + filename;
                        var file = new File();
                        file.UploadID = upload.ID;
                        file.Filename = filename;
                        _FileRepo.Create(file);

                        hpf.SaveAs(fullpathfile);                        
                    }
                }              
            }
            else
            {
                item = new Congty();
                item.MASOTHUE = txtMasothue.Text;
                item.TENCONGTY = txtTencongty.Value;
                item.DIACHI = txtAddress.Value;
                item.NGAYTAO = DateTime.Now;
                item.UserID = UserID;

                _CongtyRepo.Create(item);

                var upload = new Upload();
                upload.CongtyID = item.ID;
                upload.NAM = Utils.CIntDef(ddlNam.SelectedItem.Value, 0);
                upload.KY = Utils.CIntDef(ddlKy.SelectedItem.Value, 0);
                upload.NGAYTAO = DateTime.Now;
                upload.UserID = UserID;

                _UploadRepo.Create(upload);

                string pathfile = Server.MapPath("/Files/" + item.MASOTHUE);
                if (!Directory.Exists(pathfile))
                {
                    Directory.CreateDirectory(pathfile);
                }
                HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        string filename = System.IO.Path.GetFileName(hpf.FileName);
                        string fullpathfile = pathfile + "/" + filename;
                        var file = new File();
                        file.UploadID = upload.ID;
                        file.Filename = filename;
                        _FileRepo.Create(file);

                        hpf.SaveAs(fullpathfile);
                    }
                }   
            }
            Response.Write("<script>alert('Lưu thành công!');location.href='giao_nhan.aspx'</script>");
        }

    }
}