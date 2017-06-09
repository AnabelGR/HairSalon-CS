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
      Stylist newStylist = new Stylist("AmyRose", "Pearl", 3);
      Stylist testStylist = new Stylist("AmyRose", "Pearl", 3);

      //Act, Assert
      Assert.Equal(newStylist, testStylist);
    }

    [Fact]
    public void TestStylists_Save_SavesStylistToDatabase()
    {
      //arrange
      Stylist testStylist = new Stylist("AmyRose", "Pearl", 3, 2);

      //Act
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      //assert
      Assert.Equal(testList, result);
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
          Stylist stylist1 = new Stylist("AmyRose", "Pearl", 3, 2);
          stylist1.Save();
          Stylist stylist2 = new Stylist("Amy", "Pearl", 3, 2);
          stylist2.Save();
          Stylist stylist3 = new Stylist("AmyRose", "Pearl", 3, 2);
          stylist3.Save();

          List<Stylist> testList = new List<Stylist>{stylist1, stylist3};
          List<Stylist> testmatches = Stylist.SearchByName("AmyRose");

          Assert.Equal(testList, testmatches);
        }
        [Fact]
        public void TestStylistDelete_DeletesSingleStylist()
        {
          Stylist newStylist1 = new Stylist("AmyRose", "Pearl", 3, 2);
          newStylist1.Save();
          Stylist newStylist2 = new Stylist("Anthony", "Pearl", 3, 2);
          newStylist2.Save();

          newStylist1.DeleteSingleStylist();

          List<Stylist> sampleList = new List<Stylist>{newStylist2};
          List<Stylist> testList = Stylist.GetAll();

          Assert.Equal(sampleList, testList);
        }
        [Fact]
        public void TestStylists_Update_UpdatesStylistName()
        {
          Stylist testStylist = new Stylist("Anthony", "Pearl", 3, 2);
          testStylist.Save();

          testStylist.Update("AmyRose", "Hawthorne", 2);

          Assert.Equal("AmyRose", testStylist.GetName());
        }
      }
    }
