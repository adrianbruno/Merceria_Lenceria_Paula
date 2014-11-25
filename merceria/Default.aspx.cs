using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        //get the username
        string UserName = txtUserName.Text;

        //create the MD5CryptoServiceProvider object we will use to encrypt the password
        MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
        //create an array of bytes we will use to store the encrypted password
        Byte[] hashedBytes;
        //Create a UTF8Encoding object we will use to convert our password string to a byte array
        UTF8Encoding encoder = new UTF8Encoding();

        //encrypt the password and store it in the hashedBytes byte array
        hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(txtPassword.Text));

        //connect to our db
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        //sql command to add the user and password to the database
        SqlCommand cmd = new SqlCommand("INSERT INTO Users(UserName, Password) VALUES (@UserName, @Password)", conn);
        cmd.CommandType = CommandType.Text;

        //add parameters to our sql query
        cmd.Parameters.AddWithValue("@UserName", UserName);
        cmd.Parameters.AddWithValue("@Password", hashedBytes);

        using (conn)
        {
            //open the connection
            conn.Open();
            //send the sql query to insert the data to our Users table
            cmd.ExecuteNonQuery();
        }

    }
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        //connect to our db
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;
                                                                AttachDbFilename=|DataDirectory|\venta.mdf;
                                                                Integrated Security=True");

        //sql command to add the user to the database
        SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios WHERE login=@UserName and password=HashBytes('MD5',@Password)", conn);
        cmd.CommandType = CommandType.Text;

        //selected where UserName is the current username in txtUserName
        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

        Label1.Enabled = false;

        using (conn)
        {
            //open the connection
            conn.Open();
            //execute query and store results in a sqldatareader
            SqlDataReader rdr = cmd.ExecuteReader();
            //read the data we have selected
            if (rdr.Read())
            {
                //store the password from the db
                Label1.Text = "Todo OK";
                Response.Redirect("principal.aspx");
            }
            else
            {
                Label1.Enabled = true;
                Label1.Text = "Contraseña o nombre de usuario incorrecto, intente nuevamente  !!!"; 
            }
        }

    }
    protected void btnSalir_Click(object sender, EventArgs e)
    {
        txtPassword.Text = "";
        txtUserName.Text = "";

    }
}