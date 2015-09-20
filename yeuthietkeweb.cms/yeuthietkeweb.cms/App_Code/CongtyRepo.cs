using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yeuthietkeweb.cms
{
    public class CongtyRepo
    {
        private dbShopDataContext db = new dbShopDataContext();
        public virtual Congty GetByMasothue(string masothue)
        {
            try
            {
                return this.db.Congties.Single(u => u.MASOTHUE == masothue.Trim());
            }
            catch
            {
                return null;
            }
        }
        public virtual Congty GetById(int id)
        {
            try
            {
                return this.db.Congties.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual IQueryable GetAll()
        {
            return this.db.Congties;
        }
        public virtual void Create(Congty Congty)
        {
            try
            {
                this.db.Congties.InsertOnSubmit(Congty);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(Congty Congty)
        {
            try
            {
                Congty CongtyOld = this.GetById(Congty.ID);
                CongtyOld = Congty;
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
                Congty Congty = this.GetById(id);
                this.Remove(Congty);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(Congty Congty)
        {
            try
            {
                db.Congties.DeleteOnSubmit(Congty);
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
                Congty Congty = this.GetById(id);
                return this.Delete(Congty);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(Congty Congty)
        {
            try
            {
                //Congty.IsDelete = true;
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