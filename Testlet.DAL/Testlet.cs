using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testlet.DAL
{
    public class Testlet
    {
        #region private fields
        private string TestletId;
        public List<Item> Items;
        #endregion

        #region constructor
        public Testlet(string testletId, List<Item> items)
        {
            TestletId = testletId;
            if (items.Count < 10 || items.Count > 10)
                throw new IndexOutOfRangeException();
            Items = items;
        }
        #endregion
    }
}
