using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using HairSalon.Objects;

namespace HairSalon
{
  [Collection("HairSalon")]
  public class EmployeeTest
  {
    [Fact]
    public void TestCheckPasswordFunction_ReturnFalse()
    {
      Employee newEmployee = new Employee("Jun Fritz", "password");
      Assert.Equal(false, newEmployee.CheckPassword());
    }
    [Fact]
    public void TestCheckPasswordFunction_ReturnTrue()
    {
      Employee newEmployee = new Employee("admin", "pa55w0rd");
      Assert.Equal(true, newEmployee.CheckPassword());
    }
  }
}
