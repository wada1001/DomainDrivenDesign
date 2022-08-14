using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using App.OutPuts;

namespace Views.Components
{
    public class ClickerView : MonoBehaviour, IClickerOutPut
    {
        [SerializeField] Button clicker;
        [SerializeField] TextMeshProUGUI coin;
        [SerializeField] Button toItem;

        public void Terminate()
        {
            clicker.onClick.RemoveAllListeners();
            this.gameObject.SetActive(false);
        }

        public IObservable<Unit> GetClickerObservable() => clicker.OnClickAsObservable();
        public IObservable<Unit> GetToItemObservable() => toItem.OnClickAsObservable();

        public void Initialize()
        {
            this.gameObject.SetActive(true);
        }

        public void SetCurrentCoin(int value) => coin.text = value.ToString() + " coins";
    }
}
