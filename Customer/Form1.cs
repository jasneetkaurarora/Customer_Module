using System;
using System.Windows.Forms;
using System.Data;
using Customer.CustomerClasses;

namespace Customer
{
    public partial class CustomerForm : Form
    {
        
        public CustomerForm()
        {
            InitializeComponent();
           
        }
        CustomerClass c = new CustomerClass();

        private void lbl_Surname_Click(object sender, EventArgs e)
        {

        }

        //Update Data in database
        private void button2_Click(object sender, EventArgs e)
        {
            c.ID = int.Parse(txt_ID.Text);
            c.Name = txt_Name.Text;
            c.Surname = txt_Surname.Text;
            c.Telephone = txt_Telephone.Text;
            c.Address = txt_Address.Text;
            bool sucess = c.Update(c);
            if (sucess == true)
            {
                MessageBox.Show("Customer Detail is Successfully Updated.");
                DataTable dt = c.select();
                dgvContactList.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to Update the Detail! Try Again.");
            }
        }

        //Insert Data in Database
        private void btn_Name_Click(object sender, EventArgs e)
        {
            c.Name = txt_Name.Text;
            c.Surname = txt_Surname.Text;
            c.Telephone = txt_Telephone.Text;
            c.Address = txt_Address.Text;
            //Insert Data into database from Insert method
            bool sucess = c.Insert(c);
            if(sucess==true)
            {
                MessageBox.Show("Customer Record Successfully created");
                Clear();
            }
            else
            {
                MessageBox.Show("Insertion Failed ! Try Again");
            }
            DataTable dt = c.select();
            dgvContactList.DataSource = dt;

        }
        
        //To Delete the Data
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            c.ID = Convert.ToInt32(txt_ID.Text);
            bool sucess = c.Delete(c);
            if (sucess == true)
            {
                MessageBox.Show("Selected Customer Sucessfully Deleted.");
                DataTable dt = c.select();
                dgvContactList.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to Delete Contact ! Try Again.");
            }
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            DataTable dt = c.select();
            dgvContactList.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
        //To Close the Form
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Function to Clear the Data from Text boxes
        public void Clear()
        {
            txt_Name.Text = "";
            txt_Surname.Text = "";
            txt_Telephone.Text = "";
            txt_Address.Text = "";
            txt_ID.Text = "";
        }

        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the data from DataGrid View
            int rowIndex = e.RowIndex;
            txt_Name.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            txt_Surname.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            txt_Telephone.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            txt_Address.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
            txt_ID.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
        }

        private void txt_Address_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
