using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testlet.DAL
{
    public class Item
    {
        public string ItemId { get; set; }
        public string ItemDescription { get; set; }
        public string ItemAnswer { get; set; }
        public ItemType ItemType { get; set; }

        public List<ItemOption> Options { get; set; }

    }


    public class ItemOption
    {
        public string Option { get; set; }
    }



    public enum ItemType
    {
        Pretest = 0,
        Operational = 1
    }
}
