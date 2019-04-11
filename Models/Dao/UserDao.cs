using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.Dao
{
    public class UserDao
    {
        CamShopDbContext db = null;
        public UserDao()
        {
            db = new CamShopDbContext();
        }
        public int Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.userName == userName);
        }
        public bool Login(string username,string password)
        {
            var result = db.Users.Count(x => x.userName == username && x.passWord == password);
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
