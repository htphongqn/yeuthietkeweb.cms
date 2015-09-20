using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yeuthietkeweb.cms;
/// <summary>
/// Summary description for UserTypeRepo
/// </summary>
public class UserTypeRepo
{
    public UserTypeRepo()
	{        
		//
		// TODO: Add constructor logic here
		//
    }
    private dbShopDataContext db = new dbShopDataContext();
    public virtual UserType GetById(int id)
    {
        try
        {
            return this.db.UserTypes.Single(u => u.ID == id);
        }
        catch
        {
            return null;
        }
    }
    public virtual IQueryable GetAll()
    {
        return this.db.UserTypes.OrderByDescending(n=>n.Pos);
    }
    public virtual void Create(UserType UserType)
    {
        try
        {
            this.db.UserTypes.InsertOnSubmit(UserType);
            db.SubmitChanges();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    public virtual void Update(UserType UserType)
    {
        try
        {
            UserType UserTypeOld = this.GetById(UserType.ID);
            UserTypeOld = UserType;
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
            UserType UserType = this.GetById(id);
            this.Remove(UserType);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    public virtual void Remove(UserType UserType)
    {
        try
        {
            db.UserTypes.DeleteOnSubmit(UserType);
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
            UserType UserType = this.GetById(id);
            return this.Delete(UserType);
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }
    public virtual int Delete(UserType UserType)
    {
        try
        {
            //UserType.IsDelete = true;
            db.SubmitChanges();
            return 0;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}