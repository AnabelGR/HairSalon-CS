using Xunit;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HairSalon.Objects;

namespace HairSalon
{
  [Collection("HairSalon")]

  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void TestStylists_DatabaseEmptyAtFirst()
    {
      //Arrange
      List<Stylist> allStylists = new List<Stylist>{};

      //Act
      List<Stylist> testList = Stylist.GetAll();

      //Assert
      Assert.Equal(allStylists, testList);
    }
    public void Dispose()
    {
      Stylist.DeleteAll();
    }

    [Fact]
    public void TestStylists_Equal_ReturnEqualValues()
    {
      //Arrange
      Stylist newStylist = new Stylist("AmyRose", "Pearl", 3, 2);
      Stylist testStylist = new Stylist("AmyRose", "Pearl", 3, 2);

      //Act, Assert
      Assert.Equal(newStylist, testStylist);
    }

    [Fact]
    public void TestStylists_Save_SavesStylistToDatabase()
    {
      //arrange
      Stylist newStylist = new Stylist("AmyRose", "Pearl", 3, 2);
      newStylist.Save();

      //Act
      Stylist savedStylist = Stylist.GetAll()[0];

      //assert
      Assert.Equal(newStylist, savedStylist);
    }

    [Fact]
    public void TestStylists_Find_FindsStylistInDatabase()
    {
      //arrange
      Stylist newStylist = new Stylist("AmyRose", "Pearl", 3, 2);
      newStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(newStylist.GetId());

      //assert
      Assert.Equal(newStylist, foundStylist);
    }
    [Fact]
    public void TestStylist_SearchByName_ReturnsMatches()
    {
      Stylist Stylist1 = new Stylist("Ann", "Pearl", 3, 2);
      Stylist1.Save();
      Stylist Stylist2 = new Stylist("Anna", "Pearl", 3, 2);
      Stylist2.Save();
      Stylist Stylist3 = new Stylist("ann", "Pearl", 3, 2);
      Stylist3.Save();

      List<Stylist> testList = new List<Stylist>{Stylist1, Stylist3};
      List<Stylist> testmatches = Stylist.SearchByName("Ann");

      Assert.Equal(testList, testmatches);
    }
    [Fact]
    public void TestStylistDelete_DeletesSingleStylist()
    {
      Stylist newStylist1 = new Stylist("AmyRose", "Pearl", 3, 2);
      newStylist1.Save();
      Stylist newStylist2 = new Stylist("Anna", "Pearl", 3, 2);
      newStylist2.Save();

      newStylist1.DeleteSingleStylist();

      List<Stylist> sampleList = new List<Stylist>{newStylist2};
      List<Stylist> testList = Stylist.GetAll();

      Assert.Equal(sampleList, testList);
    }
    [Fact]
    public void TestStylists_Update_UpdatesStylistName()
    {
      Stylist testStylist = new Stylist("Levi", "Pearl", 3, 2);
      testStylist.Save();

      testStylist.Update("AmyRose", "Pearl", 3);

      Assert.Equal("AmyRose", testStylist.GetName());
    }
  }
}
