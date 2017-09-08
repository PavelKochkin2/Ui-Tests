using System;
using System.Configuration;
using System.Data;
using System.IO;
using Atata;
using NaturesProducts.DA;
using NaturesProductsUITests.Pages;
using NUnit.Framework;
using System.Net;
using System.Collections.Specialized;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;


namespace NaturesProductsUITests
{
    //[WatchDog(SaveInClass.AllTests)]
    [TestFixture]
    public class AutoTest
    {


        [SetUp]
        public void SetUp()
        {

            var initial = Path.Combine(TestProjectPath, "Db\\CreateScriptForTesting.sql");

            CreateDbIfNotExist();
            ExecuteSqlFile(initial);
            CacheReload();
            AtataContext.Build().
                UseChrome().
                WithArguments("disable-extensions", "no-sandbox", "start-maximized").
                UseBaseUrl(Config.Url).
                UseNUnitTestName().
                AddNUnitTestContextLogging().
                AddScreenshotFileSaving().
                LogNUnitError().
                TakeScreenshotOnNUnitError().
                SetUp();
            LogIn();

        }

        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["AuthorityContext"].ConnectionString; }
        }

        public string TestProjectPath
        {
            get { return Directory.GetParent(TestContext.CurrentContext.TestDirectory).FullName; }
        }

        public string SolutionPath
        {
            get
            {
                return Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.Parent.FullName;
            }
        }

        private void ExecuteSqlFile(string filepath, string specificDbName = null)
        {
            string connectionString = ConnectionString;
            if (!string.IsNullOrEmpty(specificDbName))
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionString);
                builder.InitialCatalog = specificDbName;
                connectionString = builder.ToString();
            }


            var sqlScript = File.ReadAllText(filepath);
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Server server = new Server(new ServerConnection(conn));
                server.ConnectionContext.ExecuteNonQuery(sqlScript);
            }
           
        }

        private void ExecuteNonQuery(string sql, string specificDbName = null)
        {
            string connectionString = ConnectionString;
            if (!string.IsNullOrEmpty(specificDbName))
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionString);
                builder.InitialCatalog = specificDbName;
                connectionString = builder.ToString();
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Server server = new Server(new ServerConnection(conn));
                server.ConnectionContext.ExecuteNonQuery(sql);
            }



        }

        private object ExecuteScalar(string sql)
        {
            using (var command = Db.newCommand(sql))
            {
                using (var connection = Db.newConnection(ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    command.Connection = connection;
                    return command.ExecuteScalar();
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            var clear = Path.Combine(TestProjectPath, "Db\\ClearDataAfterTesting.sql");
            LogOut();
            ExecuteSqlFile(clear);
            CacheReload();
            AtataContext.Current.CleanUp();
            CacheReload();
        }

        public virtual void LogIn()
        {
            Go.To<LoginPage>().
                UserName.Set(Config.Account.Email).
                Password.Set(Config.Account.Password).
                LogIn.ClickAndGo();
        }

        public virtual void LogOut()
        {
            Go.To<WelcomePage>().
                Administrator.Logout.ClickAndGo();
        }

        public void CacheReload()
        {
            // Address for request
            string url = GetAbsolutePath("pages/admin/ClientPages/common/ClientService.ashx?ts=1497369210447&oper=task&cmd=start");


            using (var webClient = new WebClient())
            {
                // Creating parameters collection
                JObject obj = new JObject();

                // Adding needed parameters in pairs : key value
                obj.Add("TaskName", "Reload Cache Service");
                obj.Add("Values", new JArray());

                var paramsRequest = new NameValueCollection();
                paramsRequest.Add("Data", obj.ToString());

                // Sending data on server
                var response = webClient.UploadValues(url, paramsRequest);

            }
        }

        public string GetAbsolutePath(string relativePath)
        {
            var sitePath = ConfigurationManager.AppSettings["Url"];
            if (string.IsNullOrEmpty(sitePath))
            {
                throw new ArgumentException("url param from config");
            }

            return string.Format("{0}/{1}", sitePath, relativePath);
        }

        readonly string masterTableName = "master";
        public void CreateDbIfNotExist()
        {
            string sqlCommand = string.Format("SELECT [Name] FROM sys.databases WHERE [Name] = N'{0}'", masterTableName);
            object obj = ExecuteScalar(sqlCommand);

            if (obj == null)
            {
                ExecuteNonQuery(String.Format("CREATE DATABASE [{0}];", new SqlConnectionStringBuilder(ConnectionString).InitialCatalog));

                try
                {
                    string initialCreateScriptPath = Path.Combine(SolutionPath, "Db\\SQL_InitialCreateScript.sql");

                    ExecuteSqlFile(initialCreateScriptPath);
                }
                catch (Exception ex)
                {
                    //TODO: add loger
                    //log.Error("Error in SQL_InitialCreateScript.sql", ex);
                }

                try
                {
                    string updateScriptPath = Path.Combine(SolutionPath, "Db\\SQL_updateScript.sql");
                    ExecuteSqlFile(updateScriptPath);
                }
                catch (Exception ex)
                {
                    //log.Error("Error in SQL_updateScript.sql", ex);
                }

            }
        }
    }
}
