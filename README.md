# Hair Salon

#### An Epicodus Friday independent project in CSharp xUnit testing, 06.02.17

#### **By Anabel Ramirez**

## Description

This web application will allow a salon to book clients with a stylist.

|Behavior| Input (User Action/Selection)| Input2  (User Action/Selection)|Description|
|---|:---:|:---:|:---:|
|Link a stylist to a client. |stylist: AmyRose|client: Amber|A one to one database relationship. |
|Link a stylist to several clients. |stylist: AmyRose|clients: Amber, Anthony|A one to many database relationship. |
|Add a client. |Add client: Amber|Add client: Amber to stylist AmyRose |An add function. |
|Add a stylist. |Add stylist: AmyRose|Add stylist: AmyRose to salon|An add function. |
|Delete a client. |Delete client: Amber|remove client: Amber from stylist AmyRose|A delete function. |
|Delete a stylist. |Delete stylist: AmyRose|remove stylist: AmyRose from salon database|A delete function. |
|Update a client's name. |Find client: Amber|update client to: Anne|An update function. |
|Find a client. |Find client: Amber|find client: Amber in database|A find function. |
|Find a stylist. |Find stylist: AmyRose|find stylist: AmyRose in database|A find function. |
|Link a stylist to a specialty. |stylist: AmyRose|specialty: color|A one to one database relationship. |
|Book a client with a stylist at a salon. |client: Amber|stylist: AmyRose|A many to many database relationship.|

## Setup/Installation Requirements

Must have current version of .Net and Mono installed. Will require database file to work correctly, see download instructions below.

Copy all files and folders to your desktop or {git clone} the project using this link https://github.com/AnabelGR/HairSalon-CS.git.

To recreate the databases using SQLCMD in powershell on a windows operating system type:
* > CREATE DATABASE salon; > GO > USE salon; > GO > CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT); > CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255), location VARCHAR(255), speciality_id INT); > CREATE TABLE specialties (id INT IDENTITY(1,1), name VARCHAR(255)); > CREATE TABLE appointments (id INT IDENTITY(1,1), client_id INT, stylist_id INT); > GO.

Navigate to the folder in your Windows powershell and run {dnu restore} to compile the file then run {dnx kestrel} to start the web server. In your web browser address bar, navigate to {//localhost:5004} to get to the home page.
```
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
