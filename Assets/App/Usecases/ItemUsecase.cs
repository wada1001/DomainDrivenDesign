using System.Collections;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Repositories;
using UnityEngine;

namespace App.Usecases
{
	public class ItemUsecase : IItemUsecase
	{
		readonly IGameSession gameSession;
		readonly IItemRepository itemRepository;

		public ItemUsecase(IGameSession gameSession, IItemRepository itemRepository)
		{
			this.gameSession = gameSession;
			this.itemRepository = itemRepository;
		}

		// TODO 今の仕様ではまとめ買いができない
		public bool Buy(int itemId)
		{
			var item = itemRepository.FindItem(itemId);
			if (item == null) return false;

			var coin = gameSession.GetCurrentCoin();
			if (coin < item.CalcSalesPrice()) return false;

			ApplyItemEffect(item);

			item.Amount++;
			itemRepository.UpsertItem(item);
			return true;
		}

		public List<Item> GetItems()
		{
			return itemRepository.GetItems();
		}

		void ApplyItemEffect(Item item)
		{
			var status = gameSession.GetGameStatus();

			if (item.ItemType.IsTapUp())
			{
				status.TapPerCoin += item.EffectValue;
			} else if (item.ItemType.IsAutoTap())
			{
				status.SecondPerCoin += item.EffectValue;
			}

			status.Coin -= item.CalcSalesPrice();
			gameSession.SetGameStatus(status);
		}
	}
}