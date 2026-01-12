using System.Data;
using System.Data.SqlClient;

namespace CoreAPIVs2026July25.Models
{
    public class userdb
    {

      

            SqlConnection con= new SqlConnection(@"server=RITHINSUNDAR\SQLEXPRESS;database=DBAngularAPI;Integrated Security=true");
       

        public string InsertDB(UserCls objcls)
        {
            SqlCommand cmd = new SqlCommand("sp_UserInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@na", objcls.Name);
            cmd.Parameters.AddWithValue("@ag", objcls.Age);
            cmd.Parameters.AddWithValue("@addr", objcls.Address);
            cmd.Parameters.AddWithValue("@email", objcls.Email);
            cmd.Parameters.AddWithValue("@photo", objcls.Photo);
            cmd.Parameters.AddWithValue("@una", objcls.Username);
            cmd.Parameters.AddWithValue("@pw", objcls.Password);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return ("Inserted successfully");

        }
        //SqlConnection con2 = new SqlConnection(@"data source=RITHINSUNDAR\\SQLEXPRESS;Initial Catalog=DBAngularAPI;Integrated Security=true");



        public string LoginDB(UserCls objcls)
        {
            try
            {
                string cid = "";
                SqlCommand cmd = new SqlCommand("sp_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@una", objcls.Username);
                cmd.Parameters.AddWithValue("@pw", objcls.Password);
                con.Open();
                cid = cmd.ExecuteScalar().ToString();
                con.Close();
                return cid;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }

        }
        public string GetUserId(UserCls objcls)
        {
            try
            {
                string cid = "";
                SqlCommand cmd = new SqlCommand("sp_Getid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@una", objcls.Username);
                cmd.Parameters.AddWithValue("@pw", objcls.Password);
                con.Open();
                cid = cmd.ExecuteScalar().ToString();
                con.Close();
                return cid;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }

        }
        public UserCls SelectProfileDB(int id)
        {
            var getdata = new UserCls();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_SelectProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", id);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    getdata = new UserCls
                    {
                        UserId = Convert.ToInt32(sdr["UserId"]),
                        Name = sdr["Name"].ToString(),
                        Age = Convert.ToInt32(sdr["Age"]),
                        Address = sdr["Address"].ToString(),
                        Email = sdr["Email"].ToString(),
                        Photo = sdr["Photo"].ToString(),
                    };
                }
                con.Close();
                return getdata;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return getdata;//ok
            }
        }
    }

}
