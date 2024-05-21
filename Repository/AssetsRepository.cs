using Core.Entities.Abstracts;
using Core.Entities.Results;
using Entities.Repository;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Repository
{
    public class AssetsRepository : RepositoryBase<AssetsDto>
    {
        private readonly MySqlConnection _dbConnection;
        public AssetsRepository(MySqlConnection DbConnection) { _dbConnection = DbConnection; }

        public override IResultBase Add(AssetsDto LogData)
        {
            using (_dbConnection)
            {
                var query = "INSERT INTO Assets ( NAME, BRAND, COUNT, ACTIVE ) VALUES( @NAME, @BRAND, @COUNT, @ACTIVE )";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@NAME", LogData.Name);
                parameters.Add("@BRAND", LogData.Brand);
                parameters.Add("@COUNT", LogData.Count);
                parameters.Add("@ACTIVE", LogData.Active);
                _dbConnection.Open();
                SqlMapper.Execute(_dbConnection, query, param: parameters, commandType: CommandType.Text);
            }

            return new ResultBase(true);
        }
        public override IResultBase AddMultiple(IEnumerable<AssetsDto> LogData)
        {
            using (_dbConnection)
            {
                var query = "INSERT INTO Assets ( NAME, BRAND, COUNT, ACTIVE) VALUES(@NAME, @BRAND, @COUNT, @ACTIVE )";

                _dbConnection.Open();
                SqlMapper.Execute(_dbConnection, query, param: LogData, commandType: CommandType.Text);
            }

            return new ResultBase(true);
        }

        public override IResultBase Delete(int Id)
        {
            using (_dbConnection)
            {
                var query = "DELETE FROM Assets WHERE ID = @ID";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", Id);
                _dbConnection.Open();
                SqlMapper.Execute(_dbConnection, query, param: parameters, commandType: CommandType.Text);
            }
            return new ResultBase(true);
        }

        public override IDataResultBase<IEnumerable<AssetsDto>> GetList()
        {
            using (_dbConnection)
            {
                var query = "SELECT ID, NAME, BRAND, COUNT, ACTIVE FROM Assets";
                _dbConnection.Open();
                var data = SqlMapper.Query<AssetsDto>(_dbConnection, query, commandType: CommandType.Text).ToList();

                return new DataResultBase<IEnumerable<AssetsDto>>(data, true);
            }
        }

        public override IDataResultBase<AssetsDto> Get(int Id)
        {
            using (_dbConnection)
            {
                var query = "SELECT * FROM Assets WHERE ID = @ID";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                _dbConnection.Open();
                var data = SqlMapper.Query<AssetsDto>(_dbConnection, query, parameters, commandType: CommandType.Text).FirstOrDefault();
                return new DataResultBase<AssetsDto>(data, true);
            }
        }

        public override IResultBase Update(AssetsDto LogData)
        {
            using (_dbConnection)
            {
                var query = "UPDATE Assets SET NAME = @NAME, BRAND = @BRAND, COUNT = @COUNT, ACTIVE = @ACTIVE WHERE ID = @ID";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", LogData.Id);
                parameters.Add("@NAME", LogData.Name);
                parameters.Add("@BRAND", LogData.Brand);
                parameters.Add("@COUNT", LogData.Count);
                parameters.Add("@ACTIVE", LogData.Active);
                _dbConnection.Open();
                SqlMapper.Execute(_dbConnection, query, param: parameters, commandType: CommandType.Text);
                return new ResultBase(true);
            }
        }

        public (List<AssetsDto> databaseTable, List<AssetsDto> databaseTable2) GelMultipleDataResult()
        {
            using (var multi = _dbConnection.QueryMultiple("SELECT * FROM Assets; SELECT * FROM Assets"))
            {
                var databaseTable = multi.Read<AssetsDto>().ToList();
                var databaseTable2 = multi.Read<AssetsDto>().ToList();
                return (databaseTable, databaseTable2);
            }
        }

        public override IDataResultBase<AssetsDto> Get(AssetsDto entity)
        {
            using (_dbConnection)
            {
                var query = "SELECT * FROM Assets WHERE BRAND = @BRAND, COUNT = @COUNT, ACTIVE = @ACTIVE";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@NAME", entity.Name);
                parameters.Add("@BRAND", entity.Brand);
                parameters.Add("@COUNT", entity.Count);
                parameters.Add("@ACTIVE", entity.Active);
                _dbConnection.Open();
                var data = SqlMapper.Query<AssetsDto>(_dbConnection, query, parameters, commandType: CommandType.Text).FirstOrDefault();
                return new DataResultBase<AssetsDto>(data, true);
            }
        }
    }
}
