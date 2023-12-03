using Infrastruct;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace AbstractSeviceBase
{
    public abstract class AbstractBaseServise<T> where T : class
    {
        AppDBModel _appDB;

        DbSet<T>? _dbSet;

        public AbstractBaseServise(AppDBModel _appDB)
        {
            SetAppDB(_appDB);
        }

        protected virtual void SetAppDB(AppDBModel _appDB)
        {
            this._appDB = _appDB;

            var PropBD = _appDB.GetType().GetProperties().FirstOrDefault(t => t.GetType() == typeof(DbSet<T>));
            if (PropBD == null) { throw new Exception(); }

            _dbSet = PropBD?.GetValue(_appDB) as DbSet<T>;
        }

        protected virtual IEnumerable<T> GetValues()
        {

            _dbSet?.Load();

            return _dbSet;
            //DbSet<T>
        }

        protected virtual T? GetValue<C>(C Id)
        {
            return _dbSet.Find(Id);
        }

        protected virtual T setValue(T value)
        {

            _dbSet.Add(value);
            _appDB.SaveChanges();

            return value;
        }
        protected virtual T UpdValue<C>(C Id,T value)
        {
            if(value == null) { throw new Exception(); }

            if(_dbSet.Find(Id) is T obj)
            {

                (obj as IUpdate<T>).Update(value);
                _appDB.Update(obj);
                _appDB.SaveChanges();

                return obj;
            }

            return setValue(value);
        }

        protected virtual T DelValue(T value)
        {
            _dbSet.Remove(value);
            _appDB.SaveChanges();
            return value;
        }

    }
}
