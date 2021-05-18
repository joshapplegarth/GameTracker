# Game Tracker
### An 18-Week Project. An ASP.NET MVC Core Web Application for MSSA.

---

Joshua Applegarth <br />
MSSA CAD <br />
May 17, 2021

---

## Game Tracker

#### Background Information
With the influx of new and old hunters moving into the area, it can sometimes be overwhelming trying to manage where everyone is at one time.  Sometimes adverse weather rolls in, or the area quota has been filled, and you must alert and ensure the safety of hunters in a specific hunting area of the current situation.  This web application is designed to allow administrators to keep a detail record of hunters within a selected area, and to be able to alert them if needed.  It will also allow registered Users (after being verified with a valid hunting license in person) to view, check-in, and access available hunting areas within the designated hunting zone with ease.

#### Description
The web application helps assist hunters to keep tracker and log what game, by location, they take.  It helps assist in keep records and tracking and regulating game populations in specific areas.

Upon registering and gaining access, this web application will allow Users to log in and check into the different hunting/Training Areas on Fort Hood.  It will offer checking in for different reasons based on state hunting seasons as follows:

+ **Deer**
+ **Wild Pig**
+	**Small Game**
+	**Fishing**
+	**Maintenance/ Area Access**

It will also tell how many slots are available by type.  Being define with a larger hunting area will be more accommodating to higher caliber weapons, that area would also be allowed more hunters within that area.  In comparison, the smaller areas, may be limited in the caliber that may be used as hunters will be closer to one another and less slots for hunters, so accidents are prevented. 

When hunting public property, hunters always run into two issues; other hunters nearby in an area, and walking in, or having other hunters walk into their setups.  This web application, upon successfully creating a reservation for a hunting area, will give Users a list of who also is checked in to the area along with a contact number or email, based of which the registered hunter prefers.  This will help eliminate the setting up of stands or blinds, and feeders on top of each other without knowing.  It will also allow for hunting deconfliction to be done so hunters are not walking in on each other and ruining hunts.  

#### Reservations

Reservations can be made every day, for the for the following day, at midnight.  You are only allowed to be checked into one hunting area at a time.  For example, you can check-in hunting area 5 for a certain day, then at midnight you are able to check in for the next day either into that same area if there are still slots remaining, or another hunting area of choosing.  Being able to only be checked into one hunting area at a time, and not being able to check-in and make a reservation for the next day, will help eliminate hunters continuously checking in just to keep other hunters out.  

As for reservations as well, certain areas may have hit the local quota and therefor may not be able to be hunted anymore.  When an instance like this occurs, the local availability when a hunter selects which type of game and the date they would like to hunt, a green or red dot located on the hunting area will appear.  This will indicate whether that certain area is open or available to be hunted, or “shot out” and unavailable.

#### Account Information

Administrative profiles of this application will have rights to create, edit, remove new or existing Users.  Upon verification of the proper credentials to be able to hunt, admins will then create a profile for the user to be able to access the HAC-IN features.  Admins will be able to view a record of all hunters entered within the system.  They will also be able to see which area hunter’s check-in to, on a selected day.  Along with being able to manage all registered hunters, Admins will also be able to set a given quota per area, as well as the number of hunters allowed with in that area.  

Users will have to register with a name, valid phone number, and valid email.  Once registered they will be allowed to create a password in turn creating them a profile for HAC-IN.   With this, the Users will be allowed to select a date, access type, and area in which they would like to access.  Based upon the available slots for that specified area, they will be able to check-in/check-out of areas with email confirmation of that specific transaction.




[Database Diagram](HAC_IN.pdf) <br />
[Go to Huntrac](https://webtrac.mwr.army.mil/webtrac103/wbwsc/hoodrectrac.wsc/wbsplash.html?wbsi=ac1c9c79-5413-1a91-2b14-f87330233dd3&wbp=3)
