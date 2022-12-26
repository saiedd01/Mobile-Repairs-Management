﻿using System;
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
    public partial class Customers : Form
    {
        Function con;
        public Customers()
        {
            InitializeComponent();
            con = new Function();
            ShowCustomer();
        }

        private void ShowCustomer()
        {
            String Query = "Select * from CustomerTbl";
            Customerlist.DataSource = con.GetData(Query);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(CustNameTb.Text == "" || CustAddTb.Text == "" || CustPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    String CName = CustNameTb.Text;
                    String CPhone = CustPhoneTb.Text;
                    String CAddress = CustAddTb.Text;
                    String Query = "insert into CustomerTbl values ('{0}','{1}','{2}')";
                    Query = String.Format(Query, CName, CPhone, CAddress);
                    con.SetData(Query);
                    MessageBox.Show("Customer Add !!!!");
                    ShowCustomer();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int key = 0;
        private void Customerlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustNameTb.Text = Customerlist.SelectedRows[0].Cells[1].Value.ToString();
            CustPhoneTb.Text = Customerlist.SelectedRows[0].Cells[2].Value.ToString();
            CustAddTb.Text = Customerlist.SelectedRows[0].Cells[3].Value.ToString();
            if(CustNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(Customerlist.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" || CustAddTb.Text == "" || CustPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    String CName = CustNameTb.Text;
                    String CPhone = CustPhoneTb.Text;
                    String CAddress = CustAddTb.Text;
                    String Query = "Update CustomerTbl set CustName ='{0}', CustPhone = '{1}', CustAdd = '{2}' where CustCode = {3}";
                    Query = String.Format(Query, CName, CPhone, CAddress, key);
                    con.SetData(Query);
                    MessageBox.Show("Customer Updated !!!!");
                    ShowCustomer();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Customer");
            }
            else
            {
                try
                {
                    String Query = "Delete from CustomerTbl where CustCode = {0}";
                    Query = String.Format(Query, key);
                    con.SetData(Query);
                    MessageBox.Show("Customer Deleted !!!!");
                    ShowCustomer();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
