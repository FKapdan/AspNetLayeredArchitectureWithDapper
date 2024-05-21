using Core.Abstracts;
using Core.Entities.Abstracts;
using Core.Entities.Results;
using Dapper;
using Entities.Repository;
using MySql.Data.MySqlClient;
using System.Data;

namespace Repository
{
    public class DatabaseTableModelRepository : LayerAbstractBase<DatabaseTableModelDto>
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
        public override async Task<IResultBase> AddAsync(DatabaseTableModelDto LogData)
        {
            using (_dbConnection)
            {
                var query = "INSERT INTO [dbo].[DatabaseTable] ([PID],[TELNO]) VALUES( @PID, @TELNO)";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PID", LogData.Pid);
                parameters.Add("@TELNO", LogData.TelNo);
                await SqlMapper.ExecuteAsync(_dbConnection, query, param: parameters, commandType: CommandType.Text);
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
        public override async Task<IResultBase> AddMultipleAsync(IEnumerable<DatabaseTableModelDto> LogData)
        {
            object myObj1 = LogData.Select(x => new { PID = x.Pid, TELNO = x.TelNo }).ToArray();

            using (_dbConnection)
            {
                var query = "INSERT INTO [dbo].[DatabaseTable] ([PID],[TELNO]) VALUES( @PID, @TELNO)";

                await SqlMapper.ExecuteAsync(_dbConnection, query, param: myObj1, commandType: CommandType.Text);
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
        public override async Task<IResultBase> DeleteAsync(int Id)
        {
            using (_dbConnection)
            {
                var query = "DELETE FROM [dbo].[DatabaseTable] WHERE [Id] = @Id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                await SqlMapper.ExecuteAsync(_dbConnection, query, param: parameters, commandType: CommandType.Text);
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

                return new DataResultBase<IEnumerable<DatabaseTableModelDto>>(data, true);
            }
        }
        public override async Task<IDataResultBase<IEnumerable<DatabaseTableModelDto>>> GetListAsync()
        {
            using (_dbConnection)
            {
                var query = "SELECT * FROM [dbo].[DatabaseTable]";
                var data = await SqlMapper.QueryAsync<DatabaseTableModelDto>(_dbConnection, query, commandType: CommandType.Text);

                return new DataResultBase<IEnumerable<DatabaseTableModelDto>>(data.ToList(), true);
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
                return new DataResultBase<DatabaseTableModelDto>(data, true);
            }
        }
        public override async Task<IDataResultBase<DatabaseTableModelDto>> GetAsync(int Id)
        {
            using (_dbConnection)
            {
                var query = "SELECT * FROM [dbo].[DatabaseTable] WHERE [Id]=@Id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                var data = await SqlMapper.QueryAsync<DatabaseTableModelDto>(_dbConnection, query, parameters, commandType: CommandType.Text);
                return new DataResultBase<DatabaseTableModelDto>(data.FirstOrDefault(), true);
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
        public override async Task<IResultBase> UpdateAsync(DatabaseTableModelDto LogData)
        {
            using (_dbConnection)
            {
                var query = "UPDATE [dbo].[DatabaseTable] SET [PID]=@PID,[TELNO]=@TELNO WHERE [Id]=@Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", LogData.Id);
                parameters.Add("@PID", LogData.Pid);
                parameters.Add("@TELNO", LogData.TelNo);
                await SqlMapper.ExecuteAsync(_dbConnection, query, param: parameters, commandType: CommandType.Text);
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
        public async Task<(List<DatabaseTableModelDto> databaseTable, List<DatabaseTableModelDto> databaseTable2)> GelMultipleDataResultAsync()
        {
            using (var multi = await _dbConnection.QueryMultipleAsync("SELECT * FROM DatabaseTable; SELECT * FROM DatabaseTable2"))
            {
                var databaseTable = multi.Read<DatabaseTableModelDto>().ToList();
                var databaseTable2 = multi.Read<DatabaseTableModelDto>().ToList();
                return (databaseTable, databaseTable2);
            }
        }
    }
}
