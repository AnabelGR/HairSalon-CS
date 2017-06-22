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
      Post["/clients/delete"] = _ => {
        Client.DeleteAll();
        return View["removed.cshtml"];
      };
      Get["/stylists/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedStylist = Stylist.Find(parameters.id);
        var stylistClients = selectedStylist.GetClients();
        model.Add("stylist", selectedStylist);
        model.Add("clients", stylistClients);
        return View["stylist.cshtml", model];
      };
      Get["stylists/{id}/edit"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedStylist = Stylist.Find(parameters.id);
        model.Add("stylist", selectedStylist);
        return View["stylist_edit.cshtml", model];
      };
      Patch["stylists/{id}/edit"] = parameters => {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        string newName = Request.Form["name"];
        string newLocation = Request.Form["location"];
        return View["index.cshtml"];
      };
      Get["clients/{id}/edit"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedClient = Client.Find(parameters.id);
        model.Add("client", selectedClient);
        return View["client_edit.cshtml", model];
      };
      Patch["clients/{id}/edit"] = parameters => {
        Client selectedClient = Client.Find(parameters.id);
        string newName = Request.Form["name"];
        int newStlyistId = Request.Form["stylist-id"];
        return View["index.cshtml"];
      };
      Get["stylists/{id}/delete"] = parameters => {
        return View["stylist_delete.cshtml"];
      };
      Delete["stylists/{id}/delete"] = parameters => {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        selectedStylist.Delete();
        return View["index.cshtml"];
      };
      Get["clients/{id}/delete"] = parameters => {
        return View["client_delete.cshtml"];
      };
      Delete["clients/{id}/delete"] = parameters => {
        Client selectedClient = Client.Find(parameters.id);
        selectedClient.Delete();
        return View["index.cshtml"];
      };
    }
  }
}
