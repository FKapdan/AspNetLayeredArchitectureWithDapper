using AspNetLayeredArchitectureWithDapper.Business.Interfaces;
using AspNetLayeredArchitectureWithDapper.Entities;
using AspNetLayeredArchitectureWithDapper.Repository.Interfaces;
using System.Collections.Generic;

namespace AspNetLayeredArchitectureWithDapper.Business
{
    public class DatabaseTableModelManager : IRepositoryManager<DatabaseTableModel>
    {
        IRepository<DatabaseTableModel> _databaseTableModel;
        public DatabaseTableModelManager(IRepository<DatabaseTableModel> databaseTableModel)
        {
            _databaseTableModel = databaseTableModel;
        }
        public bool Add(DatabaseTableModel Data)
        {
            return _databaseTableModel.Add(Data);
        }
        public bool AddMultiple(IEnumerable<DatabaseTableModel> Datas)
        {
            return _databaseTableModel.AddMultiple(Datas);
        }
        public bool Delete(int Id)
        {
            return _databaseTableModel.Delete(Id);
        }

        public IEnumerable<DatabaseTableModel> Get()
        {
            return _databaseTableModel.Get();
        }

        public DatabaseTableModel Get(int Id)
        {
            return _databaseTableModel.Get(Id);
        }

        public bool Update(DatabaseTableModel Data)
        {
            return _databaseTableModel.Update(Data);
        }
    }
}
