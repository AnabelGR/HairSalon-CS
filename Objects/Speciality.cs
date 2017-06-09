using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HairSalon;

namespace HairSalon.Objects
{
  public class Specialty
  {
    private int _id;
    private string _name;

    public Specialty(string name, int id = 0)
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

    public override bool Equals(System.Object otherSpecialty)
    {
      if (!(otherSpecialty is Specialty))
      {
        return false;
      }
      else
      {
        Specialty newSpecialty = (Specialty) otherSpecialty;
        bool idEquality = this.GetId() == newSpecialty.GetId();
        bool nameEquality = this.GetName() == newSpecialty.GetName();
        return (idEquality && nameEquality);
      }
    }
    public static List<Specialty> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM specialty;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      List<Specialty> allSpecialtys = new List<Specialty>{};
      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Specialty newSpecialty = new Specialty(name, id);
        allSpecialtys.Add(newSpecialty);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allSpecialtys;
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM specialty;", conn);

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
      SqlCommand cmd = new SqlCommand("INSERT INTO specialty (name) OUTPUT INSERTED.id VALUES (@SpecialtyName);", conn);
      SqlParameter nameParameter = new SqlParameter("@SpecialtyName", this.GetName());
      cmd.Parameters.Add(nameParameter);
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
    public static Specialty Find(int idToFind)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM specialty WHERE id = @SpecialtyId;", conn);
      SqlParameter idParameter = new SqlParameter("@SpecialtyId", idToFind);
      cmd.Parameters.Add(idParameter);
      SqlDataReader rdr = cmd.ExecuteReader();
      int id =  0;
      string name = null;

      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
      }
      Specialty foundSpecialty = new Specialty(name, id);

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return foundSpecialty;
    }
    public static List<Specialty> SearchByName(string nameToSearch)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM specialty WHERE name = @SearchName;", conn);
      SqlParameter searchParameter = new SqlParameter("@SearchName", nameToSearch);
      cmd.Parameters.Add(searchParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      List<Specialty> matches = new List<Specialty>{};
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Specialty newSpecialty = new Specialty(name, id);
        matches.Add(newSpecialty);
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
    public void DeleteSingleSpecialty()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM specialty WHERE id = @SpecialtyId;", conn);
      SqlParameter idParameter = new SqlParameter("@SpecialtyId", this.GetId());
      cmd.Parameters.Add(idParameter);
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
      SqlCommand cmd = new SqlCommand("UPDATE specialty SET name = @SpecialtyName OUTPUT INSERTED.name WHERE id = @SpecialtyId;", conn);
      SqlParameter nameParameter = new SqlParameter("@SpecialtyName", newName);
      SqlParameter idParameter = new SqlParameter("@SpecialtyId", this.GetId());
      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(idParameter);
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
