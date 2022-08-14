using System.Collections;
using System.Collections.Generic;
using Domain.ValueObjects;
using UnityEngine;

namespace Domain.Entities
{
    public class Item
    {
        public int ItemId;
        public string Name;
        public string Description;
        public int PriceRate;
        public ItemType ItemType;
        public int EffectValue;
        public int Amount;

        // 購入数で増える
        public int CalcSalesPrice()
		{
            return (Amount + 1) * PriceRate;
		}
    }
}
