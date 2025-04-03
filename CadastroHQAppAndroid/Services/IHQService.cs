using CadastroHQAppAndroid.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroHQAppAndroid.Services
{
    public interface IHQService
    {
        Task InitializeAsync();
        Task<List<HQ>> GetHQS();
        Task<HQ> GetHQById(int hqId);
        Task<int> AddHQ(HQ hq);
        Task<int> UpdateHQ(HQ hq);
        Task<int> DeleteHQ(HQ hq);
    }
}
