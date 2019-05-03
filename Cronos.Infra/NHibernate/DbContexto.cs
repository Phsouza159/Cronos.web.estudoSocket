using Cronos.Domain.Config;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cronos.Infra.NHibernate
{
    public class DbContexto 
    {
        private static string ConnectionString
        {   get {
                return Config.Get().ConnectString.Value;
            }
            set { }
        }
        private static ISessionFactory session;

        public static ISessionFactory CriarSession()
        {
            if (session != null)
                return session;

            IPersistenceConfigurer ConfigDB = MySQLConfiguration.Standard.ConnectionString(ConnectionString);

            var configMap = Fluently.Configure()
                .Database(ConfigDB)
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Cronos.Infra.NHibernate.Map.AutentificacaoMap>());

            session = configMap.BuildSessionFactory();

            return session;
        }

        public static ISession AbrirSession()
        {
            return CriarSession().OpenSession();
        }

        public static void FecharSession()
        {
            session.Close();
        }
    }
}
