using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testlet.DAL
{
    public interface ITestLetItemRepository
    {
        List<Item> GetTestLetItems();
        List<Item> GetRandomizeItems();
    }
}
