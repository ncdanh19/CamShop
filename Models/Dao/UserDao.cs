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
        //Thêm mới user
        public int Insert(User entity)
        {
            //add obj kiểu user
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        //Phân trang user
        public IEnumerable<User> ListAllPaging(int page,int pageSize)
        {
            //Liệt kê giảm dần
            return db.Users.OrderByDescending(x=>x.ID).ToPagedList(page,pageSize);
        }
        //Lấy id của một user cụ thể
        public User GetById(string userName)
        {
            //Trả về giá trị obj kiểu user hoặc là giá trị default của user
            return db.Users.SingleOrDefault(x => x.userName == userName);
        }

        //Kiểm tra tài khoản trong DB
        public int Login(string username,string password)
        {
            //Tạo giá trị obj hoặc giá trị default
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
        //Kiểm tra username
        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.userName == userName) > 0;
        }
        //Kiểm tra email
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.eMail == email) > 0;
        }
    }
}
