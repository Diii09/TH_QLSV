using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TH_QLSV.DBs;
using TH_QLSV.Modles;

namespace TH_QLSV
{
    public partial class Form1 : Form
    {
        static string tbName_TinhThanh = "TinhThanh", tbName_HocSinh= "HocSinh";
        IList<TinhThanh> listTinhThanh;
        IList<HocSinh> listHocSinh;
        public Form1()
        {
            InitializeComponent();

            DBUtil.Load("SQL_QLSVDB");

            var tbTinhThanh = DBUtil.GetTable(tbName_TinhThanh);

            listTinhThanh = new BindingList<TinhThanh>();
            foreach(DataRow row in tbTinhThanh.Rows)
            {
                listTinhThanh.Add(new TinhThanh
                {
                    ID = (int)row["TinhThanhID"],
                    Ten=(string)row["Ten"]
                }); 
            }
            cbTinhThanh.DataSource = listTinhThanh;
            cbTinhThanh.DisplayMember = "Ten";
            cbTinhThanh.ValueMember = "ID";


            btnAdd.Click += BtnAdd_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var tbHS = DBUtil.GetTable(tbName_HocSinh);
            var dtRow = tbHS.NewRow();
            dtRow["SinhVienID"] = txtIDSV.Text;
            dtRow["HovaTen"] = txtHoTen.Text;
           
            dtRow["DateOB"] = dtpNgaySinh.Value;
            dtRow["QueQuanID"] =(int) cbTinhThanh.SelectedValue;
            dtRow["Diem"] = float.Parse(txtDiemTB.Text);
            tbHS.Rows.Add(dtRow);
            var rs = DBUtil.SaveTable(tbHS);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
