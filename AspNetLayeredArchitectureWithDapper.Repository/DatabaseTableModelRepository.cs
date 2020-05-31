using Dapper;
using Microsoft.Extensions.Configuration;
using AspNetLayeredArchitectureWithDapper.Entities;
using AspNetLayeredArchitectureWithDapper.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AspNetLayeredArchitectureWithDapper.Repository
{
    public class DatabaseTableModelRepository : BaseRepository, IRepository<DatabaseTableModel>
    {
        public DatabaseTableModelRepository(IConfiguration configuration) : base(configuration) { }

        public bool Add(DatabaseTableModel LogData)
        {
            try
            {
                using (GetConnection)
                {
                    var query = "INSERT INTO [dbo].[DatabaseTable] ([PID],[TELNO]) VALUES( @PID, @TELNO)";

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@PID", LogData.Pid);
                    parameters.Add("@TELNO", LogData.TelNo);
                    GetConnection.Open();
                    SqlMapper.Execute(GetConnection, query, param: parameters, commandType: CommandType.Text);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddMultiple(IEnumerable<DatabaseTableModel> LogData)
        {
            try
            {
                object myObj1 = LogData.Select(x => new { PID = x.Pid, TELNO = x.TelNo }).ToArray();

                using (GetConnection)
                {
                    var query = "INSERT INTO [dbo].[DatabaseTable] ([PID],[TELNO]) VALUES( @PID, @TELNO)";

                    GetConnection.Open();
                    SqlMapper.Execute(GetConnection, query, param: myObj1, commandType: CommandType.Text);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                using (GetConnection)
                {
                    var query = "DELETE FROM [dbo].[DatabaseTable] WHERE [Id] = @Id";

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", Id);
                    GetConnection.Open();
                    SqlMapper.Execute(GetConnection, query, param: parameters, commandType: CommandType.Text);
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<DatabaseTableModel> Get()
        {
            try
            {
                using (GetConnection)
                {
                    var query = "SELECT * FROM [dbo].[DatabaseTable]";
                    GetConnection.Open();
                    IList<DatabaseTableModel> DatabaseTableModelList = SqlMapper.Query<DatabaseTableModel>(GetConnection, query, commandType: CommandType.Text).ToList();
                    return DatabaseTableModelList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DatabaseTableModel Get(int Id)
        {
            try
            {
                using (GetConnection)
                {
                    var query = "SELECT * FROM [dbo].[DatabaseTable] WHERE [Id]=@Id";

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", Id);
                    GetConnection.Open();
                    return SqlMapper.Query<DatabaseTableModel>(GetConnection, query, parameters, commandType: CommandType.Text).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(DatabaseTableModel LogData)
        {
            try
            {
                using (GetConnection)
                {
                    var query = "UPDATE [dbo].[DatabaseTable] SET [PID]=@PID,[TELNO]=@TELNO WHERE [Id]=@Id";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", LogData.Id);
                    parameters.Add("@PID", LogData.Pid);
                    parameters.Add("@TELNO", LogData.TelNo);
                    GetConnection.Open();
                    SqlMapper.Execute(GetConnection, query, param: parameters, commandType: CommandType.Text);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public (List<DatabaseTableModel> databaseTable, List<DatabaseTable2Model> databaseTable2) GelMultipleDataResult()
        {
            using (var multi = GetConnection.QueryMultiple("SELECT * FROM DatabaseTable; SELECT * FROM DatabaseTable2"))
            {
                var databaseTable = multi.Read<DatabaseTableModel>().ToList();
                var databaseTable2 = multi.Read<DatabaseTable2Model>().ToList();
                return (databaseTable, databaseTable2);
            }
        }

    }
}
