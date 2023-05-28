create database cab_booking

use cab_booking

create table driver_details
(
	driver_id int identity primary key,
	name varchar(20),
	age int,
	contact varchar(10),
	gender varchar(10),
	username varchar(20),
	password varchar(20)
)
--drop table driver_details
insert into driver_details
values ('suresh', 37, '9874363473', 'Male', 'suresh','suri@123'),
		('Ravi', 26, '9874363473', 'Male','ravi','suri@123'),
		('Ramesh', 32, '9874363473', 'Male','ramesh','suri@123'),
		('Kishore', 22, '9874363473', 'Male','kishore','suri@123'),
		('Raju', 41, '9874363473', 'Male','raju','suri@123'),
		('Veeru', 26, '9874363473', 'Male','veeru','suri@123'),
		('Suri', 46, '9874363473', 'Male','suri','suri@123'),
		('Kishu', 22, '9874363473', 'Male','kishu','suri@123'),
		('Sai', 36, '9874363473', 'Male','sai','suri@123'),
		('Anil', 28, '9874363473', 'Male','anil','suri@123'),
		('Vinay', 21, '9874363473', 'Male','vinay','suri@123')
select * from driver_details

create table car
(
	car_id int identity primary key,
	model varchar(20),
	size int,
	driver_id int references driver_details(driver_id)
)
--drop table car
insert into car
values ('Toyata Corolla', 4, 4),
		('Honda City', 4, 2),
		('Maruti Swift', 4, 3),
		('Maruti Swift', 2, 1),
  ('Hyundai i20', 2, 7),
  ('Tata Nexon', 4, 6),
  ('Mahindra XUV300', 2, 5),
  ('Ford EcoSport', 4, 8),
  ('Volkswagen Polo', 2, 9),
  ('Renault Kwid', 4, 11),
  ('Skoda Rapid', 4, 10);

  select * from car

create table user_details
(
	user_id int identity primary key,
	firstname varchar(20),
	lastname varchar(20),
	email varchar(50),
	contact varchar(10),
	username varchar(20),
	password varchar(20)
)
--drop table user_details
create table ride
(
	ride_id int identity primary key,
	user_id int references user_details(user_id),
	car_id int references car(car_id),
	source varchar(50),
	destination varchar(80),
	status varchar(10),
)
--drop table ride

select * from driver_details
select * from car
select * from user_details
select * from ride