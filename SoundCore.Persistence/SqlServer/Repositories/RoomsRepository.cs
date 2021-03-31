using Dapper;
using Microsoft.Extensions.Logging;
using SoundCore.Application.Configurations.DatabaseSettings;
using SoundCore.Application.Contracts.Persistence;
using SoundCore.Application.Models.Results;
using SoundCore.Domain.Entities;
using SoundCore.Domain.Enum;
using SoundCore.Persistence.SqlServer._base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundCore.Persistence.SqlServer.Repositories
{
    public class RoomsRepository : SqlDbBaseRepository, IRoomsRepository
    {
        public RoomsRepository(ILogger<SqlDbBaseRepository> logger, IDatabaseSetting dbConfig) : base(logger, dbConfig)
        {
        }

        public async Task<Room> AddAsync(Room entity)
        {
            using (var conn = Connection)
            {
                try
                {
                    var sQuery = @"INSERT INTO  t_Rooms (Name, Description, State, CreationDate)" +
                                   "OUTPUT INSERTED.[Id] VALUES  " +
                                   "(@Name, @Description, @State, @CreationDate )";

                    var idResult = await conn.QuerySingleAsync<Guid>(sQuery,
                         new
                         {
                             Name = entity.Name,
                             Description = entity.Description,
                             State = entity.State,
                             CreationDate = DateTime.Now                         
                         });
                    entity.Id = idResult;                  
                    return entity;
                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex.ToString());
                    throw;
                }
            }
        }

        public async Task<BaseResult> DeleteAsync(Room entity)
        {
            using (var conn = Connection)
            {
                try
                {
                    var sQuery = @"DELETE FROM t_Rooms WHERE Id = @Id";

                    var idResult = await conn.QueryAsync(sQuery,
                         new
                         {
                             Id = entity.Id
                         });
                    return new BaseResult();
                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex.ToString());
                    throw;
                }
            }
        }

        public async Task<Room> GetByIdAsync(Guid id)
        {
            using (var conn = Connection)
            {
                try
                {
                    var sQuery = "SELECT * FROM t_Rooms WHERE Id = @Id";
                    var result = await conn.QueryAsync<Room>(sQuery, new
                    {
                        Id = id
                    });

                    return result.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex.ToString());
                    throw;
                }
            }
        }

        public async Task<IEnumerable<Room>> ListAllAsync()
        {        
            using (var conn = Connection)
            {
                try
                {
                    var sQuery = "SELECT * FROM t_Rooms";

                    return await conn.QueryAsync<Room>(sQuery);

                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex.ToString());
                    throw;
                }
            }
        }

        public async Task<BaseResult> UpdateAsync(Room entity)
        {
            using (var conn = Connection)
            {
                try
                {
                    var sQuery = @"UPDATE  t_Rooms SET Name = @Name, Description = @Description, State = @State
                                      WHERE Id = @IdDaAggiornare";

                    var idResult = await conn.QuerySingleAsync<Guid>(sQuery,
                         new
                         {
                             Name = entity.Name,
                             Description = entity.Description,
                             State = entity.State    ,
                             IdDaAggiornare = entity.Id
                         });
                    return new BaseResult();
                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex.ToString());
                    throw;
                }
            }
        }
    }
 }

