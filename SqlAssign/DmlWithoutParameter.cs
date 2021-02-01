using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace SqlAssign
{
    class DmlWithoutParameter
    {
            SqlConnection cn =null;
            SqlCommand cmd =null;
            SqlDataReader dr =null;
            public int ShowData()
            {

                try
                {
                    cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3DotNet;Integrated Security=True");
                    cmd = new SqlCommand("select * from EmployeeTab", cn);
                    
                    cn.Open();
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Console.WriteLine($"{dr["EmpId"]}\t {dr["EmpName"]}\t {dr["Salary"]}\t {dr["DeptNo"]}");
                    }
                    return 0;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return 0;
                }
                finally

                {

                    cn.Close();
                }
              


            }
            public int InsertOneRow()
            {
                try
                {
                    Console.WriteLine("****Enter the Emp Name****");
                    var ename = Console.ReadLine();

                    Console.WriteLine("****Enter the Emp Salary****");
                    var esal = Convert.ToSingle(Console.ReadLine());

                    Console.WriteLine("****Enter the Emp dept id****");
                    var did = Convert.ToInt32(Console.ReadLine());

                    cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3DotNet;Integrated Security=True");
                    cmd = new SqlCommand("insert into EmployeeTab values('" + ename + "'," + esal + "," + did + ")", cn);
                    
                    cn.Open();

                    int i = cmd.ExecuteNonQuery();
                    Console.WriteLine("------Added One row-------");
                    ShowData();
                    return i;


                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return 1;
                }
                finally
                {
                    cn.Close();
                }
            }
            public int DeleteOneRow()
            {
                try
                {
                    Console.WriteLine("Enter the Employee Id->");
                    var eid = Convert.ToInt32(Console.ReadLine());
                    cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3DotNet;Integrated Security=True");
                    cmd = new SqlCommand("delete from EmployeeTab where EmpId=" + eid + "", cn);

                    cn.Open();
                
                    int i = cmd.ExecuteNonQuery();
                    Console.WriteLine("----Deleted one Row-----");
                    ShowData();
                    return i;


                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return 1;
                }
                finally
                {
                    cn.Close();
                }
            }

            public int UpadteRow()
            {
                try
                {
                    Console.WriteLine("Enter the employee Id");
                    var eid = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the Emp Name->");
                    var ename = Console.ReadLine();

                    Console.WriteLine("Enter the Emp Salary->");
                    var esal = Convert.ToSingle(Console.ReadLine());

                    Console.WriteLine("Enter the Emp dept id->");
                    var did = Convert.ToInt32(Console.ReadLine());

                    cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3DotNet;Integrated Security=True");
                    cmd = new SqlCommand("update EmployeeTab set EmpName='" + ename + "',Salary=" + esal + ",DeptNo=" + did + " where EmpId=" + eid + "", cn);
                    cn.Open();

                    int i = cmd.ExecuteNonQuery();
                    Console.WriteLine("----Updated one Row-----");
                    ShowData();
                    return i;
                   }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return 1;
                }
                finally
                {
                    cn.Close();

                }
               
            }
            public void SearchOneRow()
            {
                try
                {
                    Console.WriteLine("Enter the Emp ID------\n");
                    int eid = int.Parse(Console.ReadLine());

                    cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3DotNet;Integrated Security=True");
                    cmd = new SqlCommand("select * from EmployeeTab where EmpId=" + eid + "", cn);
                   
                    cn.Open();
                
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        Console.WriteLine($"Emp Name : {dr["empname"].ToString() }");
                        Console.WriteLine($"Salary :  {dr["salary"].ToString() }");
                        Console.WriteLine($"DeptNo : {dr["deptNo"].ToString() }");
                    }
                    ShowData();

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);

                }
                finally
                {
                    dr.Close();
                    cn.Close();
                }
            }
        }
        class DMLWithoutUsingParameter
        {
            static void Main(string[] args)
            {
                DmlWithoutParameter dmw = new DmlWithoutParameter();
                int option;
            Console.WriteLine("*********************************");
            Console.WriteLine("Select option---->");
                dmw.ShowData();
               do
                {

                    Console.WriteLine("Enter option \n1, insert data\n2. Delete Record\n3. Upadte record\n4. Search");
                    option = int.Parse(Console.ReadLine());
                    
                switch (option)

                    {
                        case 1 : dmw.InsertOneRow(); 
                        break;
                        case 2 : dmw.DeleteOneRow();
                        break;
                        case 3 : dmw.UpadteRow(); 
                        break;
                        case 4 : dmw.SearchOneRow(); 
                        break;
                        default : Console.WriteLine("Selected wrong option"); 
                        break;
                    }
                } while (option > 1 && option <= 4);
            }
        }
    }
