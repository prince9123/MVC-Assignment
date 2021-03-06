USE [mvcCrudedb]
GO
/****** Object:  StoredProcedure [dbo].[Employeeviewstore]    Script Date: 03-09-2021 10:59:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Employeeviewstore]
@mode nvarchar(max), 
@FirstName varchar(20)=null,
@LastName varchar(20)=null,
@EMP_DOB date=null,
@EmailId varchar(50)=null,
@RoleID int=null,
@EmpId int = null


AS
BEGIN

	SET NOCOUNT ON;
	if(@mode='GetEmpList')
	Begin
	    select
		Emp_ID,
		FirstName,
		LastName,
		EMP_DOB,
		EmailId,
		RoleID
		from Employee


	end
	if(@mode='AddEmployee')
	begin
	INSERT INTO Employee(
	FirstName,
	LastName,
	EMP_DOB,
	EmailId,
	RoleID
	)
	VALUES(
	@FirstName,
	@LastName,
	@EMP_DOB,
	@EmailId,
	@RoleID
	)
	
	End
	if(@mode='GetEmployeeById')
	Begin

	Select
	Emp_ID,
	FirstName,
	LastName,
	EMP_DOB,
	EmailId,
	RoleID
	FROM Employee 
	Where Emp_ID=@EmpId
   End
   if(@mode='UpdateEmployee')
   Begin
   Update Employee
   set FirstName=@FirstName,
   LastName=@LastName,
   EMP_DOB=@EMP_DOB,
   EmailId=@EmailId,
   RoleID=@RoleID
   where Emp_ID=@EmpId
   End

   if(@mode='DeleteEmployee')
   Begin
   Delete From Employee Where Emp_ID=@EmpId
   End




END
