CREATE DATABASE Pilkarzyki;
GO

use Pilkarzyki;

CREATE TABLE Players
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(20)
)

INSERT INTO Players VALUES('Micha³ Œ.')
INSERT INTO Players VALUES('Marta')
INSERT INTO Players VALUES('Krystian')
INSERT INTO Players VALUES('Szynka')
INSERT INTO Players VALUES('Piotr')
INSERT INTO Players VALUES('Gajeœ')
INSERT INTO Players VALUES('Orzech')
INSERT INTO Players VALUES('Wojtek')
INSERT INTO Players VALUES('£ukasz D.')
INSERT INTO Players VALUES('£ukasz Escalar')
INSERT INTO Players VALUES('Gosia')
INSERT INTO Players VALUES('Dominik')
INSERT INTO Players VALUES('Arek')

create table match 
(
	Id int primary key identity(1,1),
	RedDefenderId int foreign key references Players(Id),
	RedAttackerId  int foreign key references Players(Id),
	BlueDefenderId  int foreign key references Players(Id),
	BlueAttackerId  int foreign key references Players(Id),
	RedScore INT,
	BlueScore INT
)
go

create view MatchList
as
(
	select m.Id, RedScore, BlueScore, pbd.Name + ' ' + pba.Name as BlueTeam,
	prd.Name + ' ' + pra.Name as RedTeam from Match m
	inner join Players pbd on pbd.Id = m.BlueDefenderId
	inner join Players pba on pba.Id = m.BlueAttackerId
	inner join Players prd on prd.Id = m.RedDefenderId
	inner join Players pra on pra.Id = m.RedAttackerId
)

go

create view TeamScores
as
(
	select x.Player1, x.Player2, SUM(x.SumScore) as SumScore from (
		select pbd.Name as Player1, pbe.Name as Player2, SUM(RedScore) as SumScore from Match m
		inner join Players pbd on pbd.Id = m.RedAttackerId
		inner join Players pbe on pbe.Id = m.RedDefenderId
		group by pbd.Name, pbe.Name
		union all
		select pbd.Name as Player1, pbe.Name as Player2, SUM(BlueScore) as SumScore from Match m
		inner join Players pbd on pbd.Id = m.BlueAttackerId
		inner join Players pbe on pbe.Id = m.BlueDefenderId
		group by pbd.Name, pbe.Name
		) x
	group by x.Player1, x.Player2
)

