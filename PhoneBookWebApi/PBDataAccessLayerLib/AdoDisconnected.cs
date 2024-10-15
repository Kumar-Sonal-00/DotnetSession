using PBEntitiesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace PBDataAccessLayerLib
{
    public class AdoDisconnected : IContactDataAccess
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;

        public AdoDisconnected()
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PhoneBookDB;Integrated Security=True;Encrypt=False;");
            da = new SqlDataAdapter("select * from tbl_contact", con);
            ds = new DataSet();
            da.Fill(ds,"tbl_contact");
            //add primary key to the dataset table
            ds.Tables[0].Constraints.Add("pk1", ds.Tables[0].Columns["id"], true);
        }
        public void AddContact(Contact contact)
        {
            //create new row as per DataSet Table
            DataRow row =ds.Tables[0].NewRow();
            //specify the values in the columns of new row
            row["firstname"] = contact.firstname;
            row["lastname"] = contact.lastname;
            row["gender"] = contact.gender;
            row["dob"] = contact.dob;
            row["email"] = contact.email;
            row["phone"] = contact.phone;
            row["city"] = contact.city;
            row["state"] = contact.state;
            row["country"] = contact.country;
            row["picture"] = contact.picture;
            //add this row to table rows
            ds.Tables[0].Rows.Add(row);
            //save changes to database using DataAdapter
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(ds, "tbl_contact");
        }

        public void DeleteContact(int id)
        {
            //find the record in DataSet rows
            DataRow row = ds.Tables[0].Rows.Find(id);
            if (row != null)
            {
                row.Delete();
                //save changes
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "tbl_contact");
            }
        }

        public List<Contact> GetAllContacts()
        {
            List<Contact> list = new List<Contact>();
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                var contact = new Contact
                {
                    id = (int)row["id"],
                    firstname = row["firstname"].ToString(),
                    lastname = row["lastname"].ToString(),
                    gender = row["gender"].ToString(),
                    dob = row["dob"].ToString(),
                    email = row["email"].ToString(),
                    phone = row["phone"].ToString(),
                    city = row["city"].ToString(),
                    state = row["state"].ToString(),
                    country = row["country"].ToString(),
                    picture = row["picture"].ToString()
                };
                list.Add(contact);
            }
            return list;
        }

        public Contact GetContact(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateContact(Contact contact)
        {
            //find the record for update in dataset table rows
            DataRow row = ds.Tables[0].Rows.Find(contact.id);
            if (row != null)
            {
                //update the values;
                row["lastname"] = contact.lastname;
                //save changes to database
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "tbl_contact");
            }
        }
    }
}
