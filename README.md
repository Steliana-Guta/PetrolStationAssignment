# PetrolStationAssignment
The app refers to a forecourt with 9 fuel pumps arranged over 3 lanes (three pumps
in each lane). For the purpose of demonstrating the app to the customer, each n
number of seconds (where n is random) a vehicle is created and awaits to be
fuelled. The fuelling takes place automatically i.e. vehicles waiting in the queue
should be periodically assigned to an available pump. To add to realism of the
demonstration and to account for drivers’ agitation there is a finite period of time
to fuel a waiting vehicle before it leaves the forecourt. That period is set to Z
number of seconds (where Z is random). Should the vehicle not be fuelled during 
that period of time, it will leave the forecourt. Similarly, a vehicle that was fuelled
also leaves the forecourt, only this time the amount of fuel dispensed is recorded. A
pump cannot service more than one vehicle at a time and the following counters
have to be kept: (1) running total of the number of litres dispensed during the app’s
lifetime; (2) The amount of money these litres equate to; (3) The 1% commission;
(4) the number of vehicles serviced, (5) the number of vehicles that left before they
were fuelled and (6) keep a detailed list of each fuelling transaction – [Vehicle type,
Number of litres and Pump number].

A new vehicle is created randomly every 1500 to 2200 milliseconds. And the
queue of vehicles waiting to be serviced can reach 5. At this level, the time
frame to service a vehicle is random between 1000 and 2000 milliseconds.

Newly created vehicles can only be fuelled within 1500 milliseconds of their
creation. Failure to service them within this time frame will remove the
vehicle from the forecourt.

Newly created vehicles will be created with a random amount of fuel already
in their tank (which cannot be greater than a quarter of their total tank
capacity). Fuelling time will be based on the above amount.

The random amount of fuel in a newly created vehicle will be proportionate
to the vehicle size. Each vehicle type will have the following maximum
amount in their tank: Cars - maximum 40 litres, Vans - maximum 80 litres and
HGV - maximum 150 litres. HGV can only run on Diesel. Vans on both Diesel
and LPG and finally cars on all three types of fuel.

The Pump is capable of dispensing 1.5 litres / second.

A queuing system has to be implemented in the forecourt as each lane has
three pumps. As per figure 1, a vehicle which uses pump 1 blocks the way for
new vehicles to get to pumps 2 or 3. The situation is similar for lanes 2 and 3. 

All pumps contain all types of fuel.

Three counter have to be shown countign the amount of eahc fuel type sold, a total
and the commision/salary earned by the assistant.


