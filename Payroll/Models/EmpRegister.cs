#nullable disable
using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace Payroll.Models;

public class EmpRegister
    {
        public static List<CreateEmpAccount> userlist= new List<CreateEmpAccount>();

        

        public static List<Feedback> feedbacklist = new List<Feedback>();
        
        public static List<Feedback> FeedBackClass()
        {
            using(SqlConnection connection = new SqlConnection("Data Source=ASPIRE1310; Database=payroll; User ID=sa; Password=Aspire@123"))
            {
                List<Feedback> feedbacklist1= new List<Feedback>();
                Console.WriteLine("Entered Datebase");
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter("select*from Feedback",connection);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {
                    Feedback feedback = new Feedback();
                    feedback.Name=dr["Name"].ToString();
                    feedback.Emp_ID=Convert.ToInt32(dr["Emp_ID"]);
                    feedback.Subject=dr["Subject"].ToString();
                    feedback.Message=dr["Message"].ToString();
                    feedbacklist1.Add(feedback);
                }
                return feedbacklist1;
            }
        }
        public static List<CreateSalaryClass> classlist = new List<CreateSalaryClass>();
        public static List<CreateSalaryClass> SalaryClass()
        {
            using(SqlConnection connection = new SqlConnection("Data Source=ASPIRE1310; Database=payroll; User ID=sa; Password=Aspire@123"))
            {
                List<CreateSalaryClass> classlist1= new List<CreateSalaryClass>();
                Console.WriteLine("Entered salary class Datebase");
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter("select*from SalaryClass",connection);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {
                    CreateSalaryClass createSalaryClass = new CreateSalaryClass();
                    createSalaryClass.ClassName=dr["ClassName"].ToString();
                    createSalaryClass.BasicPay=Convert.ToInt32(dr["BasicPay"]);
                    createSalaryClass.Salary=Convert.ToInt32(dr["Salary"]);
                    createSalaryClass.TravelAllowance=Convert.ToInt32(dr["TravelAllowance"]);
                    createSalaryClass.MedicalAlowance=Convert.ToInt32(dr["MedicalAlowance"]);
                    createSalaryClass.InternetAllowance=Convert.ToInt32(dr["InternetAllowance"]);

                    classlist1.Add(createSalaryClass);
                }
                return classlist1;
            }
        }
        public static List<CreateEmpAccount> EmployeeRegister()
        {
                using (SqlConnection connection = new SqlConnection("Data Source=ASPIRE1310; Database=payroll; User ID=sa; Password=Aspire@123"))
                {
                List<CreateEmpAccount> userlist1= new List<CreateEmpAccount>();
                Console.WriteLine("Entered Datebase");
                connection.Open();

               SqlDataAdapter dataAdapter = new SqlDataAdapter("select*from EmployeeDetail",connection);
               DataTable dataTable = new DataTable();

              dataAdapter.Fill(dataTable);

            foreach (DataRow dr in dataTable.Rows)
            {
                    CreateEmpAccount createEmpAccount = new CreateEmpAccount();
                    createEmpAccount.Name=dr["Name"].ToString();
                    createEmpAccount.Address=dr["Address"].ToString();
                    createEmpAccount.Gender=dr["Gender"].ToString();
                    createEmpAccount.City=dr["City"].ToString();
                    createEmpAccount.Pincode=dr["Pincode"].ToString();
                    createEmpAccount.Mobile=dr["Mobile"].ToString();
                    createEmpAccount.EmpID=Convert.ToInt32(dr["Emp_ID"]);
                    createEmpAccount.Salary=dr["Salary"].ToString();
                    createEmpAccount.Department=dr["Department"].ToString();
                    createEmpAccount.BankAccNo=dr["BankAccount"].ToString();
                    createEmpAccount.Email=dr["Email"].ToString();
                    createEmpAccount.Password=dr["Password"].ToString();

                    userlist1.Add(createEmpAccount);                   
                }
                 return userlist1;
                }                
            
        }
        public static void DisplayTable()
        {
            try  
            {  
            using(SqlConnection connection = new SqlConnection("Data Source=ASPIRE1310; Database=payroll; User ID=sa; Password=Aspire@123"))
            {
                connection.Open();
                SqlCommand cm = new SqlCommand("select * from EmployeeDetail", connection);
                SqlDataReader sdr = cm.ExecuteReader();  
                while (sdr.Read())  
                {  
                    Console.WriteLine(sdr["Emp_ID"]+" "+ sdr["Name"]+" "+ sdr["Address"]+" "+ sdr["Gender"]+" "+ sdr["City"]+" "+ sdr["Pincode"]+" "+ sdr["Mobile"] +" "+ sdr["Salary"]+ sdr["Department"]+" "+ sdr["BankAccount"]+" "+ sdr["Email"]+" "+ sdr["Password"]);  
                }  
                connection.Close();  
            }
            }
            catch(SqlException e)
            {
                System.Console.WriteLine(e.Message);
            }
            catch (Exception e)  
            {  
                Console.WriteLine("OOPs, something went wrong." + e);  
            }       
            
        }

        public static int addsalaryClass(CreateSalaryClass salary)
        {
            string className=salary.ClassName;
            bool nameFlag = true;

            List<CreateSalaryClass> classlist1=SalaryClass();

            if(className!=null)
                {

            foreach (CreateSalaryClass item in classlist1)
            {
                
                
                if(string.Equals(item.ClassName,className))
                {
                    nameFlag=false;
                }

            }
            if(nameFlag==true)
            {
            using(SqlConnection connection = new SqlConnection("Data Source=ASPIRE1310; Database=payroll; User ID=sa; Password=Aspire@123"))
             {
                connection.Open();
                System.Console.WriteLine(salary.ClassName +"####"+salary.BasicPay);
                SqlCommand insertCommand = new SqlCommand("Insert into SalaryClass values ('"+salary.ClassName+"',"+salary.BasicPay+", "+salary.Salary+","+salary.TravelAllowance+" ,"+salary.MedicalAlowance+" , "+salary.InternetAllowance+" )",connection);
                insertCommand.ExecuteNonQuery();
             }
             return 1;
            }
            return 2;
                }
                return 3;
        }
        public static int signUpValidation(CreateEmpAccount newEmpAcc)
        {
            string userName=newEmpAcc.Name;
            string email=newEmpAcc.Email;
            string password=newEmpAcc.Password;
            string RePassword=newEmpAcc.RePassword;
            bool userNameFlag=true;
            bool emailFlag=true;
            List<CreateEmpAccount> userList = EmployeeRegister();

            
            foreach (CreateEmpAccount item in userlist)
            {
                if(string.Equals(userName,item.Name))
                {
                    userNameFlag=false;
                }
            }
            foreach (CreateEmpAccount item in userlist)
            {
                if(String.Equals(email,item.Email))
                {
                    emailFlag=false;
                    Console.WriteLine("Email");
                }
                                
            }
            if(userNameFlag==true)
            {
                    if(String.Equals(password,RePassword))
                    {
                        if (emailFlag==true)
                        {
                        
                            using(SqlConnection connection = new SqlConnection("Data Source=ASPIRE1310; Database=payroll; User ID=sa; Password=Aspire@123"))
                            {
                                connection.Open();
                                
                                SqlCommand insertCommand = new SqlCommand("Insert into EmployeeDetail (Name,Address,Emp_ID,Gender,City,Pincode,Mobile,Salary,Department,BankAccount,Email,Password) values('"+userName+"','"+newEmpAcc.Address+"','"+newEmpAcc.EmpID+"','"+newEmpAcc.Gender+"','"+newEmpAcc.City+"','"+newEmpAcc.Pincode+"','"+newEmpAcc.Mobile+"','"+newEmpAcc.Salary+"','"+newEmpAcc.Department+"','"+newEmpAcc.BankAccNo+"','"+email+"','"+password+"');",connection);

                                insertCommand.ExecuteNonQuery();
                            }
                            return 1;
                        }return 4; 
                    }return 2;                 
            }return 3;
        }

        public static List<CreateAdminAcc> adminlist= new List<CreateAdminAcc>();
        public static List<CreateAdminAcc> AdminRegister()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=ASPIRE1310; Database=payroll; User ID=sa; Password=Aspire@123"))
                {
                Console.WriteLine("Entered Datebase");
                connection.Open();
                SqlCommand sqlCommand=new SqlCommand("select * from Admin_Credential",connection);
                SqlDataReader sqlReader=sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    CreateAdminAcc admin = new CreateAdminAcc();
                    admin.UserName=sqlReader["UserName"].ToString();
                    admin.Email=sqlReader["Email"].ToString();
                    admin.Password=sqlReader["Password"].ToString();
                    
                    adminlist.Add(admin);                   
                }
                }                
            }
            
            catch (SqlException exception)
            {                  
                Console.WriteLine("Datebase error"+exception);               
            }
            return adminlist;
        }
        public static int AddAdmin(CreateAdminAcc admin)
        {
            string userName = admin.UserName;
            string email = admin.Email;
            string password = admin.Password;
            string confirmPass = admin.RePassword;
            bool userNameflag = true;
            bool emailFlag = true;

            List<CreateAdminAcc> adminList = AdminRegister();

            foreach(CreateAdminAcc item in adminList)
            {
                if(String.Equals(userName,item.UserName))
                {
                    userNameflag = false;
                }
            }
            foreach(CreateAdminAcc item in adminList)
            {
                if(String.Equals(email,item.Email))
                {
                    emailFlag = false;
                }
            }
            if(userNameflag == true)
            {
                if(String.Equals(password,confirmPass))
                {
                    if(emailFlag == true)
                    {
                        using(SqlConnection connection = new SqlConnection("Data Source=ASPIRE1310; Database=payroll; User ID=sa; Password=Aspire@123"))
                            {
                                connection.Open();
                                
                                SqlCommand insertCommand = new SqlCommand("Insert into Admin_Credential (UserName,Email,Password) values('"+userName+"','"+email+"','"+password+"');",connection);

                                insertCommand.ExecuteNonQuery();
                            }
                            System.Console.WriteLine("inserted");
                            return 4;
                    }
                    System.Console.WriteLine("Email Exist");
                    return 3;
                }
                System.Console.WriteLine("Password Wrong");
                return 2;
            }
            System.Console.WriteLine("UserName Exist");
            return 1;
        }
        public static CreateEmpAccount searchEmployee(int EmployeeID)
        {
        
                using(SqlConnection connection = new SqlConnection("Data Source=ASPIRE1310; Database=payroll; User ID=sa; Password=Aspire@123"))
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                    DataTable dataTable = new DataTable();
                    Console.WriteLine("Entered");
                    CreateEmpAccount employee =new CreateEmpAccount();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter($"select * from EmployeeDetail where Emp_ID={EmployeeID}",connection);

                    dataAdapter.Fill(dataTable);

                    foreach(DataRow row in dataTable.Rows)
                    {
                        employee.Name=Convert.ToString(row["Name"]);
                        employee.Address=Convert.ToString(row["Address"]);
                        employee.EmpID=Convert.ToInt32(row["Emp_ID"]);                       
                        employee.Gender=Convert.ToString(row["Gender"]);
                        employee.City=Convert.ToString(row["City"]);
                        employee.Pincode=Convert.ToString(row["Pincode"]);
                        employee.Mobile=Convert.ToString(row["Mobile"]);
                        employee.Salary=Convert.ToString(row["Salary"]);
                        employee.Department=Convert.ToString(row["Department"]);
                        employee.BankAccNo=Convert.ToString(row["BankAccount"]);
                        employee.Email=Convert.ToString(row["Email"]);
                    }
                 return employee;   
                }      
        }

        public static int idCount()
        {
           
                using(SqlConnection connection = new SqlConnection("Data Source=ASPIRE1310; Database=payroll; User ID=sa; Password=Aspire@123"))
                {
                    connection.Open();
                    SqlCommand Cmnd = new SqlCommand($"SELECT COUNT(Emp_ID) FROM EmployeeDetail", connection);
                    int CountID = Convert.ToInt32(Cmnd.ExecuteScalar());
                    System.Console.WriteLine(CountID);
                    return CountID;
                }
        }

        public static int EmpSignin(EmpSignin emp)
        {
            string email = emp.Email;
            string password = emp.Password;
            List<CreateEmpAccount> empList = EmployeeRegister();
            foreach(CreateEmpAccount item in empList)
            {
                if(String.Equals(email,item.Email) && String.Equals(password,item.Password))
                {
                    return 1;
                }
            }
            return 2;
        }

        public static int adminLogin(AdminLogin admin)
        {
            string userName = admin.UserName;
            string password = admin.Password;
            List<CreateAdminAcc> adminList = AdminRegister();
            foreach(CreateAdminAcc item in adminList)
            {
                if(String.Equals(userName,item.UserName) && String.Equals(password,item.Password))
                {
                    return 1;
                }
            }
            return 2;
        }

        public static int UpdateEmployee(CreateEmpAccount emp)
        {
            string name = emp.Name;
            string address = emp.Address;
            int empID = emp.EmpID;
            string gender = emp.Gender;
            string city = emp.City;
            string pincode = emp.Pincode;
            string mobile = emp.Mobile;
            string salary = emp.Salary;
            string department = emp.Department;
            string bankAccNo = emp.BankAccNo;
            string email = emp.Email;
            try
            {
                using(SqlConnection connection = new SqlConnection("Data Source=ASPIRE1310; Database=payroll; User ID=sa; Password=Aspire@123"))
                {
                    connection.Open();
                    SqlCommand updateCommand = new SqlCommand($"Update EmployeeDetail set Name='{name}',Address='{address}',Gender='{gender}',City='{city}',Pincode='{pincode}',Mobile='{mobile}',Salary='{salary}',Department='{department}',BankAccount='{bankAccNo}',Email='{email}' where Emp_ID={empID}",connection);
                    updateCommand.ExecuteNonQuery();
                }
                return 1;
            }
            catch(SqlException e)
            {
                System.Console.WriteLine(e.Message);
                return 2;
            }
        }

        public static int DeleteEmployee(int empID)
        {
          
                using(SqlConnection connection = new SqlConnection("Data Source=ASPIRE1310; Database=payroll; User ID=sa; Password=Aspire@123"))
                {
                    connection.Open();
                    SqlCommand deleteCommand = new SqlCommand($"Delete from EmployeeDetail where Emp_ID={empID}",connection);
                    deleteCommand.ExecuteNonQuery();
                }
                return 1;
            
            
        }
        

    }
