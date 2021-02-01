using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace SqlAssign
{
    class DmlUsingParameters
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
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
                    Console.WriteLine($"{dr["EmpId"]}\t{dr["EmpName"]}\t{dr["Salary"]}\t{dr["DeptNo"]}");
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
        public int InsertWithParameters()
        {
            try
            {
                Console.WriteLine("Enter the Employee Name");
                var ename = Console.ReadLine();
               
                Console.WriteLine("Enter Employee Salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                
                Console.WriteLine("Enter the Employee dept id");
                var did = Convert.ToInt32(Console.ReadLine());

                cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("insert into EmployeeTab values(@ename,@esal,@deptId)", cn);
                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                cmd.Parameters.Add("@deptId", SqlDbType.Int).Value = did;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("------------added one row----------");
                ShowData();
                return i;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
            
        }
        public int DeleteWithParameters()
        {
            try
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Enter the Employee Id");
                var eid = Convert.ToInt32(Console.ReadLine());

                cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("delete from EmployeeTab where EmpId=@eid", cn);
               
                cmd.Parameters.Add("@eid", SqlDbType.Int).Value = eid;
                cn.Open();

                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("--------one row deleted--------");
                ShowData();
                return i;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }

        }
        public int UpdateWithParameters()
        {
            try
            {
                Console.WriteLine("------------------");
                Console.WriteLine("Enter the Employee Id->");

                var eid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Emp Name->");

                var ename = Console.ReadLine();
                Console.WriteLine("Enter the Emp Salary->");

                var esal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter the Emp dept id->");

                var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("update EmployeeTab set EmpName=@ename,Salary=@esal,DeptNo=@did where EmpId=@empid", cn);
                cmd.Parameters.Add("@empId", SqlDbType.Int).Value = eid;
                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                cmd.Parameters.Add("@did", SqlDbType.Int).Value = did;
                cn.Open();

                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("-----------one row updated------------");
                ShowData();
                return i;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }

        }

        public void SearchWithParameters()
        {
            try
            {
                Console.WriteLine("Enter the Employee Id->");
                var eid = Convert.ToInt32(Console.ReadLine());

                cn = new SqlConnection("Data Source=.;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select * from EmployeeTab where EmpId=@empid", cn);
                cmd.Parameters.Add("@empId", SqlDbType.Int).Value = eid;
                cn.Open();

                dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["EmpName"]}\t {dr["Salary"]}\t {dr["DeptNo"]}");
                }
                ShowData();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
            finally
            {
                dr.Close();
                cn.Close();
            }

        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            DmlUsingParameters dm = new DmlUsingParameters();
            Console.WriteLine("----------------------");
            int option;
            dm.ShowData();
           Console.WriteLine("Select option======================>>");
            do
            {
                dm.ShowData();
                Console.WriteLine("Enter the option \n1, insert data\n2. Update Record\n3. Delete record\n4. Search");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1: dm.InsertWithParameters(); 
                        break;
                    case 2: dm.UpdateWithParameters(); 
                        break;
                    case 3: dm.DeleteWithParameters(); 
                        break;
                    case 4: dm.SearchWithParameters(); 
                        break;
                    default: Console.WriteLine("---wrong option selected---"); 
                        break;
                }
            } while (option >= 1 && option <= 4);
        }
    }
}