/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--------------------------------------------------------------------------------------
--EXAMPLE TABLE
--------------------------------------------------------------------------------------
SELECT TOP 0 * INTO #Mock FROM [dbo].[MockTable];

INSERT INTO #Mock ([Id], [Firstname], [Surname]) VALUES 
('bfa2b058-da81-4f61-b263-fbe9080e9cf4', 'Michael', 'Kendal'),
('c6e14ce9-ed25-4f2c-a5b3-21095eb3e66e', 'Corey', 'Vaughan');

MERGE [dbo].[MockTable] AS TARGET
USING #Mock AS SOURCE ON (TARGET.Id = SOURCE.Id)
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id], [Firstname], [Surname])
VALUES (SOURCE.Id, SOURCE.[Firstname], SOURCE.[Surname]);

IF(OBJECT_ID('tempdb..#Mock') IS NOT NULL)
BEGIN
	DROP TABLE #Mock
END