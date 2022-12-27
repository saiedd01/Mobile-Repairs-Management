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
    public partial class Spares : Form
    {
        Function con;
        public Spares()
        {
            InitializeComponent();
            con = new Function();
            ShowPart();
        }

        private void ShowPart()
        {
            String Query = "Select * from SpareTbl";
            Partlist.DataSource = con.GetData(Query);
        }

        private void clear()
        {
            PartNameTb.Text = "";
            PartCostTb.Text = "";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PartNameTb.Text == "" || PartCostTb.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    String PName = PartNameTb.Text;
                    int PCost = Convert.ToInt32(PartCostTb.Text);
                    String Query = "insert into SpareTbl values ('{0}',{1})";
                    Query = String.Format(Query, PName, PCost);
                    con.SetData(Query);
                    MessageBox.Show("Spare Add !!!!");
                    ShowPart();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (PartNameTb.Text == "" || PartCostTb.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    String PName = PartNameTb.Text;
                    int PCost = Convert.ToInt32(PartCostTb.Text);
                    String Query = "Update SpareTbl set SpName = '{0}', SpCost = {1} where SpCode ={2}";
                    Query = String.Format(Query, PName, PCost , key);
                    con.SetData(Query);
                    MessageBox.Show("Spare Updated !!!!");
                    ShowPart();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int key = 0;
        private void Partlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PartNameTb.Text = Partlist.SelectedRows[0].Cells[1].Value.ToString();
            PartCostTb.Text = Partlist.SelectedRows[0].Cells[2].Value.ToString();
            if (PartNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(Partlist.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Spare");
            }
            else
            {
                try
                {
                    String Query = "Delete from SpareTbl where SpCode = {0}";
                    Query = String.Format(Query, key);
                    con.SetData(Query);
                    MessageBox.Show("Spare Deleted !!!!");
                    ShowPart();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
