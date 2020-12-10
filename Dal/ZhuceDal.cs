using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dal
{
    public class ZhuceDal
    {
        public List<Zhuce> zhuces(string Number, string Pwd) 
        {
            string sql = "select * from Zhucebiao";
            if (Number.Length > 0 && Pwd.Length>0)
            {
                sql += $"and where Number={Number} and Pwd={Pwd}";
            }
            return DbHelper.GetList<Zhuce>(sql);
        }
    }
}
