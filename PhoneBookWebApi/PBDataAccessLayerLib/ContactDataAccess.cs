using PBEntitiesLib;
using System.Data.SqlClient;
using System.Data;


namespace PBDataAccessLayerLib
{
    public class ContactDataAccess : IContactDataAccess
    {
        SqlConnection con;
        SqlCommand cmd;

        public ContactDataAccess()
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PhoneBookDB;Integrated Security=True;Encrypt=False;");
        }

        public void AddContact(Contact contact)
        {
            //configure command for INSERT
            cmd = new SqlCommand();
            cmd.CommandText = "insert into tbl_contact values(@fn,@ln,@gender,@dob,@email,@phone,@city,@state,@country,@picture)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@fn", contact.firstname);
            cmd.Parameters.AddWithValue("@ln", contact.lastname);
            cmd.Parameters.AddWithValue("@gender", contact.gender);
            cmd.Parameters.AddWithValue("@dob", contact.dob);
            cmd.Parameters.AddWithValue("@email", contact.email);
            cmd.Parameters.AddWithValue("@phone", contact.phone);
            cmd.Parameters.AddWithValue("@city", contact.city);
            cmd.Parameters.AddWithValue("@state", contact.state);
            cmd.Parameters.AddWithValue("@country", contact.country);
            cmd.Parameters.AddWithValue("@picture", contact.picture);

            //attach connection
            cmd.Connection = con;
            //open connection
            con.Open();
            //execute the insert command
            cmd.ExecuteNonQuery();
            //close the con
            con.Close();
        }

        public void DeleteContact(int id)
        {
            cmd = new SqlCommand("delete from tbl_contact where id=@id",con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Contact> GetAllContacts()
        {
            List<Contact> list = new List<Contact>();

            //configure sql command for select all
            cmd = new SqlCommand("select * from tbl_contact",con);
            //open connection
            con.Open();
            //execute the command
            SqlDataReader sdr =cmd.ExecuteReader();
            //traverse the records and add into the collection
            while (sdr.Read()) 
            {
                var contact = new Contact
                {
                    id = sdr.GetInt32("id"),
                    firstname = sdr.GetString("firstname"),
                    lastname = sdr.GetString("lastname"),
                    gender = sdr.GetString("gender"),
                    dob = sdr.GetString("dob"),
                    email = sdr.GetString("email"),
                    phone = sdr.GetString("phone"),
                    city = sdr.GetString("city"),
                    state = sdr.GetString("state"),
                    country = sdr.GetString("country"),
                    picture = sdr.GetString("picture")
                };
                list.Add(contact);
            }
            //close the datareader and connection
            sdr.Close();
            con.Close();

            //return the result
            return list;
        }

        public Contact GetContact(int id)
        {
            var contact = new Contact();

            cmd = new SqlCommand("select * from tbl_contact where id=@id", con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader sdr= cmd.ExecuteReader();
            if(sdr.Read())
            {
                contact = new Contact
                {
                    id = sdr.GetInt32("id"),
                    firstname = sdr.GetString("firstname"),
                    lastname = sdr.GetString("lastname"),
                    gender = sdr.GetString("gender"),
                    dob = sdr.GetString("dob"),
                    email = sdr.GetString("email"),
                    phone = sdr.GetString("phone"),
                    city = sdr.GetString("city"),
                    state = sdr.GetString("state"),
                    country = sdr.GetString("country"),
                    picture = sdr.GetString("picture")
                };
            }
            sdr.Close();
            con.Close();

            return contact;
        }

        public void UpdateContact(Contact contact)
        {
            //configure command for UPDATE
            cmd = new SqlCommand();
            cmd.CommandText = "update tbl_contact set firstname=@fn,lastname=@ln,gender=@gender,dob=@dob,email=@email,phone=@phone,city=@city,state=@state,country=@country,picture=@picture where id=@id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", contact.id);
            cmd.Parameters.AddWithValue("@fn", contact.firstname);
            cmd.Parameters.AddWithValue("@ln", contact.lastname);
            cmd.Parameters.AddWithValue("@gender", contact.gender);
            cmd.Parameters.AddWithValue("@dob", contact.dob);
            cmd.Parameters.AddWithValue("@email", contact.email);
            cmd.Parameters.AddWithValue("@phone", contact.phone);
            cmd.Parameters.AddWithValue("@city", contact.city);
            cmd.Parameters.AddWithValue("@state", contact.state);
            cmd.Parameters.AddWithValue("@country", contact.country);
            cmd.Parameters.AddWithValue("@picture", contact.picture);

            //attach connection
            cmd.Connection = con;
            //open connection
            con.Open();
            //execute the insert command
            cmd.ExecuteNonQuery();
            //close the con
            con.Close();
        }
    }
}
