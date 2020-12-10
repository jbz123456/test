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
        public List<Zhuce> zhuces(string Number, string Pwd)
        {
            return dal.zhuces(Number, Pwd);
        }
    }
}
