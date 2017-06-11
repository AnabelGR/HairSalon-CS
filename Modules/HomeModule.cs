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
        // Dictionary<string, object> model = new Dictionary<string, object>();
        // model.Add("stylist", allStylists);
        return View["index.cshtml", allStylists];
      };
      // Get["/client/{id}"] = parameters => {
      //   Dictionary<string, object> model = new Dictionary<string, object>();
      //   var SelectedClient = Client.Find(parameters.id);
      //   var SelectedStylist = Stylist.Find(SelectedClient.GetStylistId());
      //   model.Add("currentStylist", SelectedStylist);
      //   model.Add("currentClient", SelectedClient);
      //   return View["stylist.cshtml", model];
      // };
      // Post["/client/{id}"] = parameters => {
      //   Dictionary<string, object> model = new Dictionary<string, object>();
      //   var SelectedClient = Client.Find(parameters.id);
      //   var SelectedStylist = Stylist.Find(SelectedClient.GetStylistId());
      //   model.Add("currentStylist", SelectedStylist);
      //   model.Add("currentClient", SelectedClient);
      //   return View["stylist.cshtml", model];
      // };
      // Post["/"] = _ => {
      //   Dictionary<string, object> model = new Dictionary<string, object>();
      //   var allStylists = Stylist.GetAll();
      //   var allClients = Client.GetAll();
      //   Client newClient = new Client(Request.Form["name"], Request.Form["stylist_id"]);
      //   allClients.Add(newClient);
      //   newClient.Save();
      //   model.Add("stylists", allStylists);
      //   model.Add("clients", allClients);
      //   return View["index.cshtml", model];
      // };
      // Get["client/new"] = _ => {
      //   return View["client-form.cshtml"];
      // };
      // Post["client/new"] = _ => {
      //   Employee newEmployee = new Employee(Request.Form["user-name"], Request.Form["user-password"]);
      //   bool isEmployee = newEmployee.CheckPassword();
      //   if (isEmployee)
      //   {
      //     Employee.SetStatus(true);
      //   }
      //   return View["client-form.cshtml", newEmployee];
      // };
    }
  }
}
