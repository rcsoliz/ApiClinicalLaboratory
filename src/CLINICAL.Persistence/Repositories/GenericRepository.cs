﻿using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Persistence.Context;
using Dapper;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicactionDbContext _context;

        public GenericRepository(ApplicactionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string storedProcedure)
        {
            using var connection = _context.CreateConnection;
            return await connection
                .QueryAsync<T>(storedProcedure, 
                commandType: CommandType.StoredProcedure);
        }

        public async Task<T> GetByIdAsync(string storedProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;

            var objParam = new DynamicParameters(parameter);
            return await connection.QuerySingleOrDefaultAsync<T>(
                storedProcedure,
                param: objParam,
                commandType: CommandType.StoredProcedure);
        }
        public async Task<bool> ExecAsync(string storedProcedure, object parameters)
        {
            using var connection = _context.CreateConnection;

            var objParam = new DynamicParameters(parameters);
            var recordAffected = await connection
                .ExecuteAsync(storedProcedure,
                param: objParam, 
                commandType: CommandType.StoredProcedure);

            return recordAffected > 0;
            
        }
    }


}
