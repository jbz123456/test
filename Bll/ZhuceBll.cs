using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;


namespace Bll
{
    public class ZhuceBll
    {
        ZhuceDal dal = new ZhuceDal();
        public int zhuces(string Number, string Pass)
        {
            return dal.zhuces(Number, Pass);
        }
        public Page Xian(int PageIndex, int PageSize)
        {
            return dal.Xian(PageIndex, PageSize);
        }
    }
}
