﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Entity;

namespace Models
{
    class MySqlConfiguration : DbConfiguration
    {
        public MySqlConfiguration()
        {
            SetHistoryContext(
            "MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
        }
    }
}
