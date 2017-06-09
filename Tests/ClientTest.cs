using Xunit;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HairSalon.Objects;

namespace HairSalon
{
  [Collection("HairSalon")]

  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void TestClients_DatabaseEmptyAtFirst()
    {
      //Arrange
      List<Client> allClients = new List<Client>{};

      //Act
      List<Client> testList = Client.GetAll();

      //Assert
      Assert.Equal(allClients, testList);
    }
    public void Dispose()
    {
      Client.DeleteAll();
    }

    [Fact]
    public void TestClients_Equal_ReturnEqualValues()
    {
      //Arrange
      Client newClient = new Client("Amber");
      Client testClient = new Client("Amber");

      //Act, Assert
      Assert.Equal(newClient, testClient);
    }
    [Fact]
    public void TestClients_Save_SavesClientToDatabase()
    {
      //arrange
      Client newClient = new Client("Amber");
      newClient.Save();

      //Act
      Client savedClient = Client.GetAll()[0];

      //assert
      Assert.Equal(newClient, savedClient);
    }
    [Fact]
    public void TestClients_Find_FindsClientInDatabase()
    {
      //arrange
      Client newClient = new Client("Amber");
      newClient.Save();

      //Act
      Client foundClient = Client.Find(newClient.GetId());

      //assert
      Assert.Equal(newClient, foundClient);
    }
  }
}
