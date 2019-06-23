using System.Collections.Generic;
using System.Threading.Tasks;
using Loetopia.DataAccess;

namespace Loetopia.Repository
{
    public interface IAttributes
    {
        Task<bool> AddAttribute(Attribute attribute);
        List<Attribute> GetAttributes(int? id);
    }
}