using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Repairs_Management
{
    public partial class Repairs : Form
    {
        Function con;
        public Repairs()
        {
            InitializeComponent();
            con = new Function();
            ShowRepairs();
            GetCustomer();
            GetSpare();
        }

        private void ShowRepairs()
        {
            string Query = "Select * from repairTbl";
            RepairsList.DataSource = con.GetData(Query);

        }

        private void GetCustomer()
        {
            string Query = "Select * from CustomerTbl";
            CustCb.DisplayMember = con.GetData(Query).Columns["CustName"].ToString();
            CustCb.ValueMember = con.GetData(Query).Columns["CustCode"].ToString();
            CustCb.DataSource = con.GetData(Query);
        }

        private void GetSpare()
        {
            string Query = "Select * from SpareTbl";
            SpareCb.DisplayMember = con.GetData(Query).Columns["SpName"].ToString();
            SpareCb.ValueMember = con.GetData(Query).Columns["SpCode"].ToString();
            SpareCb.DataSource = con.GetData(Query);
        }

        private void GetCost()
        {
            string Query = "Select * from SpareTbl where SpCode = {0}";
            Query = string.Format(Query, SpareCb.SelectedValue.ToString());
            foreach(DataRow dr in con.GetData(Query).Rows)
            {
                SpareCostTb.Text = dr["SpCost"].ToString();
            }
        }

        private void Repairs_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustCb.SelectedIndex == -1 || PhoneTb.Text == "" || ProblemTb.Text == "" || DNameTb.Text == "" 
                || ModelTb.Text == "" || SpareCb.SelectedIndex == -1 || TotalTb.Text == "" || SpareCostTb.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    string RDate = RepDateTb.Value.Date.ToString("yyyyMMdd");
                    int Customer = Convert.ToInt32(CustCb.SelectedValue.ToString());
                    string CPhone = PhoneTb.Text;
                    string DeviceName = DNameTb.Text;
                    string DeviceModle = ModelTb.Text;
                    string Problem = ProblemTb.Text;
                    int Spare = Convert.ToInt32(SpareCb.SelectedValue.ToString());
                    int Total = Convert.ToInt32(TotalTb.Text);
                    int GrdTotal = Convert.ToInt32(SpareCostTb.Text) + Total;
                    string Query = "insert into repairTbl values ({0},{1},'{2}','{3}','{4}','{5}',{6},{7})";
                    Query = string.Format(Query,RDate ,Customer, CPhone, DeviceName, DeviceModle, Problem, Spare, GrdTotal);
                    con.SetData(Query);
                    MessageBox.Show("Repair Add !!!!");
                    ShowRepairs();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void SpareCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCost();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Data");
            }
            else
            {
                try
                {
                    string Query = "delete from repairTbl where RepCode = {0}";
                    Query = string.Format(Query, key);
                    con.SetData(Query);
                    MessageBox.Show("Repair Deleted !!!!");
                    ShowRepairs();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0; 
        private void RepairsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(RepairsList.SelectedRows[0].Cells[0].Value.ToString());
        }
    }
}
