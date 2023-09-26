CREATE TABLE Analysis
(
AnalysisId int identity(1,1) not null,
Name varchar(50),
State int not null,
AuditCreateDate datetime2(7) not null,
constraint pk_Analysis primary key(AnalysisId)
)
go

create proc uspAnalyisList
as
begin

	SELECT AnalysisId, Name,  AuditCreateDate, State FROM Analysis
end

EXEC uspAnalyisList
go

create proc uspAnalysisById
(
	@AnalysisId int 
)
as
begin
	SELECT 
		AnalysisId, 
		Name 
	FROM Analysis where AnalysisId = @AnalysisId
end
go

exec uspAnalysisById 3
go

create proc uspAnalysisRegister
(@Name varchar(50),
@State int,
@AuditCreateDate datetime)
as 
begin
	insert into Analysis(name, state, AuditCreateDate) 
	values (@Name, @State, @AuditCreateDate);
end
go

create proc uspAnalysisEdit
(
@AnalysisId int,
@Name varchar(50)
)
as
begin
	update Analysis set
		Name = @Name
	where AnalysisId = @AnalysisId
end
go

create proc uspAnalysisRemove
(@AnalysisId int)
as
begin
	delete from Analysis where AnalysisId = @AnalysisId;
end

