/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Proid]
      ,[Project_name]
      ,[StartDate]
      ,[EndDate]
      ,[Budget]
  FROM [mvcCrudedb].[dbo].[Project]