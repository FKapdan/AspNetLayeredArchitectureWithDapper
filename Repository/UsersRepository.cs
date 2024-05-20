using AspNetLayeredArchitectureWithDapper.Core.Abstracts;
using AspNetLayeredArchitectureWithDapper.Core.Results;
using AspNetLayeredArchitectureWithDapper.Entities.Repository;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace AspNetLayeredArchitectureWithDapper.Repository
{
    public class UsersRepository : RepositoryBase<UsersDto>
    {
        private readonly MySqlConnection _dbConnection;
        public UsersRepository(MySqlConnection DbConnection) { _dbConnection = DbConnection; }

        public override IResultBase Add(UsersDto LogData)
        {
            using (_dbConnection)
            {
                var query = "INSERT INTO Users ( NAME, SURNAME, USERNAME, PASSWORD, ACTIVE ) VALUES( @NAME, @SURNAME, @USERNAME, @PASSWORD, @ACTIVE )";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@NAME", LogData.Name);
                parameters.Add("@SURNAME", LogData.Surname);
                parameters.Add("@USERNAME", LogData.UserName);
                parameters.Add("@PASSWORD", LogData.Password);
                parameters.Add("@ACTIVE", LogData.Active);
                _dbConnection.Open();
                SqlMapper.Execute(_dbConnection, query, param: parameters, commandType: CommandType.Text);
            }

            return new ResultBase(true);
        }
        public override IResultBase AddMultiple(IEnumerable<UsersDto> LogData)
        {
            using (_dbConnection)
            {
                var query = "INSERT INTO Users ( NAME, SURNAME, USERNAME, PASSWORD, ACTIVE ) VALUES( @NAME, @SURNAME, @USERNAME, @PASSWORD, @ACTIVE )";

                _dbConnection.Open();
                SqlMapper.Execute(_dbConnection, query, param: LogData, commandType: CommandType.Text);
            }

            return new ResultBase(true);
        }

        public override IResultBase Delete(int Id)
        {
            using (_dbConnection)
            {
                var query = "DELETE FROM Users WHERE ID = @ID";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", Id);
                _dbConnection.Open();
                SqlMapper.Execute(_dbConnection, query, param: parameters, commandType: CommandType.Text);
            }
            return new ResultBase(true);
        }

        public override IDataResultBase<IEnumerable<UsersDto>> GetList()
        {
            using (_dbConnection)
            {
                var query = "SELECT ID, NAME,SURNAME, USERNAME, PASSWORD, ACTIVE FROM Users";
                _dbConnection.Open();
                var data = SqlMapper.Query<UsersDto>(_dbConnection, query, commandType: CommandType.Text).ToList();

                return new DataResultBase<IEnumerable<UsersDto>>(data, true);
            }
        }

        public override IDataResultBase<UsersDto> Get(int Id)
        {
            using (_dbConnection)
            {
                var query = "SELECT * FROM Users WHERE ID = @ID";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                _dbConnection.Open();
                var data = SqlMapper.Query<UsersDto>(_dbConnection, query, parameters, commandType: CommandType.Text).FirstOrDefault();
                return new DataResultBase<UsersDto>(data, true);
            }
        }

        public override IResultBase Update(UsersDto LogData)
        {
            using (_dbConnection)
            {
                var query = "UPDATE Users SET NAME = @NAME, SURNAME = @SURNAME, USERNAME = @USERNAME, PASSWORD = @PASSWORD, ACTIVE= @ACTIVE WHERE ID = @ID";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", LogData.Id);
                parameters.Add("@NAME", LogData.Name);
                parameters.Add("@SURNAME", LogData.Surname);
                parameters.Add("@USERNAME", LogData.UserName);
                parameters.Add("@PASSWORD", LogData.Password);
                parameters.Add("@ACTIVE", LogData.Active);
                _dbConnection.Open();
                SqlMapper.Execute(_dbConnection, query, param: parameters, commandType: CommandType.Text);
                return new ResultBase(true);
            }
        }

        public (List<UsersDto> databaseTable, List<UsersDto> databaseTable2) GelMultipleDataResult()
        {
            using (var multi = _dbConnection.QueryMultiple("SELECT * FROM Users; SELECT * FROM USERS"))
            {
                var databaseTable = multi.Read<UsersDto>().ToList();
                var databaseTable2 = multi.Read<UsersDto>().ToList();
                return (databaseTable, databaseTable2);
            }
        }

        public override IDataResultBase<UsersDto> Get(UsersDto entity)
        {
            using (_dbConnection)
            {
                var query = "SELECT * FROM Users WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD AND ACTIVE = @ACTIVE";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", entity.Id);
                parameters.Add("@USERNAME", entity.UserName);
                parameters.Add("@PASSWORD", entity.Password);
                parameters.Add("@ACTIVE", entity.Active);
                _dbConnection.Open();
                var data = SqlMapper.Query<UsersDto>(_dbConnection, query, parameters, commandType: CommandType.Text).FirstOrDefault();
                return new DataResultBase<UsersDto>(data, true);
            }
        }
    }
}
