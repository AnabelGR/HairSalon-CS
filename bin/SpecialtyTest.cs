using Xunit;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HairSalon.Objects;

namespace HairSalon
{
  [Collection("HairSalon")]

  public class SpecialtyTest : IDisposable
  {
    public SpecialtyTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void TestSpecialty_DatabaseEmptyAtFirst()
    {
      //Arrange
      List<Specialty> allSpecialtys = new List<Specialty>{};

      //Act
      List<Specialty> testList = Specialty.GetAll();

      //Assert
      Assert.Equal(allSpecialtys, testList);
    }

    [Fact]
    public void TestSpecialty_Equal_ReturnEqualValues()
    {
      //Arrange
      Specialty newSpecialty = new Specialty("color");
      Specialty testSpecialty = new Specialty("color");

      //Act, Assert
      Assert.Equal(newSpecialty, testSpecialty);
    }

    [Fact]
    public void TestSpecialty_Save_SavesSpecialtyToDatabase()
    {
      //arrange
      Specialty newSpecialty = new Specialty("color");
      newSpecialty.Save();

      //Act
      Specialty savedSpecialty = Specialty.GetAll()[0];

      //assert
      Assert.Equal(newSpecialty, savedSpecialty);
    }

    [Fact]
    public void TestSpecialty_Find_FindsSpecialtyInDatabase()
    {
      //arrange
      Specialty newSpecialty = new Specialty("color");
      newSpecialty.Save();

      //Act
      Specialty foundSpecialty = Specialty.Find(newSpecialty.GetId());

      //assert
      Assert.Equal(newSpecialty, foundSpecialty);
    }
    [Fact]
    public void TestSpecialty_SearchByName_ReturnsMatches()
    {
      Specialty specialty1 = new Specialty("color");
      specialty1.Save();
      Specialty specialty2 = new Specialty("mens cut");
      specialty2.Save();
      Specialty specialty3 = new Specialty("color");
      specialty3.Save();

      List<Specialty> testList = new List<Specialty>{specialty1, specialty3};
      List<Specialty> testmatches = Specialty.SearchByName("color");

      Assert.Equal(testList, testmatches);
    }
    [Fact]
    public void TestSpecialtyDelete_Delete()
    {
      Specialty newSpecialty1 = new Specialty("color");
      newSpecialty1.Save();
      Specialty newSpecialty2 = new Specialty("Anna");
      newSpecialty2.Save();

      newSpecialty1.Delete();

      List<Specialty> sampleList = new List<Specialty>{newSpecialty2};
      List<Specialty> testList = Specialty.GetAll();

      Assert.Equal(sampleList, testList);
    }
    [Fact]
    public void TestSpecialty_Update_Update()
    {
      Specialty testSpecialty = new Specialty("Anthony");
      testSpecialty.Save();

      testSpecialty.Update("color");

      Assert.Equal("color", testSpecialty.GetName());
    }
    public void Dispose()
    {
      Client.DeleteAll();
      Stylist.DeleteAll();
      Specialty.DeleteAll();
    }
  }
}
