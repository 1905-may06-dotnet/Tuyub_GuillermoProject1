using System;
using System.Data; //brings libraries required for applications connected to database
using System.Data.SqlClient; //for SQL

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = "Data Source = gt-dbserver.database.windows.net; Initial Catalog = AdventureWorks; Persist Security Info = True;"+
            "User ID = guillermoT; Password = Kratos0909!";
            string query = "select * from SalesLT.Customer";

            //1. Make a sql connection
            SqlConnection con;
            con = new SqlConnection(conStr); //constr is endpoint
            con.Open();
            //2. fire query

            SqlCommand cmd;
            cmd = new SqlCommand(query, con);
            //3. execute query and get results;
            SqlDataReader dr;
            dr=cmd.ExecuteReader(); //used for select commands can use cmd.executenonquery() - which are used for insert/update/delete
            //unmanaged data
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Console.WriteLine($"Id: {dr[0]} name {dr["FirstName"]} {dr["LastName"]} {dr["MiddleName"]}");
                }//read pulls one record at a time. cannot backtrack- why we should read/store previous records
            }
            con.Close();
        }
    }
}
