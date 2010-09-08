-------------------------------------------------------------------------------
-- Data for the University schema
-------------------------------------------------------------------------------
-- If you have problems loading the data try to change the default date format.
-- If you cannot do this it can be done manually for each insert statement,
-- which contains a date. As an example change the following insert statement
-- >insert into takes values ('DBS', 1, '2007-01-01', 'spring', null);
-- to
-- >insert into takes values ('DBS', 1, to_date('2007-01-01', 'SYYYY-MM-DD'), 'spring', null);

--1
insert into course values ('DBS', 'Database Systems', 3);
insert into course values ('PDK', 'Communication', 2);
insert into course values ('SV',  'Semantics and Verification', 3);
insert into course values ('SF',  'System Development' , 3);
insert into course values ('SOE', 'Software Engineering', 3);
insert into course values ('RTS', 'Real-Time Systems', 3);
insert into course values ('MP',  'Mini Project', 1);

--1
insert into teacher values (1, 'Aaen', 'E111');
insert into teacher values (2, 'Dolog', 'E116');
insert into teacher values (3, 'Larsen', 'E117');
insert into teacher values (4, 'Ravn', 'E161');
insert into teacher values (5, 'Srba', 'E166');
insert into teacher values (6, 'Rose', 'E167');
insert into teacher values (7, 'Torp', 'E171');
insert into teacher values (8, 'Lazy', 'E176');


--1 
insert into gives values ('DBS', 7);
insert into gives values ('PDK', 5);
insert into gives values ('SV', 5);
insert into gives values ('SV', 3);
insert into gives values ('SF', 3);
insert into gives values ('SOE', 1);
insert into gives values ('SOE', 2);
insert into gives values ('RTS', 4);
insert into gives values ('MP', 1);
insert into gives values ('MP', 2);
insert into gives values ('MP', 5);
insert into gives values ('MP', 7);

--1
insert into student values (1, 'Anne', 'A777');
insert into student values (2, 'Albert', 'A777');
insert into student values (3, 'Arne', 'A777');

insert into student values (4, 'Bent', 'A888');
insert into student values (5, 'Brail', 'A888');
insert into student values (6, 'Bente', 'A888');
insert into student values (7, 'Bono', 'A888');

insert into student values (8, 'Charlie', 'A2');

insert into student values (9, 'Dorit', 'P2');

insert into student values (100, 'Zorro', 'X888');
insert into student values (101, 'Zill', 'XY-985');

--1
insert into takes values ('DBS', 1, '2007-01-01', 'spring', null);
insert into takes values ('PDK', 1, '2007-01-01', 'spring', null);
insert into takes values ('SV', 1, '2007-01-01', 'spring', null);
insert into takes values ('SOE', 1, '2007-01-01', 'spring', null);
insert into takes values ('MP', 1, '2007-01-01', 'spring', null);

insert into takes values ('DBS', 2, '2007-01-01', 'spring', null);
insert into takes values ('PDK', 2, '2007-01-01', 'spring', null);
insert into takes values ('SV', 2, '2007-01-01', 'spring', null);
insert into takes values ('SOE', 2, '2007-01-01', 'spring', null);
insert into takes values ('MP', 2, '2007-01-01', 'spring', null);

insert into takes values ('DBS', 3, '2007-01-01', 'spring', null);
insert into takes values ('PDK', 3, '2007-01-01', 'spring', null);
insert into takes values ('SV', 3, '2007-01-01', 'spring', null);
insert into takes values ('SOE', 3, '2007-01-01', 'spring', null);
insert into takes values ('MP', 3, '2007-01-01', 'spring', null);

insert into takes values ('DBS', 4, '2007-01-01', 'spring', null);
insert into takes values ('PDK', 4, '2007-01-01', 'spring', null);
insert into takes values ('SV', 4, '2007-01-01', 'spring', null);
insert into takes values ('SOE', 4, '2007-01-01', 'spring', null);
insert into takes values ('MP', 4, '2007-01-01', 'spring', null);

insert into takes values ('DBS', 5, '2007-01-01', 'spring', null);
insert into takes values ('PDK', 5, '2007-01-01', 'spring', null);
insert into takes values ('SV', 5, '2007-01-01', 'spring', null);
insert into takes values ('SOE', 5, '2007-01-01', 'spring', null);
insert into takes values ('MP', 5, '2007-01-01', 'spring', null);

insert into takes values ('DBS', 6, '2007-01-01', 'spring', null);
insert into takes values ('PDK', 6, '2007-01-01', 'spring', null);
insert into takes values ('SV', 6, '2007-01-01', 'spring', null);
insert into takes values ('SOE', 6, '2007-01-01', 'spring', null);
insert into takes values ('MP', 6, '2007-01-01', 'spring', null);

insert into takes values ('DBS', 7, '2007-01-01', 'spring', null);
insert into takes values ('PDK', 7, '2007-01-01', 'spring', null);
insert into takes values ('SV', 7, '2007-01-01', 'spring', null);
insert into takes values ('SOE', 7, '2007-01-01', 'spring', null);
insert into takes values ('MP', 7, '2007-01-01', 'spring', null);

insert into takes values ('DBS', 8, '2007-01-01', 'spring', null);
insert into takes values ('PDK', 8, '2007-01-01', 'spring', null);

insert into takes values ('DBS', 9, '2007-01-01', 'spring', null);
insert into takes values ('SV', 9, '2007-01-01', 'spring', null);
insert into takes values ('SOE', 9, '2007-01-01', 'spring', null);

--1
insert into lecture values ('DBS', 1, 'Introduction', null);
insert into lecture values ('DBS', 2, 'The Relational Model and Relational Algebra', null);
insert into lecture values ('DBS', 3, 'Relational Algebra and Relational Calculus', null);
insert into lecture values ('DBS', 4, 'Entity-Relationship Model', null);
insert into lecture values ('DBS', 5, 'SQL', null);
insert into lecture values ('DBS', 6, 'SQL', null);
insert into lecture values ('DBS', 7, 'Logical Database Design', null);
insert into lecture values ('DBS', 9, 'Physical Database Design', null);

insert into lecture values ('PDK', 1, 'Introduction', null);
insert into lecture values ('PDK', 2, 'Writing a Scientific Paper', null);
insert into lecture values ('PDK', 3, 'Presenting a Scientific Work', null);
insert into lecture values ('PDK', 4, 'To appear', null);
insert into lecture values ('PDK', 5, 'To appear 1 ', null);
insert into lecture values ('PDK', 6, 'To appear 2 ', null);

insert into lecture values ('SF', 1, 'mechanistic v romantic worldviews, organic v bureaucratic organization', null);
insert into lecture values ('SF', 2, 'data v information, hard v soft systems', null);

insert into lecture values ('SV', 1, 'Labelled Transition Systems', null);
insert into lecture values ('SV', 2, 'CCS', null);
insert into lecture values ('SV', 3, 'CCS 1', null);
insert into lecture values ('SV', 4, 'CCS 2', null);
insert into lecture values ('SV', 5, 'CCS 3', null);
insert into lecture values ('SV', 6, 'CCS 4', null);

insert into lecture values ('SOE', 1, 'Introduction and Course Organization', null);
insert into lecture values ('SOE', 2, 'Perspectives on Software Engineering', null);
insert into lecture values ('SOE', 3, 'Requirements Engineering and SCURM', null);

insert into lecture values ('RTS', 1, 'Designing real-time systems', null);
insert into lecture values ('RTS', 2, 'Real-Time facilities', null);
insert into lecture values ('RTS', 3, 'Scheduling Responsetime Calculation', null);
insert into lecture values ('RTS', 4, 'Scheduling, blocking etc.', null);
insert into lecture values ('RTS', 5, 'Low Level Programming A Kernel', null);
insert into lecture values ('RTS', 6, 'The execution environment', null);


--1
insert into semester values ('dat1', 'OOAD + OOP');
insert into semester values ('dat2', 'Compiler construction');
insert into semester values ('dat3', 'Smart machines');
insert into semester values ('dat4', 'Database');
insert into semester values ('dat5', 'Thesis one');
insert into semester values ('dat6', 'Thesis two');


insert into sem_stud values ('dat4', 1);
insert into sem_stud values ('dat4', 2);
insert into sem_stud values ('dat4', 3);
insert into sem_stud values ('dat4', 4);
insert into sem_stud values ('dat4', 5);
insert into sem_stud values ('dat4', 6);
insert into sem_stud values ('dat4', 7);
insert into sem_stud values ('dat6', 8);
insert into sem_stud values ('dat6', 9);
insert into sem_stud values ('dat2', 100);
insert into sem_stud values ('dat2', 101);
