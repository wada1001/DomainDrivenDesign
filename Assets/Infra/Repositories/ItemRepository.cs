using System.Collections;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Repositories;
using System.Linq;
using Domain.ValueObjects;

namespace Infra.Repositories
{
	public class ItemRepository : IItemRepository
	{
		// TODO stub
		Dictionary<int, int> havingItemDict = new Dictionary<int, int>();

		public List<Item> GetItems()
		{
			var masters = ItemMaster.GetItemMasters();

			var items = new List<Item>();

			masters.ForEach(x => items.Add(new Item()
			{
				ItemId = x.ItemId,
				Name = x.Name,
				Description = x.Description,
				PriceRate = x.PriceRate,
				ItemType = new ItemType(x.ItemType),
				EffectValue = x.EffectValue,
				Amount = havingItemDict.ContainsKey(x.ItemId) ?  havingItemDict[x.ItemId] : 0
			}));

			return items;
		}


		public Item FindItem(int itemId)
		{
			var master = ItemMaster.Find(itemId);

			if (master == null) return null;

			return new Item()
			{
				ItemId = master.ItemId,
				Name = master.Name,
				Description = master.Description,
				PriceRate = master.PriceRate,
				ItemType = new ItemType(master.ItemType),
				EffectValue = master.EffectValue,
				Amount = havingItemDict.ContainsKey(master.ItemId) ? havingItemDict[master.ItemId] : 0
			};
		}

		public void UpsertItem(Item item)
		{
			if (havingItemDict.ContainsKey(item.ItemId))
			{
				havingItemDict[item.ItemId] = item.Amount;
			}
			else {
				havingItemDict.Add(item.ItemId, item.Amount);
			}
		}
	}

	public class ItemMaster
	{
		public int ItemId;
		public string Name;
		public string Description;

		public int PriceRate;
		public int ItemType;
		public int EffectValue;

		/// <summary>
		/// TODO Stub
		/// </summary>
		/// <returns></returns>
		public static List<ItemMaster> GetItemMasters()
		{
			return new List<ItemMaster>()
			{
				new ItemMaster()
				{
					ItemId = 1,
					Name = "Item01",
					Description = "first item",
					PriceRate = 10,
					ItemType = Domain.ValueObjects.ItemType.TAP_UP,
					EffectValue = 1
				},
				new ItemMaster()
				{
					ItemId = 2,
					Name = "Item02",
					Description = "second item",
					PriceRate = 100,
					ItemType = Domain.ValueObjects.ItemType.TAP_UP,
					EffectValue = 5
				},
				new ItemMaster()
				{
					ItemId = 3,
					Name = "Item03",
					Description = "third item",
					PriceRate = 50,
					ItemType = Domain.ValueObjects.ItemType.AUTO_TAP,
					EffectValue = 1
				},
			};
		}

		public static ItemMaster Find(int itemId)
		{
			switch(itemId)
			{
				case 1:
					return new ItemMaster()
					{
						ItemId = 1,
						Name = "Item01",
						Description = "first item",
						PriceRate = 10,
						ItemType = Domain.ValueObjects.ItemType.TAP_UP,
						EffectValue = 1
					};
				case 2:
					return new ItemMaster()
					{
						ItemId = 2,
						Name = "Item02",
						Description = "second item",
						PriceRate = 100,
						ItemType = Domain.ValueObjects.ItemType.TAP_UP,
						EffectValue = 5
					};
				case 3:
					return new ItemMaster()
					{
						ItemId = 3,
						Name = "Item03",
						Description = "third item",
						PriceRate = 50,
						ItemType = Domain.ValueObjects.ItemType.AUTO_TAP,
						EffectValue = 1
					};
				default:
					return null;
			}
		}
	}
}
