using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testlet.DAL
{
    public class TestLetItemRepository : ITestLetItemRepository
    {
        private readonly List<Item> _testLetItems;
        private readonly Testlet _testLet;
        public TestLetItemRepository()
        {
            _testLetItems = new List<Item>
            {
                new Item() { ItemId = "Q1", ItemDescription="What is your favourite sport?",Options=new List<ItemOption> { new ItemOption() { Option="Cricket"},new ItemOption() { Option="Football"},new ItemOption() { Option="Tennis"},new ItemOption() { Option="Baseball"} }, ItemType = ItemType.Pretest },
                new Item() { ItemId = "Q2", ItemDescription="Who discovered America?",Options=new List<ItemOption> { new ItemOption() { Option="Columbus"},new ItemOption() { Option="Lincoln"},new ItemOption() { Option="Bush"},new ItemOption() { Option="Pretorius"} },ItemType = ItemType.Pretest },
                new Item() { ItemId = "Q3",ItemDescription="Which Country is biggest land wise?",Options=new List<ItemOption> { new ItemOption() { Option="USA"},new ItemOption() { Option="Russia"},new ItemOption() { Option="Canada"},new ItemOption() { Option="India"} }, ItemType = ItemType.Pretest },
                new Item() { ItemId = "Q4",ItemDescription="Which language spoken by most people",Options=new List<ItemOption> { new ItemOption() { Option="English"},new ItemOption() { Option="Spanish"},new ItemOption() { Option="Sanskrit"},new ItemOption() { Option="Tamil"} }, ItemType = ItemType.Pretest },
                new Item() { ItemId = "Q5", ItemDescription="Who won last footbal world cup?",Options=new List<ItemOption> { new ItemOption() { Option="Brazil"},new ItemOption() { Option="Germany"},new ItemOption() { Option="Netherlands"},new ItemOption() { Option="France"} },ItemType = ItemType.Operational },
                new Item() { ItemId = "Q6", ItemDescription="which one of the following among 7 wonders of the world?",Options=new List<ItemOption> { new ItemOption() { Option="Statue of Liberty"},new ItemOption() { Option="Tajmahal"},new ItemOption() { Option="Opera house"},new ItemOption() { Option="Pyramids"} },ItemType = ItemType.Operational },
                new Item() { ItemId = "Q7",ItemDescription="which one of the following Person is famous Tennis Player?",Options=new List<ItemOption> { new ItemOption() { Option="Federer"},new ItemOption() { Option="Tendulkar"},new ItemOption() { Option="Keenu reaves"},new ItemOption() { Option="Maradona"} }, ItemType = ItemType.Operational },
                new Item() { ItemId = "Q8",ItemDescription="Which country has most population?",Options=new List<ItemOption> { new ItemOption() { Option="India"},new ItemOption() { Option="USA"},new ItemOption() { Option="China"},new ItemOption() { Option="Brazil"} }, ItemType = ItemType.Operational },
                new Item() { ItemId = "Q9", ItemDescription="Which one of the following person is famous for Nonviolence?",Options=new List<ItemOption> { new ItemOption() { Option="Nelson Mandela"},new ItemOption() { Option="Martin Luther King"},new ItemOption() { Option="Gandhi"},new ItemOption() { Option="Bush"} },ItemType = ItemType.Operational },
                new Item() { ItemId = "Q10",ItemDescription="Which one of the following person is famous for Music?",Options=new List<ItemOption> { new ItemOption() { Option="Lohan"},new ItemOption() { Option="Michael Jockson"},new ItemOption() { Option="Tom Hanks"},new ItemOption() { Option="Trump"} }, ItemType = ItemType.Operational },

            };
            _testLet = new Testlet("Assessment1", _testLetItems);

        }

        public List<Item> GetTestLetItems()
        {
            return _testLet.Items;
        }

        public List<Item> GetRandomizeItems()
        {
            List<Item> randomizedList = new List<Item>();            
            var preTestItems = _testLet.Items.Where(a => a.ItemType == ItemType.Pretest).ToList().RandomizeItems();
            var operationalItems = _testLet.Items.Where(a => a.ItemType == ItemType.Operational).ToList();
            operationalItems.AddRange(preTestItems.Skip(2).Take(2));
            randomizedList.AddRange(preTestItems.Take(2));
            randomizedList.AddRange(operationalItems.RandomizeItems());
            return randomizedList;
        }
        //Refactored as extension method
        //public List<Item> ShuffleItems(List<Item> items)
        //{
        //    for(int i=items.Count-1;i>0;i--)
        //    {
        //        Swap(items, i, StaticRandom.Instance.Next(i + 1));
        //    }
        //    return items;
        //}

        //private static void Swap(List<Item> items, int i, int j)
        //{
        //    var temp = items[i];
        //    items[i] = items[j];
        //    items[j] = temp;
        //}


    }
}
