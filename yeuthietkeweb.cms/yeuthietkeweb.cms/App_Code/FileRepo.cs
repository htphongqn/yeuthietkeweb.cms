using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yeuthietkeweb.cms
{
    public class FileRepo
    {
        private dbShopDataContext db = new dbShopDataContext();
        public virtual List<File> GetByUploadId(int uploadId)
        {
            try
            {
                return this.db.Files.Where(u => u.UploadID == uploadId).ToList();
            }
            catch
            {
                return null;
            }
        }
        public virtual File GetById(int id)
        {
            try
            {
                return this.db.Files.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual IQueryable GetAll()
        {
            return this.db.Files;
        }
        public virtual void Create(File file)
        {
            try
            {
                this.db.Files.InsertOnSubmit(file);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(File file)
        {
            try
            {
                File FileOld = this.GetById(file.ID);
                FileOld = file;
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
                File File = this.GetById(id);
                this.Remove(File);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(File file)
        {
            try
            {
                db.Files.DeleteOnSubmit(file);
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
                File File = this.GetById(id);
                return this.Delete(File);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(File file)
        {
            try
            {
                //File.IsDelete = true;
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