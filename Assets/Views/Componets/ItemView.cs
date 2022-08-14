using System;
using System.Collections;
using System.Collections.Generic;
using App.OutPuts;
using Domain.Entities;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace Views.Components
{
    public class ItemView : MonoBehaviour, IItemOutPut
    {
        [SerializeField] GameObject itemIconPrefab;
        [SerializeField] Button back;
        [SerializeField] RectTransform itemParent;

        Subject<int> buySubject = new Subject<int>();

        List<ItemIcon> pool = new List<ItemIcon>();

		private void Awake()
		{
            for (int i = 0; i < 10; i++)
            {
                var tmp = GameObject.Instantiate(itemIconPrefab, itemParent);
                pool.Add(tmp.GetComponent<ItemIcon>());
                tmp.SetActive(false);
            }
        }

        public void Terminate()
        {
            back.onClick.RemoveAllListeners();
            buySubject.Dispose();
            this.gameObject.SetActive(false);
        }

        public void Initialize()
        {
            this.gameObject.SetActive(true);
        }

        public void SetItems(List<Item> items)
        {
            // TODO 必要な数だけ作るとかでいい
            pool.ForEach(x => {
                x.gameObject.SetActive(false);
            });

            for (int i = 0; i < items.Count; i++)
            {
                var tmp = pool[i];
                var tmpItem = items[i];
                var tmpPrice = tmpItem.CalcSalesPrice();
                tmp.gameObject.SetActive(true);
                tmp.Initialize(tmpItem.Name, tmpPrice, tmpItem.Amount);
                tmp.GetOnClicObservable()
                    .Subscribe(_ => buySubject.OnNext(tmpItem.ItemId));
            }
        }

		public IObservable<Unit> GetBackObservable()
		{
            return back.OnClickAsObservable();
        }

		public IObservable<int> GetBuyItemObservable()
		{
            buySubject = new Subject<int>();
            return buySubject.AsObservable();
        }
	}
}