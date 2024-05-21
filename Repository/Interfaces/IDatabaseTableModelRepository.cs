using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IDatabaseTableModelRepository
    {
        bool AddSMS(DatabaseTableModel user);
        bool UpdateSMS(DatabaseTableModel user);
        bool DeleteSMS(int Id);
        IList<DatabaseTableModel> GetAllSMS();
        DatabaseTableModel GetSMSById(int Id);
    }
}
