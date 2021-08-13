using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH_QLSV.Modles
{
    class HocSinh
    {
        public int  ID { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public TinhThanh QueQuan { get; set; }
        public float Diem { get; set; }
        //public int QueQuanID { get; set; }
        //public static IList<HocSinh> LoadFromTable(DataTable dt)
        //{
        //    var list = new BindingList<HocSinh>();
        //    foreach(DataRow row in dt.Rows)
        //    {
        //        list.Add(new HocSinh
        //        {
        //            ID=(int)row["SinhVienID"],
        //            HoTen=(string)row["HovaTen"],
        //            NgaySinh=(DateTime)row["DateOB"],
        //            QueQuanID=(int)row["QueQuanID"]
        //        }
                    
        //            )
        //    }
        //}
    }
}
