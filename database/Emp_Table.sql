/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Emp_ID]
      ,[FirstName]
      ,[LastName]
      ,[EMP_DOB]
      ,[EmailId]
      ,[RoleID]
  FROM [mvcCrudedb].[dbo].[Employee]