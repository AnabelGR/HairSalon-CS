# Hair Salon

#### An Epicodus Friday independent project in CSharp xUnit testing, 06.02.17

#### **By Anabel Ramirez**

## Description

This web application will allow a salon to book clients with a stylist.

|Behavior| Input (User Action/Selection) |Description|
|---|:---:|:---:|
|Add a client. |Add client: Amber|An add function. |
|Find a client. |Find client: Amber|A find function. |
|Search for a client. |Search client: Amber|A search function. |
|Delete a client. |Delete client: Amber|A delete function. |
|Update a client's name. |Find client: Amber|An update function. |
|Add a stylist. |Add stylist: AmyRose|An add function. |
|Find a stylist. |Find stylist: AmyRose|A find function. |
|Search for a stylist. |Search stylist: AmyRose|A search function. |
|Delete a stylist. |Delete stylist: AmyRose|A delete function. |
|Update a stylist's name. |Find stylist: AmyRose, update to Levi|An update function. |
|View all stylists. |stylists: AmyRose, Levi, Morgan|View the full list of stylists in the database. |
|View a stylist's details, clients. |stylist: AmyRose, location: Pearl, specialty: color |View the full list of stylists in the database. |
|Link a stylist to a client. |stylist: AmyRose, client: Amber|A one to one database relationship. |
|Link a stylist to several clients. |stylist: AmyRose, clients: Amber, Anthony|A one to many database relationship. |
|Link a stylist to a specialty. |stylist: AmyRose, specialty: color|A one to one database relationship. |
|Book a client with a stylist at a salon. |client: Amber, stylist: AmyRose|A many to many database relationship.|

## Setup/Installation Requirements

Must have current version of .Net and Mono installed. Will require database file to work correctly, see download instructions below.

Copy all files and folders to your desktop or {git clone} the project using this link https://github.com/AnabelGR/HairSalon-CS.git.

To recreate the databases using SQLCMD in powershell on a windows operating system type:
* > CREATE DATABASE hair_salon; > GO > USE hair_salon; > GO > CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT); > CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255), location VARCHAR(255), speciality_id INT); > CREATE TABLE specialties (id INT IDENTITY(1,1), name VARCHAR(255)); > CREATE TABLE appointments (id INT IDENTITY(1,1), client_id INT, stylist_id INT); > GO.

Navigate to the folder in your Windows powershell and run {dnu restore} to compile the file then run {dnx kestrel} to start the web server. In your web browser address bar, navigate to {//localhost:5004} to get to the home page.

## Known Bugs

* No known bugs

## Support and contact details

If you have any issues or have questions, ideas, concerns, or contributions please contact the contributor through Github.

## Technologies Used

* C#
* Nancy
* Razor
* xUnit
* JSON
* HTML
* CSS
* Bootstrap

### License
This software is licensed under the MIT license.

Copyright (c) 2017 **Anabel Ramirez**
