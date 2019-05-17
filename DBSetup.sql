USE master
GO

IF EXISTS(SELECT name FROM sys.databases WHERE name = N'Stats') 
DROP DATABASE  Stats
GO

CREATE DATABASE Stats
GO

USE Stats
GO

CREATE TABLE LogNames(
	LogId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Descr varchar(50) NOT NULL
);

CREATE TABLE LogData(
	id int IDENTITY(1,1) NOT NULL,
	[DateTime] datetime NULL,
	LogId int FOREIGN KEY REFERENCES LogNames(LogId) ON DELETE CASCADE NOT NULL,
	Val float NULL
);
GO

CREATE PROCEDURE GetCharts
 @params XML
 as
BEGIN
DECLARE @columns NVARCHAR(MAX), @resolution NVARCHAR(5), @startDateTime NVARCHAR(30), @sql NVARCHAR(MAX);

SET @resolution = (SELECT x.y.value('.','INT') AS IDs
          FROM @params.nodes('/SQLParams/Resolution') AS x ( y ))

SET @startDateTime = (SELECT x.y.value('.','NVARCHAR(30)') AS IDs
          FROM @params.nodes('/SQLParams/StartDateTime') AS x ( y ))

SET @columns = N'';
SELECT @columns += N', ' + QUOTENAME(Descr)
FROM (SELECT DISTINCT Descr FROM dbo.LogNames WHERE LogId in(

SELECT x.y.value('.','INT') AS IDs
          FROM @params.nodes('/SQLParams/LogID/int') AS x ( y )

)) AS x;

SET @columns = STUFF(@columns, 1, 2, '')

SET @sql = N'
SELECT [Datetime],' + @columns +'
FROM
(
  SELECT n.Descr, d.Val, d.[Datetime]
   FROM dbo.LogNames AS n
   INNER JOIN dbo.LogData AS d
   ON n.LogId = d.LogId WHERE d.[Datetime] >=  DATEADD(MINUTE,'+ @resolution +','''+ @startDateTime + ''') AND d.[Datetime] < '''+ @startDateTime + ''' 
) AS j 
PIVOT
(
  MAX(Val) FOR Descr IN ('+
  @columns
  + ')
) AS piv  ORDER BY [Datetime] ASC;';
--print @sql;
EXEC sp_executesql @sql;
END
GO
