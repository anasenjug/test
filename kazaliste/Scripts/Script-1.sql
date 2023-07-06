-- public.theater definition

-- Drop table

-- DROP TABLE public.theater;

CREATE TABLE public.theater (
	id uuid NOT NULL,
	"Name" varchar NOT NULL,
	address varchar NOT NULL,
	CONSTRAINT theater_pk PRIMARY KEY (id)
);


-- public.play definition

-- Drop table

-- DROP TABLE public.play;

CREATE TABLE public.play (
	id uuid NOT NULL,
	"Name" varchar NULL,
	genre varchar NULL,
	"Date" date NULL,
	description varchar NULL,
	starttime timestamp NULL,
	endtime timestamp NULL,
	CONSTRAINT play_pk PRIMARY KEY (id)
);


-- public.actor definition

-- Drop table

-- DROP TABLE public.actor;

CREATE TABLE public.actor (
	id uuid NOT NULL,
	firstname varchar NULL,
	lastname varchar NULL,
	CONSTRAINT actor_pk PRIMARY KEY (id)
);


-- public.customer definition

-- Drop table

-- DROP TABLE public.customer;

CREATE TABLE public.customer (
	id uuid NOT NULL,
	"Name" varchar NULL,
	email varchar NULL,
	phone varchar NULL,
	CONSTRAINT customer_pk PRIMARY KEY (id)
);


-- public.department definition

-- Drop table

-- DROP TABLE public.department;

CREATE TABLE public.department (
	id uuid NOT NULL,
	"Name" varchar NOT NULL,
	theaterid uuid NOT NULL,
	CONSTRAINT department_pk PRIMARY KEY (id),
	CONSTRAINT fk_department_theater_theaterid FOREIGN KEY (theaterid) REFERENCES public.theater(id) ON DELETE CASCADE ON UPDATE CASCADE
);


-- public.hall definition

-- Drop table

-- DROP TABLE public.hall;

CREATE TABLE public.hall (
	id uuid NOT NULL,
	"Name" varchar NULL,
	capacity int4 NULL,
	theaterid uuid NOT NULL,
	CONSTRAINT hall_pk PRIMARY KEY (id),
	CONSTRAINT fk_hall_theater_theaterid FOREIGN KEY (theaterid) REFERENCES public.theater(id) ON DELETE CASCADE ON UPDATE CASCADE
);


-- public.staff definition

-- Drop table

-- DROP TABLE public.staff;

CREATE TABLE public.staff (
	id uuid NOT NULL,
	firstname varchar NULL,
	lastname varchar NULL,
	job varchar NULL,
	departmentid uuid NULL,
	CONSTRAINT staff_pk PRIMARY KEY (id),
	CONSTRAINT fk_staff_department_departmentid FOREIGN KEY (departmentid) REFERENCES public.department(id) ON DELETE CASCADE ON UPDATE CASCADE
);


-- public.hallplay definition

-- Drop table

-- DROP TABLE public.hallplay;

CREATE TABLE public.hallplay (
	id uuid NOT NULL,
	hallid uuid NOT NULL,
	playid uuid NULL,
	CONSTRAINT hallplay_pk PRIMARY KEY (id),
	CONSTRAINT fk_hallplay_hall_hallid FOREIGN KEY (hallid) REFERENCES public.hall(id) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT fk_hallplay_play_playid FOREIGN KEY (playid) REFERENCES public.play(id)
);


-- public.actorplay definition

-- Drop table

-- DROP TABLE public.actorplay;

CREATE TABLE public.actorplay (
	id uuid NOT NULL,
	rolename varchar NULL,
	playid uuid NULL,
	actorid uuid NULL,
	CONSTRAINT actorplay_pk PRIMARY KEY (id),
	CONSTRAINT fk_actorplay_actor_actorid FOREIGN KEY (actorid) REFERENCES public.actor(id) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT fk_actorplay_play_playid FOREIGN KEY (playid) REFERENCES public.play(id) ON DELETE CASCADE ON UPDATE CASCADE
);


-- public.booking definition

-- Drop table

-- DROP TABLE public.booking;

CREATE TABLE public.booking (
	id uuid NOT NULL,
	"Date" date NULL,
	seatnr int4 NULL,
	paymentmethodid uuid NULL,
	customerid uuid NULL,
	hallplayid uuid NULL,
	CONSTRAINT booking_pk PRIMARY KEY (id)
);


-- public.paymentmethod definition

-- Drop table

-- DROP TABLE public.paymentmethod;

CREATE TABLE public.paymentmethod (
	id uuid NOT NULL,
	"Method" varchar NULL,
	CONSTRAINT paymentmethod_pk PRIMARY KEY (id)
);


-- public.booking foreign keys

ALTER TABLE public.booking ADD CONSTRAINT fk_booking_customer_customerid FOREIGN KEY (customerid) REFERENCES public.customer(id) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE public.booking ADD CONSTRAINT fk_booking_hallplay_hallplayid FOREIGN KEY (hallplayid) REFERENCES public.hallplay(id);
ALTER TABLE public.booking ADD CONSTRAINT fk_booking_paymentmethod_paymentmethodid FOREIGN KEY (paymentmethodid) REFERENCES public.paymentmethod(id) ON DELETE CASCADE ON UPDATE CASCADE;


-- public.paymentmethod foreign keys

ALTER TABLE public.paymentmethod ADD CONSTRAINT paymentmethod_fk FOREIGN KEY (id) REFERENCES public.booking(id) ON DELETE CASCADE ON UPDATE CASCADE;