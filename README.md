# Kasa

## Shop and cart with dynamically created buttons.

Go to:
* [Setup](#setup---how-to-tweak-this-project)
* [Products](#products)
* [Cart](#cart)

### Capabilities
This program can: 
* read data from JSON file, 
* visualize shop panel, 
* increment, decrement or remove items from cart,  
* send information with ids and quantities of ordered items

Technologies used: Visual Studio, .NET, Windows Forms, LINQ, Newtonsoft.Json. 
<p align="center">
  <img src=https://user-images.githubusercontent.com/62205129/234090966-40b8fbae-26cf-41dc-bcc7-7154e7653756.png>
</p>

---

## Products

Products are read from the JSON file. After reading the data, it is validated and the correctness of the database is checked (if ids are unique, name exists and price is more than 0). Then a button is created for each product with its name and price on it.

## Cart

The cart is controlled by four buttons:
- increase 
- decrease 
- delete
- confirm

Increase button allows to add one of selected item in cart.
Decrease button allows to remove one of selected item in cart. If there is only one item left, user will be asked if item should be removed from cart.
Delete button removes item from cart regardless of how many pieces there were.
Confirm button asks for confirmation and information about all items from cart is sent to console. User is informed about value of the entire cart.

---

## Setup - how to tweak this project

In order for the project to work properly, you need to change a few things:

### Set CashUI as Startup Project 
As default Visual Studio sets first project as Startup one so this must be changed in order to work properly.
<p align="center">
  <img src=https://user-images.githubusercontent.com/62205129/234096849-85fec5ff-ceed-4c79-a87f-2306ed4dc83e.png>
</p>

### Changing file path for database file

Change key value in ```<appSettings>``` for  ```DataFileFullPath```:
Easly it can be created by Solution Explorer in Visual Studio

<p align="center">
  <img src=https://user-images.githubusercontent.com/62205129/234099726-ab11a4c7-4b82-431c-bf5a-3a4fd9717827.png>
</p>

Then it should be pasted in <strong>CashUI</strong> project in file: ```App.config```:

```
	<appSettings>
		<add key="DataFileFullPath" value="C:\Full\Path\To\File.json"/>
	</appSettings>
```

And you should be good to go! <br>
If you find any problem, please let me know.
