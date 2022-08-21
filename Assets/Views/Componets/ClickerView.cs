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
        //[SerializeField] TextMeshProUGUI coin;

        public void Terminate()
        {
            clicker.onClick.RemoveAllListeners();
            this.gameObject.SetActive(false);
        }

        public IObservable<Unit> GetClickerObservable() => clicker.OnClickAsObservable();

        public void Initialize()
        {
            this.gameObject.SetActive(true);
        }
    }
}
