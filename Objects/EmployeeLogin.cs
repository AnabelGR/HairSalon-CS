using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using HairSalon;

namespace HairSalon.Objects
{
  public class Employee
  {
    private static string _employeeName = "admin";
    private static string _employeePassword = "pa55w0rd";
    private string _userNameEntry;
    private string _userPasswordEntry;
    private static bool _status;

    public Employee(string userNameEntry, string userPasswordEntry)
    {
      _userNameEntry = userNameEntry;
      _userPasswordEntry = userPasswordEntry;
    }
    public static bool GetStatus()
    {
      return _status;
    }
    public static void SetStatus(bool update)
    {
      _status = update;
    }
    public string GetNameEntry()
    {
      return _userNameEntry;
    }
    public string GetPasswordEntry()
    {
      return _userPasswordEntry;
    }
    public bool CheckPassword()
    {
      if ((_userPasswordEntry == _employeePassword) && (_userNameEntry == _employeeName))
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}
