using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HairSalon;

namespace HairSalon.Objects
{
  public class Client
  {
    private int _id;
    private string _name;

    public Client(string name, int id = 0)
    {
      _name = name;
      _id = id;
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

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;

        bool idEquality = this.GetId() == newClient.GetId();
        bool nameEquality = this.GetName() == newClient.GetName();

        return (idEquality && nameEquality);
      }
    }
    public static List<Client> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      List<Client> allClients = new List<Client>{};
      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);

        Client newClient = new Client(name, id);
        allClients.Add(newClient);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allClients;
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);

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

      SqlCommand cmd = new SqlCommand("INSERT INTO clients (name) OUTPUT INSERTED.id VALUES (@ClientName);", conn);

      SqlParameter nameParam = new SqlParameter("@ClientName", this.GetName());

      cmd.Parameters.Add(nameParam);

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
    public static Client Find(int idToFind)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientId;", conn);
      SqlParameter idParam = new SqlParameter("@ClientId", idToFind);
      cmd.Parameters.Add(idParam);
      SqlDataReader rdr = cmd.ExecuteReader();

      int id =  0;
      string name = null;

      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
      }
      Client foundClient = new Client(name, id);

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return foundClient;
    }
    public static List<Client> SearchByName(string nameToSearch)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE name = @SearchName;", conn);
      SqlParameter searchParam = new SqlParameter("@SearchName", nameToSearch);
      cmd.Parameters.Add(searchParam);
      SqlDataReader rdr = cmd.ExecuteReader();

      List<Client> matches = new List<Client>{};
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Client newClient = new Client(name, id);
        matches.Add(newClient);
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
    public void DeleteSingleClient()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM clients WHERE id = @ClientId;", conn);

      SqlParameter idParam = new SqlParameter("@ClientId", this.GetId());
      cmd.Parameters.Add(idParam);
      cmd.ExecuteNonQuery();
      if(conn != null)
      {
        conn.Close();
      }
    }
    public void Update(string newName)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE clients SET name = @ClientName OUTPUT INSERTED.name WHERE id = @ClientId;", conn);

      SqlParameter nameParam = new SqlParameter("@ClientName", newName);
      SqlParameter idParam = new SqlParameter("@ClientId", this.GetId());
      cmd.Parameters.Add(nameParam);
      cmd.Parameters.Add(idParam);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._name = rdr.GetString(0);
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
