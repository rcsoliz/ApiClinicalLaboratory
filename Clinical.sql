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

create or alter proc uspAnalysisRegister
(@Name varchar(50))
as 
begin
	insert into Analysis(name, state, AuditCreateDate) 
	values (@Name, 1, GETDATE());
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
go


create or alter proc uspAnalysisChangeState
(
@AnalysisId int,
@State int
)
as
begin
 	update Analysis set
		State = @State
	where AnalysisId = @AnalysisId
end
go

create table Exams
(ExamId int Identity(1,1) NOT NULL,
Name varchar(100),
AnalysisId int not null,
State int not null,
AuditCreateDate Datetime2(7) not null
);

alter table Exams add constraint  pkExams primary key(ExamId);

alter table Exams add constraint fk_Analysis_Exams 
foreign key (AnalysisId) references Analysis (AnalysisId);
go


Create or alter Proc uspExamList
as
begin
	select 
		ex.ExamId,
		ex.Name,
		a.Name Analysis,
		ex.AuditCreateDate,
		case ex.State when 1 then 'ACTIVO'	
		else 'INACTIVO' 
		end StateExam
	from Exams ex
	inner join Analysis a
	on ex.AnalysisId = a.AnalysisId
end
go

Create or alter Proc uspExamById
(@ExamId int)
as
begin
	select 
		ex.ExamId,
		ex.Name,
		ex.AnalysisId
	from Exams ex where ex.ExamId =@ExamId
end
go


create or alter proc uspExamRegister
(
@Name varchar(100),
@AnalysisId int
)
as
begin
	insert into Exams
	(
		Name, 
		AnalysisId,
		State,
		AuditCreateDate
	)
	values
	(
		@Name,
		@AnalysisId,
		1,
		GetDate()
	)
end

create or alter proc uspExamEdit
(
@ExamId int,
@Name varchar(100),
@AnalysisId int
)
as
begin
	update Exams set
		Name = @Name,
		AnalysisId = @AnalysisId
	where ExamId = @ExamId
end