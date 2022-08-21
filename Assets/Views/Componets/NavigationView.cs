using System;
using System.Collections;
using System.Collections.Generic;
using App.OutPuts;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Components
{
    public class NavigationView : MonoBehaviour, INavigatorOutPut
    {
        [SerializeField] Button clicker;
        [SerializeField] Button item;
        [SerializeField] Button empty_1;
        [SerializeField] Button empty_2;

        public IObservable<Unit> GetClickerObservable() => clicker.OnClickAsObservable();
        public IObservable<Unit> GetItemObservable() => item.OnClickAsObservable();

		public void Initialize()
		{
			this.gameObject.SetActive(true);
		}

		public void Terminate()
		{
			this.gameObject.SetActive(false);
		}
		//public IObservable<Unit> GetClickerObservable() => clicker.OnClickAsObservable();
	}
}
