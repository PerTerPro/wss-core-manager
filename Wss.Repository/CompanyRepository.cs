﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Wss.Entities;

namespace Wss.Repository
{
    public class CompanyRepository:ICompanyRepository
    {
        private IDbConnection _connection;

        public CompanyRepository()
        {
            _connection=new SqlConnection("");
        }

        public void Insert(Entities.Company entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Entities.Company GetById(long id)
        {
            string query =
                string.Format(@"Select cp.Id, cp.Website, cp.Domain
From Company cp
where cp.ID = {0}", id);
            return _connection.Query<Company>(query).First();
        }

        public IEnumerable<Company> GetAllCompanyIdsCrawler()
        {
            string query = 
@"select c.Id
from company c
where c.Status=1
and c.DataFeedType=0";
            return _connection.Query<Company>(query);
        }
    }
}
