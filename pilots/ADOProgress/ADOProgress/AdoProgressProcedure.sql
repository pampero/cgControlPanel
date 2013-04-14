IF EXISTS ( SELECT 1 FROM sys.objects WHERE name = 'AdoProcess_Test1' )
BEGIN
	DROP PROCEDURE AdoProcess_Test1
END
go

CREATE PROCEDURE AdoProcess_Test1
AS
BEGIN
	SET NOCOUNT ON -- Used for performance and making sure we don't send back unneeded information.
	DECLARE @time VARCHAR(16)
	SET @time = CONVERT(VARCHAR(16),GETDATE(),114)
	RAISERROR( 'Completed 25%% At %s', 2, 1, @time) WITH NOWAIT
	WAITFOR DELAY '00:00:03'
	SET @time = CONVERT(VARCHAR(16),GETDATE(),114)
	RAISERROR( 'Completed 50%% At %s', 2, 2, @time) WITH NOWAIT
	WAITFOR DELAY '00:00:03'
	SET @time = CONVERT(VARCHAR(16),GETDATE(),114)
	RAISERROR( 'Completed 75%% At %s', 1, 3, @time) WITH NOWAIT
	WAITFOR DELAY '00:00:03'
	SET @time = CONVERT(VARCHAR(16),GETDATE(),114)
	RAISERROR( 'Completed 100%% At %s', 1, 4, @time) WITH NOWAIT
END;

GRANT EXECUTE ON AdoProcess_Test1 TO public