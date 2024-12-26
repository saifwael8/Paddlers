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
        public int UpdateCompany(string oldname,string newname)
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

        
        public int? getcompanyid(string comp_name)
        {
            string query = "SELECT sum(company_id) FROM Company WHERE company_name='" + comp_name + "';";
            DataTable result = dbMan.ExecuteReader(query);

            if (result != null && result.Rows.Count > 0) // Ensure the DataTable has data
            {
                object value = result.Rows[0][0]; // Access the first row, first column
                if (value != DBNull.Value) // Check if the value is not NULL
                {
                    int sum = Convert.ToInt32(value); // Convert to integer
                    return sum;
                }
            }


            // Check if the result is valid
            if (result != null && int.TryParse(result.ToString(), out int companyId))
            {
                return companyId; // Return the valid company ID
            }

            return null; // Return null if no result or invalid result
        }
        
        public int? getbranchid(string branch_name, string company_name)
        {
            int? cid = getcompanyid(company_name);
            string query = "SELECT branch_id  FROM Branch  WHERE branch_name='" + branch_name + "' and company_id='" + cid + "';";
            object res =dbMan.ExecuteScalar(query);
            if (cid.HasValue)
            {
                if (res != null && int.TryParse(res.ToString(), out int branchId))
                {
                    return branchId; // Return the valid company ID
                }

                return null;
            }
            return 0;
        }
        public int InsertBranch(string branch_name, string company_name, string location, string city)
        {
            string r = company_name;
            int? cid = getcompanyid(r);     
            if (cid.HasValue)
            {  

                string query = "INSERT INTO Branch (branch_name,company_id, location, city) " +
                            "Values ('" + branch_name + "', '" + cid + "', '" + location + "', '" + city + "');";

                 return dbMan.ExecuteNonQuery(query);
             }
            return 0;

        }
        public DataTable SelectAllBranches()
        {

            string query = "SELECT Distinct branch_name FROM Branch ";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectAllBrancheswithdata()
        {

            string query = "SELECT Distinct Branch.branch_name, Company.company_name, Branch.location, Branch.city FROM Branch, Company WHERE Company.company_id = Branch.company_id ";
            return dbMan.ExecuteReader(query);
        }
        public int UpdateBranch(string old_name, string new_name, string company_name, string location, string city)
        {
                int? cid = getcompanyid(company_name);
                int? bid = getbranchid(old_name, company_name);
            if (cid.HasValue && bid!=0)
            {

                string query = "UPDATE Branch SET  branch_name='" + new_name + "', company_id='" + cid + "' , location='" + location + "', city ='" + city + "'  WHERE branch_id= '" + bid + "';" ;

                return dbMan.ExecuteNonQuery(query);
            }
            return 0;

        }
        public int DeleteBranch(string name,string company_name)
        {
            int? cid = getcompanyid(company_name);
            int? bid = getbranchid(name, company_name);
            if (cid.HasValue && bid!=0)
            {
                string query = "DELETE FROM Branch WHERE branch_name='" + name + "' and company_id='" + cid + "';";
                return dbMan.ExecuteNonQuery(query);
            }
            return 0;
        }
        /////////////////////////////////////////////////////////////////////////////////////////
        public int INSERTCOURT(string court_name, string type,string branch_name,string company_name)
        {
            int? cid = getcompanyid(company_name);
            int? bid = getbranchid(branch_name, company_name);
            if (cid.HasValue && bid != 0)
            {
                string query = "INSERT INTO Court (court_name,type, branch_id) " +
                            "Values ('" + court_name + "', '" + type + "', '" + bid + "');";
                return dbMan.ExecuteNonQuery(query);
            }
            return 0;
        }
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


        //public int InsertManager(string usrname,string pass,string fname,string lname, string address,string pnumber, string comp_name, string branch_name, string bio )
        //{
        //  int cid= getcompanyid(comp_name);
        //    int bid= getbranchid(branch_name,comp_name);

        //    string query = "INSERT INTO Users ( username, password, first_name, last_name, address, phone_number, company_id, type, branch_id, bio) " +
        //                    "Values ('" + usrname + "', '" + pass + "', '" + fname + "', '" + lname +"', '" + address + "', '" + pnumber + "', '" + cid + "','manager', '" + bid + "', '" + bio + "' );";

        //    return dbMan.ExecuteNonQuery(query);

        //}













        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

       
    }
}
