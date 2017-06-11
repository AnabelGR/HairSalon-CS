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
      Post["/stylists/new"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["name"], Request.Form["location"], Request.Form["specialty-id"]);
        newStylist.Save();
        return View["action_completed.cshtml"];
      };
      Get["/clients/new"] = _ => {
        List<Stylist> AllStylists = Stylist.GetAll();
        return View["clients_form.cshtml", AllStylists];
      };
      Post["/clients/new"] = _ => {
        Client newClient = new Client(Request.Form["name"], Request.Form["stylist-id"]);
        newClient.Save();
        return View["action_completed.cshtml"];
      };
      Post["/clients/delete"] = _ => {
        Client.DeleteAll();
        return View["removed.cshtml"];
      };
      Get["/stylists/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        List<Client> StylistClients = SelectedStylist.GetClients();
        model.Add("stylist", SelectedStylist);
        model.Add("clients", StylistClients);
        return View["stylist.cshtml", model];
      };
      Get["stylist/edit/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        return View["stylist_edit.cshtml", SelectedStylist];
      };
      Patch["stylist/edit/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        SelectedStylist.Update(Request.Form["name"], Request.Form["location"], Request.Form["specialty-id"]);
        return View["action_completed.cshtml"];
      };
      Get["client/edit/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        return View["client_edit.cshtml", SelectedClient];
      };
      Patch["client/edit/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        SelectedClient.Update(Request.Form["name"], Request.Form["stylist-id"]);
        return View["action_completed.cshtml"];
      };
      Get["stylist/delete/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        return View["stylist_delete.cshtml", SelectedStylist];
      };
      Delete["stylist/delete/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        SelectedStylist.Delete();
        return View["action_completed.cshtml"];
      };
      Get["client/delete/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        return View["client_delete.cshtml", SelectedClient];
      };
      Delete["client/delete/{id}"] = parameters => {
        Client SelectedClient = Client.Find(parameters.id);
        SelectedClient.Delete();
        return View["action_completed.cshtml"];
      };
    }
  }
}
