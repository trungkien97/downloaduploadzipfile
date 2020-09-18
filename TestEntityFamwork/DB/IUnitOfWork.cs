using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestEntityFamwork.DB
{
    public interface IUnitOfWork
    {
        
        MySqlTransaction BeginTransaction();
        void Commit();
        //void Dispose();

        void RollBack();
    }
}
