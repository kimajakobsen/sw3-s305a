create table person(person_id int primary key,
 first_name varchar(255) not null,
 last_name varchar(255) not null,
 address_line1 varchar(255),
 address_line2 varchar(255),
 address_line3 varchar(255),
 address_line4 varchar(255),
 Check (address_line4 is null or address_line3 is not null),
 Check (address_line3 is null or address_line2 is not null),
 Check (address_line2 is null or address_line1 is not null)
); 

insert into person values ('2', 'R','p', 'h','h','g', 'g')
insert into person values ('3', 'R','p', 'h','h','g', null)
insert into person values ('4', 'R','p', null,null,null, null)
insert into person values ('5', 'R','p', null,null,'h', null)
insert into person values ('6', 'R','p', null,null,'h', 'hghghfghfghfghfdg')

select * from person