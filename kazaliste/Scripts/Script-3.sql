CREATE TABLE "Theater" (
	"Id" uuid NOT NULL,
	"Name" varchar NOT NULL,
	"Address" varchar NOT NULL,
	CONSTRAINT theater_pk PRIMARY KEY ("Id")
);

CREATE TABLE "Play" (
	"Id" uuid NOT NULL,
	"Name" varchar NULL,
	"Genre" varchar NULL,
	"Date" date NULL,
	"Description" varchar NULL,
	"StartTime" timestamp NULL,
	"EndTime" timestamp NULL,
	CONSTRAINT play_pk PRIMARY KEY ("Id")
);

CREATE TABLE "Actor" (
	"Id" uuid NOT NULL,
	FirstName varchar NULL,
	LastName varchar NULL,
	CONSTRAINT actor_pk PRIMARY KEY ("Id")
);

CREATE TABLE "Customer" (
	"Id" uuid NOT NULL,
	"Name" varchar NULL,
	"Email" varchar NULL,
	"Phone" varchar NULL,
	CONSTRAINT customer_pk PRIMARY KEY ("Id")
);

CREATE TABLE "Department" (
	"Id" uuid NOT NULL,
	"Name" varchar NOT NULL,
	"TheaterId" uuid NOT NULL,
	CONSTRAINT department_pk PRIMARY KEY ("Id"),
	CONSTRAINT fk_department_theater_theaterId FOREIGN KEY ("TheaterId") REFERENCES "Theater"("Id") ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE "Hall" (
	"Id" uuid NOT NULL,
	"Name" varchar NULL,
	"Capacity" int4 NULL,
	"TheaterId" uuid NOT NULL,
	CONSTRAINT hall_pk PRIMARY KEY ("Id"),
	CONSTRAINT fk_hall_theater_TheaterId FOREIGN KEY ("TheaterId") REFERENCES "Theater"("Id") ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE "Staff" (
	"Id" uuid NOT NULL,
	"FirstName" varchar NULL,
	"LastName" varchar NULL,
	"Job" varchar NULL,
	"DepartmentId" uuid NULL,
	CONSTRAINT staff_pk PRIMARY KEY ("Id"),
	CONSTRAINT fk_staff_department_DepartmentId FOREIGN KEY ("DepartmentId") REFERENCES "Department"("Id") ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE "HallPlay" (
	"Id" uuid NOT NULL,
	"HallId" uuid NOT NULL,
	"PlayId" uuid NULL,
	CONSTRAINT hallplay_pk PRIMARY KEY ("Id"),
	CONSTRAINT fk_hallplay_hall_HallId FOREIGN KEY ("HallId") REFERENCES "Hall"("Id") ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT fk_hallplay_play_PlayId FOREIGN KEY ("PlayId") REFERENCES "Play"("Id")
);

CREATE TABLE "ActorPlay" (
	"Id" uuid NOT NULL,
	"RoleName" varchar NULL,
	"PlayId" uuid NULL,
	"ActorId" uuid NULL,
	CONSTRAINT actorplay_pk PRIMARY KEY ("Id"),
	CONSTRAINT fk_actorplay_actor_ActorId FOREIGN KEY ("ActorId") REFERENCES "Actor"("Id") ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT fk_actorplay_play_PlayId FOREIGN KEY ("PlayId") REFERENCES "Play"("Id") ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE "PaymentMethod" (
	"Id" uuid NOT NULL,
	"Method" varchar NULL,
	CONSTRAINT paymentmethod_pk PRIMARY KEY ("Id")
);

CREATE TABLE "Booking" (
	"Id" uuid NOT NULL,
	"Date" date NULL,
	"SeatNr" int4 NULL,
	"PaymentMethodId" uuid NULL,
	"CustomerId" uuid NULL,
	"HallPlayId" uuid NULL,
	CONSTRAINT booking_pk PRIMARY KEY ("Id")
);

ALTER TABLE "Booking" ADD CONSTRAINT fk_booking_customer_CustomerId FOREIGN KEY ("CustomerId") REFERENCES "Customer"("Id") ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE "Booking" ADD CONSTRAINT fk_booking_hallplay_HallPlayId FOREIGN KEY ("HallPlayId") REFERENCES "HallPlay"("Id");

ALTER TABLE "Booking" ADD CONSTRAINT fk_booking_paymentmethod_PaymentMethodId FOREIGN KEY ("PaymentMethodId") REFERENCES "PaymentMethod"("Id") ON DELETE CASCADE ON UPDATE CASCADE;

INSERT INTO public."Theater" ("Id", "Name", "Address")
VALUES
  ('b4c9d7a2-d125-4f68-b97c-4fda23e3e50e', 'City Theater', '123 Main Street'),
  ('e52c8895-8f8f-4c37-a42d-5dbb48ad684c', 'Starlight Theater', '456 Broadway Ave'),
  ('a609fe92-3c1d-4f5c-a7a5-10de9db29f1f', 'Grand Opera House', '789 Center Street');
  
 INSERT INTO public."Play" ("Id", "Name", "Genre", "Date", "Description", "StartTime", "EndTime")
VALUES
  ('d9f8f8ed-920d-478b-938b-0316b3b1ff09', 'Romeo and Juliet', 'Tragedy', '2023-07-15', 'Classic Shakespearean play', '2023-07-15 18:30:00', '2023-07-15 22:00:00'),
  ('e1d2dd01-1734-4287-87e6-ebcc2a927a9e', 'The Great Gatsby', 'Drama', '2023-07-20', 'Adaptation of F. Scott Fitzgerald novel', '2023-07-20 19:00:00', '2023-07-20 21:30:00'),
  ('f702c998-8c3b-4879-bf9f-7e74a462165c', 'A Midsummer Nights Dream', 'Comedy', '2023-07-25', 'Shakespearean comedy', '2023-07-25 18:45:00', '2023-07-25 21:15:00');