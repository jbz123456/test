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
        public int zhuces(string Number, string Pass) 
        {
            string sql = $"select Count(1) from Zhucebiao where Number='{Number}' and  Pass='{Pass}'";
            int i = DbHelper.ExecuteScalar(sql);
            return i;
        }
        public Page Xian(int PageIndex,int PageSize)
        {
            string sql = "select * from Zhucebiao where 1=1";
            string sqlcount = "select count(1) from Zhucebiao where 1=1";
            sql += $"order by Id offset {(PageIndex - 1) * PageSize}  row fetch next {PageSize} row only ";

            int Totalcount = DbHelper.ExecuteScalar(sqlcount);

            List<Zhuce> list = DbHelper.GetList<Zhuce>(sql);

            int rowcount = Convert.ToInt32(Math.Ceiling(Totalcount * 1.0 / PageSize));

            Page pagre = new Page()
            {
                PageIndex = PageIndex,
                PageSize = PageSize,
                TotalCount = Totalcount,
                RowCount = rowcount,
                Data=list
            };
            return pagre;

        }
    }
}
