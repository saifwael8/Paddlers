using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBapplication
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }
        ////////////////////////////////////////////////////////////////////////////////////
        public int InsertCompany(string name)
        {


            string query = "INSERT INTO Company (company_name) " +
                            "Values ('" + name + "');";

            return dbMan.ExecuteNonQuery(query);

        }
        public DataTable SelectAllCompanies()
        {

            string query = "SELECT DISTINCT company_name FROM Company ";
            return dbMan.ExecuteReader(query);
        }
        public int UpdateCompany(string oldname, string newname)
        {
            string query = "UPDATE Company SET company_name='" + newname + "' WHERE company_name='" + oldname + "';  ";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeleteCompany(string name)
        {
            string query = "DELETE FROM Company WHERE company_name='" + name + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        /////////////////////////////////////////////////////////////////////////////////////////


        public int getCompanyId(string comp_name)
        {
            string query = "SELECT company_id FROM Company WHERE company_name='" + comp_name + "';";
            int result = (int) dbMan.ExecuteScalar(query);

            return result;
        }

        public int getCompanyIdUsername(string username)
        {
            string query = "SELECT company_id FROM Users WHERE username='" + username + "';";
            return (int)dbMan.ExecuteScalar(query);
        }

        public int InsertBranch(string branch_name, int company_id, string location, string city)
        {
            string query = "INSERT INTO Branch (branch_name, company_id, location, city) " +
                        "Values ('" + branch_name + "', '" + company_id + "', '" + location + "', '" + city + "');";

            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable SelectAllBranches(int company_id)
        {
            string query = "SELECT * FROM Branch WHERE company_id=" + company_id + ";";
            return dbMan.ExecuteReader(query);
        }
        public int DeleteBranch(string name, int company_id)
        {
            string query = "DELETE FROM Branch WHERE branch_name='" + name + "' and company_id=" + company_id + ";";
            return dbMan.ExecuteNonQuery(query);
        }
        /////////////////////////////////////////////////////////////////////////////////////////
        public DataTable SelectAllCourts()
        {


            string query = "SELECT Distinct Court.court_name, Court.type,Branch.branch_name  FROM Court, Branch Where Court.branch_id = Branch.branch_id";
            return dbMan.ExecuteReader(query);
        }


        public int UpdateCourt(string old_name, string new_name, string new_type)
        {



            string query = "UPDATE Court SET  court_name='" + new_name + "', type ='" + new_type + "'  WHERE court_name= '" + old_name + "';";

            return dbMan.ExecuteNonQuery(query);


        }
        public int DeleteCourt(string name, string type)
        {

            string query = "DELETE FROM Court WHERE court_name='" + name + "' and type='" + type + "';";
            return dbMan.ExecuteNonQuery(query);

        }
        ////////////////////////////////////////////////////////////////////////////////////////






        //LOGIN PAGE:

        public string getUserType(string username)
        {
            string query = "select type from users where username = '" + username + "';";
            return (string)dbMan.ExecuteScalar(query);
        }

        public string getPassword(string username)
        {
            string query = "select password from users where username = '" + username + "';";
            return (string)dbMan.ExecuteScalar(query);
        }

        public int insertCity(string city)
        {
            string query = "insert into cities values ('" + city + "'); ";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getCities()
        {
            string query = "select * from cities;";
            return dbMan.ExecuteReader(query);
        }

        public int insertUser(string username, string password, string firstName, string lastName, string Address, string PhoneNumber, string companyName, string type)
        {
            int companyId = getCompanyId(companyName);
            if (companyId != 0)
            {
                string query = "INSERT INTO Users (username, password, first_name, last_name, address, phone_number, company_id, type, bio) " +
                               "VALUES ('" + username + "', '" + password + "', '" + firstName + "', '" + lastName + "', '" + Address + "', '" + PhoneNumber + "', '" + companyId + "','"  + type + "','Hi');";
                return dbMan.ExecuteNonQuery(query);
            }
            return 0;
        }


        public int insertCompany(string company)
        {
            string query = "insert into company(company_name) values ('" + company + "'); ";
            return dbMan.ExecuteNonQuery(query);
        }

        public int deleteCompany(string company)
        {
            string query = "delete from company where company_name = '" + company + "'; ";
            return dbMan.ExecuteNonQuery(query);
        }


        public string getFirstName(string username)
        {
            string query = "select first_name from users where username = '" + username + "'; ";
            return (string)dbMan.ExecuteScalar(query);
        }

        public string getLastName(string username)
        {
            string query = "select last_name from users where username = '" + username + "'; ";
            return (string)dbMan.ExecuteScalar(query);
        }

        public string getAddress(string username)
        {
            string query = "select address from users where username = '" + username + "'; ";
            return (string)dbMan.ExecuteScalar(query);
        }
        
        public string getPhoneNumber(string username)
        {
            string query = "select phone_number from users where username = '" + username + "'; ";
            return (string)dbMan.ExecuteScalar(query);
        }

        public string getCompanyName(string username)
        {
            string query = "select company_name from company where company_id = (select company_id from users where username = '" + username + "'); ";
            object result = dbMan.ExecuteScalar(query);

            // Debugging: Check the type of the result

            return (string)result;
        }

        public int updateProfile(string  username, string firstName, string lastName, string address, string phoneNumber)
        {
            string query = "update users set first_name = '" + firstName + "', last_name = '" + lastName + "', address = '" + address + "', phone_number = '" + phoneNumber + "' where username = '" + username + "'; ";
            return dbMan.ExecuteNonQuery(query);
        }

        public int updatePassword(string username, string password)
        {
            string query = "update users set password = '" + password + "' where username = '" + username + "'; ";
            return dbMan.ExecuteNonQuery(query);
        }

        //TODO: SET UNIQUE (COMPANY_ID, BRANCH_NAME) IN DB
        public int updateManager(string username, string branch_name, int company_id)
        {
            string query = "update users set branch_id = (select branch_id from branch where branch_name = '" + branch_name + "' AND company_id = " + company_id + ") where username = '" + username + "'; ";
            return dbMan.ExecuteNonQuery(query);
        }

        public int deleteUser(string username)
        {
            string query = "delete from users where username = '" + username + "'; ";
            return dbMan.ExecuteNonQuery(query);
        }


        public DataTable getManagers(int company_id)
        {
            string query = "select * from users where type = 'manager' and company_id = " + company_id + ";";
            return dbMan.ExecuteReader(query);
        }


        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

    }
}
