using System;
using System.Collections.Generic;

namespace Generics_And_Collections
{
    //public class GenericRepository<T> : IGenericRepository<T> where T : class
    //{
    //    private DBContext context = null;
    //    private DbSet<T> table = null;
    //    public GenericRepository()
    //    {
    //        this.context = new DBContext();
    //        table = context.Set<T>();
    //    }
    //    public GenericRepository(DBContext context)
    //    {
    //        this.context = context;
    //        table = context.Set<T>();
    //    }
    //    public IEnumerable<T> GetAll()
    //    {
    //        return table.ToList();
    //    }
    //    public T GetById(object id)
    //    {
    //        return table.Find(id);
    //    }
    //    public void Insert(T obj)
    //    {
    //        table.Add(obj);
    //    }
    //    public void Update(T obj)
    //    {
    //        table.Attach(obj);
    //        context.Entry(obj).State = EntityState.Modified;
    //    }
    //    public void Delete(object id)
    //    {
    //        T existing = table.Find(id);
    //        table.Remove(existing);
    //    }
    //    public void Save()
    //    {
    //        context.SaveChanges();
    //    }
    //}
}
