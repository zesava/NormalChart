USE master
GO

IF EXISTS(SELECT name FROM sys.databases WHERE name = N'Stats')
BEGIN
ALTER DATABASE [Stats] set single_user with rollback immediate
DROP DATABASE  Stats
END
GO

CREATE DATABASE Stats
GO

USE Stats
GO

CREATE TABLE LogNames(
	LogId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Descr nvarchar(50) NOT NULL
);

CREATE TABLE LogData(
	id int IDENTITY(1,1) NOT NULL,
	[DateTime] datetime NULL,
	LogId int FOREIGN KEY REFERENCES LogNames(LogId) ON DELETE CASCADE NOT NULL,
	Val real NULL
);
GO

CREATE PROCEDURE GetCharts
 @params XML
 as
BEGIN
DECLARE @columns NVARCHAR(MAX),@columns_int NVARCHAR(MAX), @resolution NVARCHAR(5), @startDateTime NVARCHAR(30), @sql NVARCHAR(MAX);

SET @resolution = (SELECT x.y.value('.','INT') FROM @params.nodes('/SQLParams/Resolution') AS x (y))
SET @startDateTime = CONVERT(datetime, (SELECT x.y.value('.','NVARCHAR(30)') FROM @params.nodes('/SQLParams/StartDateTime') AS x (y)),103)


SET @columns_int = N'';
SELECT @columns_int += N', '+ CAST(IDs as varchar) FROM 
(SELECT x.y.value('.','INT') AS IDs FROM @params.nodes('/SQLParams/LogID/int') AS x (y)) 
AS r; 
SET @columns_int = STUFF(@columns_int, 1, 2, '')


SET @columns = N'';
SELECT @columns += N', ' + QUOTENAME(Descr)
FROM (SELECT Descr FROM dbo.LogNames WHERE LogId IN(
SELECT x.y.value('.','INT') FROM @params.nodes('/SQLParams/LogID/int') AS x (y)
)) AS x;

SET @columns = STUFF(@columns, 1, 2, '')

SET @sql = N'
SELECT *
FROM
(
  SELECT n.Descr, ROUND(d.Val,3) as Val, d.[Datetime]
   FROM dbo.LogData AS d
   INNER JOIN dbo.LogNames AS n
   ON n.LogId = d.LogId WHERE d.[Datetime] >=  DATEADD(MINUTE,'+ @resolution +','''+ @startDateTime + ''') AND d.[Datetime] < '''+ @startDateTime + ''' 
   AND d.LogId IN (' +@columns_int +')
) AS j 
PIVOT
(
  MAX(Val) FOR Descr IN ('+
  @columns
  + ')
) AS piv  ORDER BY [Datetime] ASC;';
print @sql;
EXEC sp_executesql @sql;
END

GO
