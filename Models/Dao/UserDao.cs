using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

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

        public IEnumerable<User> ListAllPaging(int page,int pageSize){
            return db.Users.OrderByDescending(x=>x.ID).ToPagedList(page,pageSize);
        }
        
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.userName == userName);
        }

        //Kiểm tra tài khoản trong DB
        public int Login(string username,string password)
        {
            var result = db.Users.SingleOrDefault(x => x.userName == username);
            if (result == null)
                return 0; //Trường hợp tài khoản không tồn tại
            else
            {
                if (result.passWord == password)
                    return 1;
                else
                    return -2;
            }
        }

        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.userName == userName) > 0;
        }

        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.eMail == email) > 0;
        }
    }
}
