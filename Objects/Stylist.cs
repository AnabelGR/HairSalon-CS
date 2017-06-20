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

    public Stylist(string name, string location, int id = 0)
    {
      _id = id;
      _name = name;
      _location = location;
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
        int ClientId = rdr.GetInt32(0);
        string ClientName = rdr.GetString(1);
        int ClientStylistId = rdr.GetInt32(2);
        Client newClient = new Client(ClientName, ClientStylistId, ClientId);
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
        return (idEquality && nameEquality && locationEquality);
      }
    }
    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string location = rdr.GetString(2);

        Stylist newStylist = new Stylist(name, location, id);
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
      conn.Close();
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO stylists (name, location) OUTPUT INSERTED.id VALUES (@StylistName, @StylistLocation);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName ="@Name";
      nameParameter.Value = this.GetName();

      SqlParameter locationParameter = new SqlParameter();
      locationParameter.ParameterName = "@StylistLocation";
      locationParameter.Value = this.GetLocation();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(locationParameter);

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

    public static Stylist Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id = @StylistId;", conn);
      SqlParameter StylistIdParameter = new SqlParameter();
      StylistIdParameter.ParameterName = "@StylistId";
      StylistIdParameter.Value = id.ToString();
      cmd.Parameters.Add(StylistIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundStylistId =  0;
      string foundStylistName = null;
      string foundStylistLocation = null;

      while(rdr.Read())
      {
        foundStylistId = rdr.GetInt32(0);
        foundStylistName = rdr.GetString(1);
        foundStylistLocation = rdr.GetString(2);
      }
      Stylist foundStylist = new Stylist(foundStylistName, foundStylistLocation, foundStylistId);

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
        Stylist newStylist = new Stylist(name, location, id);
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

    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM stylists WHERE id = @StylistId;DELETE FROM clients WHERE id = @StylistId;", conn);
      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName = "@StylistId";
      stylistIdParameter.Value = this.GetId();

      cmd.Parameters.Add(stylistIdParameter);
      cmd.ExecuteNonQuery();
      if(conn != null)
      {
        conn.Close();
      }
    }

    public void Update(string newName, string newLocation)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE stylists SET name = @StylistName, location = @StylistLocation,  OUTPUT INSERTED.name, INSERTED.location WHERE id = @StylistId;", conn);

      SqlParameter newNameParameter = new SqlParameter();
      newNameParameter.ParameterName = "@NewName";
      newNameParameter.Value = newName;
      cmd.Parameters.Add(newNameParameter);

      SqlParameter newLocationParameter = new SqlParameter();
      newLocationParameter.ParameterName = "@StylistLocation";
      newLocationParameter.Value = newLocation;
      cmd.Parameters.Add(newLocationParameter);

      SqlDataReader rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {
        this._name = rdr.GetString(0);
        this._location = rdr.GetString(1);
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
