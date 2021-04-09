--dropovanje seme
if exists(select * from sys.schemas where name=N'sony')
drop schema sony
go
--dodavanje seme
create schema sony
go
--brisanje tabela
if object_id('sony.Stavka','u') is not null
drop table sony.Stavka
go
if object_id('sony.Racun','u') is not null
drop table sony.Racun
go
if object_id('sony.Iznajmljivanje','u') is not null
drop table sony.Iznajmljivanje
go
if object_id('sony.Radnik','u') is not null
drop table sony.Radnik
go
if object_id('sony.Konzola','u') is not null
drop table sony.Konzola
go
if object_id('sony.Pice','u') is not null
drop table sony.Pice
go
if object_id('sony.Clan','u') is not null
drop table sony.Clan
go
if object_id('sony.Slusalice','u') is not null
drop table sony.Slusalice
go
if object_id('sony.Joyped','u') is not null
drop table sony.Joyped
go
if object_id('sony.Dostupnost','u') is not null
drop table sony.Dostupnost
go

if object_id('sony.KnjigaSanka','u') is not null
drop table sony.Sank
go

/*kreiranje tabela*/
create table sony.Dostupnost
(
	IdDostupnosti int IDENTITY(1,1) ,
	Naziv varchar(20),
	Slobodna bit,
	BrojPoslednjegRacuna int,
	constraint PK_Dostupnost primary key (IdDostupnosti)
);

create table dbo.KnjigaSanka
(
	IdKnjigaSanka int IDENTITY(1,1) ,
	NazivPica varchar(20),
	Stanje int,
	PoslednjaIzmenaIzvrsena datetime,
	constraint PK_KnjigaSanka primary key (IdKnjigaSanka)
);


create table sony.Radnik
(
	IdRadnika int IDENTITY(1,1) ,
	ImePrz varchar(20),
	BrojTelefonaR varchar(20),
	constraint PK_Radnik primary key (IdRadnika)
);

create table sony.Konzola
(
	IdKonzole int IDENTITY(1,1),
	ImeKonzole varchar(50),
	Model varchar (50),
	CenaPoSatu varchar(50),
	constraint PK_Konzola primary key (IdKonzole)
);

create table sony.Pice
(
	IdPica int IDENTITY(1,1),
	Predmet varchar(50),
	Vrsta varchar(50),
	Podvrsta varchar(50),
	CenaPoKomadu varchar(50),
	constraint PK_Pice primary key (IdPica)
);
create table sony.Slusalice 
(
	IdSlusalica int IDENTITY(1,1),
	CenaSlusalica varchar(50),
	NazivSlusalica varchar(50),
	constraint PK_Slusalice primary key (IdSlusalica)
);

create table sony.Joyped
(
	IdJoypeda int IDENTITY(1,1),
	ImeJoypeda varchar(50),
	CenaJoypeda varchar(50),
	constraint PK_Joyped primary key (IdJoypeda)
);
create table sony.Clan 
(
	IdClan int IDENTITY(1,1),
	Ime varchar(50),
	Prezime varchar(50),
	BrojDolaska int,
	BrojTelefona varchar(50),
	KumulativnoSati varchar(25),
	Napomena varchar(500),
	constraint PK_Clan primary key (IdClan)
);
create table sony.Iznajmljivanje
(
	IdIznajmljivanje int IDENTITY(1,1), 
	Datum date,
	VremePocetka datetime,
	VremeZavrsavanja datetime,
	IdSlusalica int,
	IdJoypeda int,
	IdClan int,
	IdRadnika int,
	IdKonzole int,
	constraint PK_Iznajmljivanje primary key(IdIznajmljivanje),
	constraint FK_Iznajmljivanje_Slusalice foreign key(IdSlusalica) references sony.Slusalice (IdSlusalica),
	constraint FK_Iznajmljivanje_Joyped foreign key(IdJoypeda) references sony.Joyped (IdJoypeda),
	constraint FK_Iznajmljivanje_Clan foreign key(IdClan) references sony.Clan (IdClan),
	constraint FK_Iznajmljivanje_Radnik foreign key(IdRadnika) references sony.Radnik (IdRadnika),
	constraint FK_Iznamljivanje_Konzola foreign key(IdKonzole) references sony.Konzola (IdKonzole)
);

create table sony.Racun
(
	IdRacuna int IDENTITY(1,1),
	DatumR date,
	Naplaceno bit,
	IzdatRacunPice bit,
	IzdatRacunIznajmljivanje bit,
	CenaIznajmljvanja varchar(50),
	KomadaPica int,
	CenaPica varchar(50),
	UkupnaCena varchar(50),
	IdIznajmljivanje int,
	IdPica int,
	constraint PK_Racun primary key(IdRacuna),
	constraint FK_Racun_Pice foreign key(IdPica) references sony.Pice  (IdPica),
	constraint FK_Racun_Iznamljivanje foreign key(IdIznajmljivanje) references sony.Iznajmljivanje (IdIznajmljivanje)
);
create table sony.Stavka
(
	IdStavka int IDENTITY(1,1),
	IdRacuna integer,
	KomadaPica integer,
	IdPica integer,
	constraint PK_Stavka primary key(IdStavka),
	constraint FK_Stavka_Pice foreign key(IdPica) references sony.Pice  (IdPica),
	constraint FK_Stavka_Racun foreign key(IdRacuna) references sony.Racun (IdRacuna)
);
