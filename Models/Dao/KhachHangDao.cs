using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.Dao
{
    public class KhachHangDao
    {
        CamShopDbContext db = null;
        public KhachHangDao()
        {
            db = new CamShopDbContext();
        }
        //Thêm mới user
        public int Insert(KhachHang entity)
        {
            //add obj kiểu user
            db.KhachHangs.Add(entity);
            db.SaveChanges();
            return entity.khachHangID;
        }

        public bool Update(KhachHang entity)
        {
            try
            {
                var user = db.KhachHangs.Find(entity.khachHangID);
                user.hoTen = entity.hoTen;
                user.eMail = entity.eMail;
                user.diaChi = entity.diaChi;
                user.soDienThoai = entity.soDienThoai;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }
        }

        public bool UpdatePassword(KhachHang entity)
        {
            try
            {
                var user = db.KhachHangs.Find(entity.khachHangID);
                user.passWord = entity.passWord;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
         
       
        //Lấy tát cả gái trị của id
        public KhachHang ViewDetail(int id)
        {
            //tìm theo id
            return db.KhachHangs.Find(id);
        }

        //Xóa theo id
        public bool Delete(int id)
        {
            try
            {
                var user = db.KhachHangs.Find(id);
                db.KhachHangs.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Kiểm tra tài khoản trong DB
        public int Login(string username, string password)
        {
            //Tạo giá trị obj hoặc giá trị default
            var result = db.KhachHangs.SingleOrDefault(x => x.userName == username);
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

        //Lấy id của một user cụ thể
        public KhachHang GetById(string userName)
        {
            //Trả về giá trị obj kiểu user hoặc là giá trị default của user
            return db.KhachHangs.SingleOrDefault(x => x.userName == userName);
        }

        //Kiểm tra username
        public bool CheckUserName(string email)
        {
            return db.KhachHangs.Count(x => x.eMail == email) > 0;
        }
        //Kiểm tra email
        public bool CheckEmail(string email)
        {
            return db.KhachHangs.Count(x => x.eMail == email) > 0;
        }

        // kiểm tra passwork
        public bool CheckPassWord(string password)
        {
            return db.KhachHangs.Count(x => x.passWord == password) > 0;
        }
    }
}
