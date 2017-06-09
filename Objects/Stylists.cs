using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HairSalon;

namespace HairSalon.Objects
{
  public class Stylist
  {
    private int _id;
    private string _name;
    private string _location;
    private int _specialty_id;

    public Stylist(string name, string location, int specialtyId, int id = 0)
    {
      _id = id;
      _name = name;
      _location = location;
      _specialty_id = specialtyId;
    }

    public int GetId()
    {
      return _id;
    }
    public void SetId(int id)
    {
      _id = id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string name)
    {
      _name = name;
    }
    public string GetLocation()
    {
      return _location;
    }
    public void SetLocation(string location)
    {
      _location = location;
    }
    public int GetSpecialtyId()
    {
      return _specialty_id;
    }
    public void SetSpecialtyId(int specialtyId)
    {
      _specialty_id = specialtyId;
    }
    public List<Client> GetClients()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE stylist_id = @StylistId;", conn);
      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName = "@StylistId";
      stylistIdParameter.Value = this.GetId();
      cmd.Parameters.Add(stylistIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      List<Client> allClients = new List<Client>{};
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        Client newClient = new Client(name, stylistId);
        allClients.Add(newClient);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return allClients;
    }
    
    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = this.GetId() == newStylist.GetId();
        bool nameEquality = this.GetName() == newStylist.GetName();
        bool locationEquality = this.GetLocation() == newStylist.GetLocation();
        bool specialtyIdEquality = this.GetSpecialtyId() == newStylist.GetSpecialtyId();
        return (idEquality && nameEquality && locationEquality && specialtyIdEquality);
      }
    }
    public static List<Stylist> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      List<Stylist> allStylists = new List<Stylist>{};
      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string location = rdr.GetString(2);
        int specialtyId = rdr.GetInt32(3);
        Stylist newStylist = new Stylist(name, location, specialtyId, id);
        allStylists.Add(newStylist);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allStylists;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", conn);
      cmd.ExecuteNonQuery();
      if(conn != null)
      {
        conn.Close();
      }
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("INSERT INTO stylists (name, location, specialty_id) OUTPUT INSERTED.id VALUES (@StylistName, @StylistLocation, @StylistSpecialtyId);", conn);
      SqlParameter nameParameter = new SqlParameter("@StylistName", this.GetName());
      SqlParameter locationParameter = new SqlParameter("@StylistLocation", this.GetLocation());
      SqlParameter specialtyIdParameter = new SqlParameter("@StylistSpecialtyId", this.GetSpecialtyId());
      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(locationParameter);
      cmd.Parameters.Add(specialtyIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public static Stylist Find(int idToFind)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id = @StylistId;", conn);
      SqlParameter idParameter = new SqlParameter("@StylistId", idToFind);
      cmd.Parameters.Add(idParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int id =  0;
      string name = null;
      string location = null;
      int specialtyId = 0;

      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
        location = rdr.GetString(2);
        specialtyId = rdr.GetInt32(3);
      }
      Stylist foundStylist = new Stylist(name, location, specialtyId, id);

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return foundStylist;
    }

    public static List<Stylist> SearchByName(string nameToSearch)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE name = @SearchName;", conn);
      SqlParameter searchParameter = new SqlParameter("@SearchName", nameToSearch);
      cmd.Parameters.Add(searchParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      List<Stylist> matches = new List<Stylist>{};
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string location = rdr.GetString(2);
        int specialtyId = rdr.GetInt32(3);
        Stylist newStylist = new Stylist(name, location, specialtyId, id);
        matches.Add(newStylist);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return matches;
    }

    public void DeleteSingleStylist()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM stylists WHERE id = @StylistId;", conn);
      SqlParameter idParameter = new SqlParameter("@StylistId", this.GetId());
      cmd.Parameters.Add(idParameter);
      cmd.ExecuteNonQuery();
      if(conn != null)
      {
        conn.Close();
      }
    }

    public void Update(string name, string location, int specialtyId)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE stylists SET name = @StylistName, location = @StylistLocation, specialty_id = @SpecialtyId OUTPUT INSERTED.name, INSERTED.location, INSERTED.specialty_id WHERE id = @StylistId;", conn);

      SqlParameter nameParameter = new SqlParameter("@StylistName", name);
      SqlParameter locationParameter = new SqlParameter("@StylistLocation", location);
      SqlParameter specialtyIdParameter = new SqlParameter("@SpecialtyId", specialtyId);
      SqlParameter idParameter = new SqlParameter("@StylistId", this.GetId());

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(locationParameter);
      cmd.Parameters.Add(specialtyIdParameter);
      cmd.Parameters.Add(idParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._name = rdr.GetString(0);
        this._location = rdr.GetString(1);
        this._specialty_id = rdr.GetInt32(2);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }
  }
}
