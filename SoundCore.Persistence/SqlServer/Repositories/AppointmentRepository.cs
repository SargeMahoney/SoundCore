using Dapper;
using Microsoft.Extensions.Logging;
using SoundCore.Application.Configurations.DatabaseSettings;
using SoundCore.Application.Contracts.Persistence;
using SoundCore.Application.Models.Results;
using SoundCore.Domain.Entities;
using SoundCore.Persistence.SqlServer._base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoundCore.Persistence.SqlServer.Repositories
{
    public class AppointmentRepository : SqlDbBaseRepository, IAppointmentRepository
    {
        public AppointmentRepository(ILogger<SqlDbBaseRepository> logger, IDatabaseSetting dbConfig) : base(logger, dbConfig)
        {
        }

        public async Task<Appointment> AddAsync(Appointment entity)
        {
            using (var conn = Connection)
            {
                try
                {
                    var sQuery = @"INSERT INTO  d_Appointments (RoomId, Owner, Start, [End])" +
                                   " OUTPUT INSERTED.[Id] VALUES  " +
                                   " (@RoomId, @Owner, @Start, @End )";

                    var idResult = await conn.QuerySingleAsync<Guid>(sQuery,
                         new
                         {
                             RoomId = entity.RoomId,
                             Owner = entity.Owner,
                             Start = entity.Start,
                             End = entity.End
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

        public Task<BaseResult> DeleteAsync(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Appointment>> ListAllAsync()
        {      


            using (var conn = Connection)
            {
                try
                {
                    var sQuery = "SELECT * FROM d_Appointments";

                    return await conn.QueryAsync<Appointment>(sQuery);

                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex.ToString());
                    throw;
                }
            }
        }

        public async Task<BaseResult> UpdateAsync(Appointment entity)
        {
            using (var conn = Connection)
            {
                try
                {
                    var sQuery = @"UPDATE  d_Appointments SET RoomId = @RoomId, Owner = @Owner, Start = @Start, [End] = @End "  +
                                   "WHERE Id = @Id ";
                 

                    var idResult = await conn.ExecuteAsync(sQuery,
                         new
                         {
                             RoomId = entity.RoomId,
                             Owner = entity.Owner,
                             Start = entity.Start,
                             End = entity.End,
                             Id =entity.Id
                         });
                   
                    return new BaseResult(message: string.Empty,success: true);
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
