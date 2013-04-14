using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

using ADOProgress.Properties;

namespace ADOProgress
{
    internal class Program
    {
        private const string ConnectionStr = "Data Source=(local);Initial Catalog=tempdb;Trusted_Connection=SSPI;Asynchronous Processing=true";
        private const string StoredProc = "AdoProcess_Test1";
        private static readonly ManualResetEvent _reset = new ManualResetEvent(false);

        private static void Main()
        {
            if (TestConnection())
            {
                CreateObject();
                TestNonExecuteMethod();
                TestExecuteReaderMethod();
                //TestExecuteReaderBackupMethod();
                DropObject();
            }
        }

        private static void TestNonExecuteMethod()
        {
            Console.WriteLine("Staring of Non Execute Method....");
            _reset.Reset();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStr))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProc, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 30;
                        cmd.Connection.InfoMessage += ConnectionInfoMessage;
                        AsyncCallback result = NonQueryCallBack;
                        cmd.Connection.Open();
                        cmd.BeginExecuteNonQuery(result, cmd);
                        Console.WriteLine("Waiting for completion of executing stored procedure....");
                        _reset.WaitOne();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problem with executing command! - [{0}]", ex.Message);
            }
            Console.WriteLine("Completion of Non Execute Method....");
        }
        
        private static void TestExecuteReaderMethod()
        {
            Console.WriteLine("Staring of Execute Reader Method....");
            _reset.Reset();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStr))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProc, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.InfoMessage += ConnectionInfoMessage;
                        AsyncCallback result = ReaderCallback;
                        cmd.Connection.Open();
                        cmd.BeginExecuteReader(result, cmd);
                        Console.WriteLine("Waiting for completion of executing stored procedure....");
                        _reset.WaitOne();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problem with executing command! - [{0}]", ex.Message);
            }


            Console.WriteLine("Completion of Execute Reader Method....");
        }

        private static void TestExecuteReaderBackupMethod()
        {
            Console.WriteLine("Staring of Execute Reader Method....");
            _reset.Reset();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStr))
                {
                    using (SqlCommand cmd = new SqlCommand("BACKUP DATABASE msdb TO DISK ='backup1.bak' WITH FORMAT;", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection.InfoMessage += ConnectionInfoMessage;
                        AsyncCallback result = ReaderCallback;
                        cmd.Connection.Open();
                        cmd.BeginExecuteReader(result, cmd);
                        Console.WriteLine("Waiting for completion of executing stored procedure....");
                        _reset.WaitOne();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problem with executing command! - [{0}]", ex.Message);
            }


            Console.WriteLine("Completion of Execute Reader Method....");
        }

        #region Misc Test Methods

        private static void ConnectionInfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            if ( e.Errors.Count > 0 )
            {
                // Check to make sure we are information only messages
                Console.WriteLine("Recieved {0} messages", e.Errors.Count);
                foreach( SqlError info in e.Errors )
                {
                    if ( info.Class > 9 ) // Severity
                    {
                        Console.WriteLine("Error Message : {0} : State : {1}", info.Message, info.State );
                    }
                    else
                    {
                        Console.WriteLine("Info Message : {0} : State : {1}", info.Message, info.State);
                    }
                }
            }
            else
            {
                Console.WriteLine("Recieved Connection Info Message : {0}", e.Message);                
            }
        }

        private static void ReaderCallback(IAsyncResult result)
        {
            SqlCommand command = (SqlCommand) result.AsyncState;
            try
            {
                if (command != null)
                {
                    Console.WriteLine("Waiting for completion of the Async call");
                    command.EndExecuteReader(result);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problem with executing command! - [{0}]", ex.Message);
            }
            finally
            {
                Console.WriteLine("Completed call back so signal main thread to continue....");
                _reset.Set();
            }
        }

        private static void NonQueryCallBack(IAsyncResult result)
        {
            SqlCommand command = (SqlCommand) result.AsyncState;
            try
            {
                if (command != null)
                {
                    Console.WriteLine("Waiting for completion of the Async call");
                    command.EndExecuteNonQuery(result);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problem with executing command! - [{0}]", ex.Message);
            }
            finally
            {
                Console.WriteLine("Completed call back so signal main thread to continue....");
                _reset.Set();
            }
        }

        #endregion

        #region Helpers

        private static bool TestConnection()
        {
            bool res = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStr))
                {
                    connection.Open();
                    string ver = connection.ServerVersion;
                    Console.WriteLine("Connected to SQL Server {0} Version {1}", connection.DataSource, ver);
                    res = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problem connecting! {0}", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Problem connecting! {0}", ex.Message);
            }
            return res;
        }

        private static void CreateObject()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStr))
                {
                    connection.Open();
                    string[] batches = Resources.AdoProgressProcedure.Split(new[] {"go", "GO"}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string batch in batches)
                    {
                        using (SqlCommand cmd = new SqlCommand(batch, connection))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                Console.WriteLine("Created Test Stored Procedure Successfully");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problem creating test procedure! {0}", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Problem creating test procedure! {0}", ex.Message);
            }
        }

        private static void DropObject()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStr))
                {
                    connection.Open();
                    string[] batches = Resources.AdoProgressProcedure.Split(new[] {"go", "GO"}, StringSplitOptions.RemoveEmptyEntries);
                    using (SqlCommand cmd = new SqlCommand(batches[0], connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Dropped Test Stored Procedure Successfully");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problem dropping test procedure! {0}", ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Problem dropping test procedure! {0}", ex.Message);
            }
        }

        #endregion

        //BACKUP DATABASE msdb TO DISK ='.\backup1.bak' WITH FORMAT;
    }
}