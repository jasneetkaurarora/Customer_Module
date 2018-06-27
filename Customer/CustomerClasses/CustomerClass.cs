using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Customer.CustomerClasses
{
    class CustomerClass
    {
        //Getter And Setter properties
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Telephone { get; set; }
        public String Address { get; set; }
        public int ID { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        //Selecting Data from database
        public DataTable select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM tbl_Customer";
                SqlCommand cmd = new SqlCommand(sql,conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        //Method to Insert Data in Database
        public bool Insert(CustomerClass c)
        {
            bool isSucess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO tbl_Customer(Name,Surname,Telephone,Address) VALUES (@Name,@Surname,@Telephone,@Address)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", c.Name);
                cmd.Parameters.AddWithValue("@Surname", c.Surname);
                cmd.Parameters.AddWithValue("@Telephone", c.Telephone);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSucess = true;
                }
                else
                {
                    isSucess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSucess;

        }
        //Method to update data in database
        public bool Update(CustomerClass c)
        {
            bool isSucess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE tbl_Customer SET Name=@Name, Surname=@Surname, Telephone=@Telephone, Address=@Address WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", c.Name);
                cmd.Parameters.AddWithValue("@Surname", c.Surname);
                cmd.Parameters.AddWithValue("@Telephone", c.Telephone);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@ID", c.ID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSucess = true;
                }
                else
                {
                    isSucess = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSucess;
        }
        //Mmethod to Delete data from database
        public bool Delete(CustomerClass c)
        {
            bool isSucess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "DELETE FROM tbl_Customer where ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", c.ID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSucess = true;
                }
                else
                {
                    isSucess = false;
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return isSucess;
        }

    }
}
