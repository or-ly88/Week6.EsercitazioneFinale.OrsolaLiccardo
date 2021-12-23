Create database GestioneSpesa

create table Categoria(
IDCategoria int identity (1,1)constraint PK_IDCategoria primary key,
Nome varchar (100)
)

create table Spesa(
ID int identity(1,1)constraint PK_ID primary key,
Insert_date date,
Descrizione varchar(100),
Utente varchar(100),
Importo decimal(10,2) constraint check_Importo check(Importo>=0),
Approvata bit,
constraint check_dates check (Insert_date >= GETDATE()),
Categoria int foreign key references Categoria(IDCategoria)
)

INSERT INTO Categoria VALUES('Shopping');
INSERT INTO Categoria VALUES('Finanziamento');