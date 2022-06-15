using AspNetLayeredArchitectureWithDapper.Entities.Interfaces;
using AspNetLayeredArchitectureWithDapper.Entities.Repository;
using AspNetLayeredArchitectureWithDapper.Entities.Results;
using AspNetLayeredArchitectureWithDapper.Repository.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AspNetLayeredArchitectureWithDapper.Repository
{
    public class DatabaseTableModelRepository : BaseRepository, IRepository<DatabaseTableModelDto>
    {
        public DatabaseTableModelRepository(IConfiguration configuration) : base(configuration) { }

        public IResultBase Add(DatabaseTableModelDto LogData)
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

            return new ResultBase(true, null, null);
        }
        public IResultBase AddMultiple(IEnumerable<DatabaseTableModelDto> LogData)
        {
            object myObj1 = LogData.Select(x => new { PID = x.Pid, TELNO = x.TelNo }).ToArray();

            using (GetConnection)
            {
                var query = "INSERT INTO [dbo].[DatabaseTable] ([PID],[TELNO]) VALUES( @PID, @TELNO)";

                GetConnection.Open();
                SqlMapper.Execute(GetConnection, query, param: myObj1, commandType: CommandType.Text);
            }

            return new ResultBase(true, null, null);
        }

        public IResultBase Delete(int Id)
        {
            using (GetConnection)
            {
                var query = "DELETE FROM [dbo].[DatabaseTable] WHERE [Id] = @Id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                GetConnection.Open();
                SqlMapper.Execute(GetConnection, query, param: parameters, commandType: CommandType.Text);
            }
            return new ResultBase(true, null, null);
        }

        public IDataResultBase<IEnumerable<DatabaseTableModelDto>> GetList()
        {
            using (GetConnection)
            {
                var query = "SELECT * FROM [dbo].[DatabaseTable]";
                GetConnection.Open();
                var data = SqlMapper.Query<DatabaseTableModelDto>(GetConnection, query, commandType: CommandType.Text).ToList();

                return new DataResultBase<IEnumerable<DatabaseTableModelDto>>(data);
            }
        }

        public IDataResultBase<DatabaseTableModelDto> Get(int Id)
        {
            using (GetConnection)
            {
                var query = "SELECT * FROM [dbo].[DatabaseTable] WHERE [Id]=@Id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                GetConnection.Open();
                var data = SqlMapper.Query<DatabaseTableModelDto>(GetConnection, query, parameters, commandType: CommandType.Text).FirstOrDefault();
                return new DataResultBase<DatabaseTableModelDto>(data);
            }
        }

        public IResultBase Update(DatabaseTableModelDto LogData)
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
                return new ResultBase(true, null, null);
            }
        }

        public (List<DatabaseTableModelDto> databaseTable, List<DatabaseTableModelDto> databaseTable2) GelMultipleDataResult()
        {
            using (var multi = GetConnection.QueryMultiple("SELECT * FROM DatabaseTable; SELECT * FROM DatabaseTable2"))
            {
                var databaseTable = multi.Read<DatabaseTableModelDto>().ToList();
                var databaseTable2 = multi.Read<DatabaseTableModelDto>().ToList();
                return (databaseTable, databaseTable2);
            }
        }

    }
}
