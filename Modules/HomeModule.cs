using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using HairSalon.Objects;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Get["/clients"] = _ => {
        List<Client> AllClients = Client.GetAll();
        return View["clients.cshtml", AllClients];
      };
      Get["/stylists"] = _ => {
        List<Stylist> AllStylists = Stylist.GetAll();
        return View["stylists.cshtml", AllStylists];
      };
      Get["/stylists/new"] = _ => {
        return View["stylists_form.cshtml"];
      };
      Get["/clients/new"] = _ => {
        List<Stylist> AllStylists = Stylist.GetAll();
        return View["clients_form.cshtml", AllStylists];
      };
      Post["/stylists/new"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["name"], Request.Form["location"]);
        newStylist.Save();
        return View["index.cshtml"];
      };
      Post["/clients/new"] = _ => {
        Client newClient = new Client(Request.Form["name"], Request.Form["stylist-id"]);
        newClient.Save();
        return View["index.cshtml"];
      };
      Get["/stylists/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedStylist = Stylist.Find(parameters.id);
        var stylistClients = selectedStylist.GetClients();
        model.Add("stylist", selectedStylist);
        model.Add("clients", stylistClients);
        return View["stylist.cshtml", model];
      };
      Get["/stylists/edit/{id}"] = parameters => {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        return View["stylist_edit.cshtml", selectedStylist];
      };
      Patch["/stylists/edit/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        string newName = Request.Form["name"];
        string newLocation = Request.Form["location"];
        SelectedStylist.Update(newName, newLocation);
        return View["index.cshtml"];
      };
      Get["/stylists/delete/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        return View["stylist_delete.cshtml", SelectedStylist];
      };
      Delete["/stylists/delete/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        SelectedStylist.Delete();
        return View["index.cshtml"];
      };
      Get["/clients/delete/{id}"] = parameters => {
        return View["client_delete.cshtml"];
      };
      Delete["/clients/delete/{id}"] = parameters => {
        Client selectedClient = Client.Find(parameters.id);
        selectedClient.Delete();
        return View["index.cshtml"];
      };
    }
  }
}
