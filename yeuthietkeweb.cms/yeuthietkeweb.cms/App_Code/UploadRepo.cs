using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yeuthietkeweb.cms
{
    public class UploadRepo
    {
        private dbShopDataContext db = new dbShopDataContext();
        public virtual List<Upload> GetByCongtyId(int CongtyId)
        {
            try
            {
                return this.db.Uploads.Where(u => u.CongtyID == CongtyId).ToList();
            }
            catch
            {
                return null;
            }
        }
        public virtual Upload GetById(int id)
        {
            try
            {
                return this.db.Uploads.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual IQueryable GetAll()
        {
            return this.db.Uploads;
        }
        public virtual void Create(Upload Upload)
        {
            try
            {
                this.db.Uploads.InsertOnSubmit(Upload);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(Upload upload)
        {
            try
            {
                Upload UploadOld = this.GetById(upload.ID);
                UploadOld = upload;
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public virtual void Remove(int id)
        {
            try
            {
                Upload Upload = this.GetById(id);
                this.Remove(Upload);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(Upload upload)
        {
            try
            {
                db.Uploads.DeleteOnSubmit(upload);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(int id)
        {
            try
            {
                Upload Upload = this.GetById(id);
                return this.Delete(Upload);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(Upload upload)
        {
            try
            {
                //Upload.IsDelete = true;
                db.SubmitChanges();
                return 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}