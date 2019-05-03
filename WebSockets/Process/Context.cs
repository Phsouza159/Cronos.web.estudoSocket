using Cronos.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebSockets.ws.Process
{
    public static class Context
    {
        public static DbContexto Instancia(string conect) 
        {
            DbContextOptionsBuilder<DbContexto> options = new DbContextOptionsBuilder<DbContexto>();
            string connectString = "Data Source=127.0.0.1;Initial Catalog=cronos.db;User ID=root;Password=";
            options.UseMySql(connectString);

            return new DbContexto(options.Options);
        }

    }
}
