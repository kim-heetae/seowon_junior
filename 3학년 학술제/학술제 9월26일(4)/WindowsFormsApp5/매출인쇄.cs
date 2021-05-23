using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    class 매출인쇄
    {
        public string 날짜
        {
            get;
            set;
        }
        public int 매출금액
        {
            get;
            set;
        }
        public string 결제방법
        {
            get;
            set;
        }
        public 매출인쇄(string item, int q, string t)
        {
            날짜 = item;
            매출금액 = q;
            결제방법 = t;
        }
    }
}
