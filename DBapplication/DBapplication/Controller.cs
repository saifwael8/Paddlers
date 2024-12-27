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

        public int getCompanyIdBranchId(int branch_id)
        {
            string query = "SELECT company_id FROM Branch WHERE branch_id=" + branch_id + ";";
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
        public DataTable SelectAllCourts(int branch_id)
        {

            string query = "SELECT * FROM Court WHERE branch_id=" + branch_id + ";";
            return dbMan.ExecuteReader(query);
        }


        public int UpdateCourt(int court_id, string name, string type)
        {
            string query = "UPDATE Court SET court_name='" + name + "', type='" + type + "' WHERE court_id=" + court_id + ";";
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

        public int insertUser(string username, string password, string firstName, string lastName, string Address, string PhoneNumber, string type)
        {
            string query = "INSERT INTO Users (username, password, first_name, last_name, address, phone_number, type, bio) " +
                           "VALUES ('" + username + "', '" + password + "', '" + firstName + "', '" + lastName + "', '" + Address + "', '" + PhoneNumber + "','" + type + "','Hi');";
            return dbMan.ExecuteNonQuery(query);
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

        public int getBranchIdUsername(string username)
        {
            string query = "select branch_id from users where username = '" + username + "'; ";
            return (int) dbMan.ExecuteScalar(query);
        }

        public int InsertCourt(string court_name, string court_type, int branch_id)
        {
            string query = "INSERT INTO Court (court_name, type, branch_id) " +
                        "Values ('" + court_name + "', '" + court_type + "', '" + branch_id + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int getCourtId(string court_name, int branch_id)
        {
            string query = "SELECT court_id FROM Court WHERE court_name='" + court_name + "' and branch_id=" + branch_id + ";";
            if (dbMan.ExecuteScalar(query) == null)
                return 0;
            return (int)dbMan.ExecuteScalar(query);
        }

        public DataTable SelectAllEmployees(int branch_id)
        {
            string query = "SELECT * FROM Users WHERE branch_id=" + branch_id + " and type = 'Employee';";
            return dbMan.ExecuteReader(query);
        }



        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

        public int insertEmployee(string username, string password, string firstName, string lastName, string Address, string PhoneNumber, int company_id, string type, int branch_id)
        {
            string query = "INSERT INTO Users (username, password, first_name, last_name, address, phone_number, company_id, type, branch_id, bio) " +
                           "VALUES ('" + username + "', '" + password + "', '" + firstName + "', '" + lastName + "', '" + Address + "', '" + PhoneNumber + "', '" + company_id + "','" + type + "', '" + branch_id + "', 'Hi');";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable SelectAllServices(int company_id)
        {
            string query = "SELECT * FROM services WHERE company_id=" + company_id + ";";
            return dbMan.ExecuteReader(query);
        }

        public int insertService(string service_Name, int price, int company_id)
        {
            string query = "INSERT INTO services (service_name, price, company_id) " +
                           "VALUES ('" + service_Name + "', '" + price + "', '" + company_id + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int deleteService(string service_name, int company_id)
        {
            string query = "DELETE FROM services WHERE service_name='" + service_name + "' and company_id=" + company_id + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int updateService(string service_Name, int price, int company_id)
        {
            string query = "UPDATE services SET price='" + price + "' WHERE service_name='" + service_Name + "' and company_id=" + company_id + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertSlot(DateTime s, int court_id)
        {
            string formattedDate = s.ToString("yyyy-MM-dd HH:mm");
            string query = $"INSERT INTO Slots (time, court_id) VALUES ('{formattedDate}', {court_id});";
            return dbMan.ExecuteNonQuery(query);
        }

        public int deleteSlots()
        {
            string query = "DELETE FROM Slots WHERE time < GETDATE() AND status = 0;";
            return dbMan.ExecuteNonQuery(query);
        }

        public int insertCompetition(string name, int maxNumberofParticipants, int branch_id, int prize, int current_no_particpants = 0)
        {
            string query = "INSERT INTO Competition (competition_name, max_no_particpants, branch_id, prize, current_no_particpants) " +
                           "VALUES ('" + name + "', '" + maxNumberofParticipants + "', '" + branch_id + "', '" + prize + "', '" + current_no_particpants + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int getCompetitionId(string name, int branch_id)
        {
            string query = "SELECT competition_id FROM competition WHERE competition_name='" + name + "' and branch_id=" + branch_id + ";";
            return (int)dbMan.ExecuteScalar(query);
        }

        public int getSlotId(string time, int court_id)
        {
            DateTime parsedTime;
            if (!DateTime.TryParse(time, out parsedTime))
            {
                throw new ArgumentException("Invalid time format");
            }

            string formattedTime = parsedTime.ToString("yyyy-MM-dd HH:mm");
            string query = $"SELECT slot_id FROM slots WHERE time='{formattedTime}' and court_id={court_id};";
            object result = dbMan.ExecuteScalar(query);
            if (result == null)
                return 0;
            return (int)result;
        }

        public int addCompetitionSlots(int competition_id, int slots_id)
        {
            string query = "INSERT INTO competition_slots (competition_id, slot_id) " +
                           "VALUES ('" + competition_id + "', '" + slots_id + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getCompetitions(int branch_id)
        {
            string query = "SELECT * FROM competition WHERE branch_id=" + branch_id + ";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getSlots(int court_id)
        {
            string query = "SELECT * FROM slots WHERE court_id=" + court_id + " and status = 0;";
            return dbMan.ExecuteReader(query);
        }

        public int updateCompetition(int competition_id, int slots_id)
        {
            string query = "insert into competition_slots values (" + competition_id + ", " + slots_id + "); ";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getBranchCity(string city)
        {
            string query = "SELECT * FROM Branch WHERE city='" + city + "';";
            return dbMan.ExecuteReader(query);
        }

        public int getBranchIdName(string branch_name)
        {
            string query = "SELECT branch_id FROM Branch WHERE branch_name='" + branch_name + "';";
            return (int)dbMan.ExecuteScalar(query);
        }

        //TODO: unique(service_name, company_id)
        public int getPrice(int company_id, string service_name)
        {
            string query = "SELECT price FROM services WHERE company_id=" + company_id + " and service_name='" + service_name + "';";
            if (dbMan.ExecuteScalar(query) == null)
                return 0;
            return (int)dbMan.ExecuteScalar(query);
        }


        public int getService(int company_id, string service_name)
        {
            string query = "SELECT service_id FROM services WHERE company_id=" + company_id + " and service_name='" + service_name + "';";
            return (int)dbMan.ExecuteScalar(query);
        }

        internal int insertReservation(string username, int service_id, int branch_id, int slot_id)
        {
            string query = "INSERT INTO reservation (client_username, service_id, branch_id, slot_id) " +
                           "VALUES ('" + username + "', '" + service_id + "', '" + branch_id + "', '" + slot_id + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int setSlot(int slot_id)
        {
            string query = "UPDATE slots SET status = 1 WHERE slot_id = " + slot_id + ";";
            return dbMan.ExecuteNonQuery(query);
        }
    }
}
