using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessLogic.Layer.Base;
using BusinessLogic.Layer.ManagerObjects;
using BusinessLogic.Layer.BusinessObjects;

namespace BusinessLogic.Layer
{
    public class Bootstrapper
    {
        public Bootstrapper() { }

        public static void InitializeDB()
        {
            //will throw config error if connection.connection_string is not set properly     
            try
            {
                InitializeAccount();
            }
            catch
            {
                CreateDatabaseSchemaFromMappingFiles();
                InitializeAccount();
            }

             
        }

        private static void InitializeAccount()
        {
            var data = new ManagerFactory().GetAccountManager().GetAll(1);

            if (data.Count == 0)
            {
                //Create default Account here
                using (var adminmanager = new ManagerFactory().GetAdminManager())
                {
                    adminmanager.Session.BeginTransaction();
                    Admin admin = new Admin();
                    admin.Firstname = "Winston";
                    admin.Lastname = "Gubantes";

                    Account acc = new Account();
                    acc.Id = "admin";
                    acc.Password = "secret";
                    acc.Admin = admin;

                    admin.Accounts.Add(acc);
                    adminmanager.Save(admin);
                    adminmanager.Session.CommitTransaction();
                } 
            }
        }


        /// <summary>
        /// This will create a Database Schema based on the config(app/web) file on
        /// hibernate-configuration element(make sure database is created, except tables)
        /// </summary>
        private static void CreateDatabaseSchemaFromMappingFiles()
        {
            NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();
            cfg.Configure();

            new NHibernate.Tool.hbm2ddl.SchemaUpdate(cfg).Execute(false, true);

            //NHibernate.Tool.hbm2ddl.SchemaExport schema = new NHibernate.Tool.hbm2ddl.SchemaExport(cfg);
            //schema.Create(false, true);
        }
    }
}
