using Core.Entities.Abstracts;
using Core.Entities.Results;
using Entities.Repository;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace Repository
{
    public class DatabaseTableModelRepository : RepositoryBase<DatabaseTableModelDto>
    {
        private readonly MySqlConnection _dbConnection;
        public DatabaseTableModelRepository(MySqlConnection DbConnection) { _dbConnection = DbConnection; }

       public override IResultBase Add(DatabaseTableModelDto LogData)
        {
            using (_dbConnection)
            {
                var query = "INSERT INTO [dbo].[DatabaseTable] ([PID],[TELNO]) VALUES( @PID, @TELNO)";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PID", LogData.Pid);
                parameters.Add("@TELNO", LogData.TelNo);
                _dbConnection.Open();
                SqlMapper.Execute(_dbConnection, query, param: parameters, commandType: CommandType.Text);
            }

            return new ResultBase(true);
        }
       public override IResultBase AddMultiple(IEnumerable<DatabaseTableModelDto> LogData)
        {
            object myObj1 = LogData.Select(x => new { PID = x.Pid, TELNO = x.TelNo }).ToArray();

            using (_dbConnection)
            {
                var query = "INSERT INTO [dbo].[DatabaseTable] ([PID],[TELNO]) VALUES( @PID, @TELNO)";

                _dbConnection.Open();
                SqlMapper.Execute(_dbConnection, query, param: myObj1, commandType: CommandType.Text);
            }

            return new ResultBase(true);
        }

       public override IResultBase Delete(int Id)
        {
            using (_dbConnection)
            {
                var query = "DELETE FROM [dbo].[DatabaseTable] WHERE [Id] = @Id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                _dbConnection.Open();
                SqlMapper.Execute(_dbConnection, query, param: parameters, commandType: CommandType.Text);
            }
            return new ResultBase(true);
        }

       public override IDataResultBase<IEnumerable<DatabaseTableModelDto>> GetList()
        {
            using (_dbConnection)
            {
                var query = "SELECT * FROM [dbo].[DatabaseTable]";
                _dbConnection.Open();
                var data = SqlMapper.Query<DatabaseTableModelDto>(_dbConnection, query, commandType: CommandType.Text).ToList();

                return new DataResultBase<IEnumerable<DatabaseTableModelDto>>(data,true);
            }
        }

       public override IDataResultBase<DatabaseTableModelDto> Get(int Id)
        {
            using (_dbConnection)
            {
                var query = "SELECT * FROM [dbo].[DatabaseTable] WHERE [Id]=@Id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                _dbConnection.Open();
                var data = SqlMapper.Query<DatabaseTableModelDto>(_dbConnection, query, parameters, commandType: CommandType.Text).FirstOrDefault();
                return new DataResultBase<DatabaseTableModelDto>(data,true);
            }
        }

       public override IResultBase Update(DatabaseTableModelDto LogData)
        {
            using (_dbConnection)
            {
                var query = "UPDATE [dbo].[DatabaseTable] SET [PID]=@PID,[TELNO]=@TELNO WHERE [Id]=@Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", LogData.Id);
                parameters.Add("@PID", LogData.Pid);
                parameters.Add("@TELNO", LogData.TelNo);
                _dbConnection.Open();
                SqlMapper.Execute(_dbConnection, query, param: parameters, commandType: CommandType.Text);
                return new ResultBase(true);
            }
        }

       public (List<DatabaseTableModelDto> databaseTable, List<DatabaseTableModelDto> databaseTable2) GelMultipleDataResult()
        {
            using (var multi = _dbConnection.QueryMultiple("SELECT * FROM DatabaseTable; SELECT * FROM DatabaseTable2"))
            {
                var databaseTable = multi.Read<DatabaseTableModelDto>().ToList();
                var databaseTable2 = multi.Read<DatabaseTableModelDto>().ToList();
                return (databaseTable, databaseTable2);
            }
        }

    }
}
