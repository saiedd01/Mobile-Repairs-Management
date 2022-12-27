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
            String Query = "Select * from repairTbl";
            RepairsList.DataSource = con.GetData(Query);

        }

        private void GetCustomer()
        {
            String Query = "Select * from CustomerTbl";
            CustCb.DisplayMember = con.GetData(Query).Columns["CustName"].ToString();
            CustCb.ValueMember = con.GetData(Query).Columns["CustCode"].ToString();
            CustCb.DataSource = con.GetData(Query);
        }

        private void GetSpare()
        {
            String Query = "Select * from SpareTbl";
            SpareCb.DisplayMember = con.GetData(Query).Columns["SpName"].ToString();
            SpareCb.ValueMember = con.GetData(Query).Columns["SpCode"].ToString();
            SpareCb.DataSource = con.GetData(Query);
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
                    String RDate = RepDateTb.Value.ToString();
                    int Customer = Convert.ToInt32(CustCb.SelectedValue.ToString());
                    String CPhone = PhoneTb.Text;
                    String DeviceName = DNameTb.Text;
                    String DeviceModle = ModelTb.Text;
                    String Problem = ProblemTb.Text;
                    int Spare = Convert.ToInt32(SpareCb.SelectedValue.ToString());
                    int Total = Convert.ToInt32(TotalTb.Text);
                    String Query = "insert into repairTbl values ('{0}',{1},'{2}','{3}','{4}','{5}',{6},{7})";
                    Query = String.Format(Query,RDate ,Customer, CPhone, DeviceName, DeviceModle, Problem, Spare, Total);
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
    }
}
