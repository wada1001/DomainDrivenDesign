using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

namespace Views.Components
{
    public class ItemIcon : MonoBehaviour
    {
        [SerializeField] Button button;
        [SerializeField] TextMeshProUGUI itemName;
        [SerializeField] TextMeshProUGUI itemPrice;
        [SerializeField] TextMeshProUGUI itemAmount;
        public int ItemId;

        public void SetItemId(int itemId) => this.ItemId = itemId;
        public void SetName(string name) => itemName.text = name;
        public void SetAmount(int amount) => itemAmount.text = amount.ToString();

        public void Initialize(string name, int buyPrice, int amount)
		{
            button.onClick.RemoveAllListeners();
            itemName.text = name;
            itemPrice.text = "P:" + buyPrice.ToString();
            itemAmount.text = "A:" + amount.ToString();
		}

        public IObservable<Unit> GetOnClicObservable()
		{
            return button.onClick.AsObservable();
		}
    }
}
