USE [mvcCrudedb]
GO
/****** Object:  StoredProcedure [dbo].[ProjectVieworInsrert]    Script Date: 03-09-2021 11:01:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ProjectVieworInsrert]
@mode varchar (max),
@Project_name varchar (max) = null,
@StartDate varchar (max) = null,
@EndDtae varchar (max) = null,
@Budget varchar (max) = null,
@em_Proid int = null

	
AS
Begin

	SET NOCOUNT ON;

	if(@mode='GetProjectList')
	Begin

	select  
	Proid,
	Project_name,
	StartDate,
	EndDate,
	Budget
	From Project
	
End
if(@mode='AddProject')
Begin

    INSERT INTO Project(
    Project_name,
	StartDate,
	EndDate,
	Budget
	)
	values(
	@Project_name,
	@StartDate,
	@EndDtae,
	@Budget
	)
  
  End

  if(@mode='GetEditByProid')
  Begin
  select
  Proid,
  Project_name,
  StartDate,
  EndDate,
  Budget
  FROM Project
  where  Proid = @em_Proid
  End 


  if(@mode='UpdatePro')
  Begin
  update Project
  set Project_name = @Project_name,
  StartDate = @StartDate,
  EndDate = @EndDtae,
  Budget = @Budget
  where Proid=@em_Proid
End

if(@mode='DeleteProject')
Begin
 Delete From Project WHERE Proid = @em_Proid
 End
 end
