using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using App.OutPuts;
using TMPro;
using UnityEngine;

namespace Views.Components
{
    public class ClickerHeaderView : MonoBehaviour, IIncrimentOutPut
	{
		[SerializeField] TextMeshProUGUI coin;

		public void Initialize()
		{
			this.gameObject.SetActive(true);
		}

		public void SetCurrentCoin(BigInteger value)
		{
			this.coin.text = value.ToString() + " Coins";
		}

		public void Terminate()
		{
			this.gameObject.SetActive(false);
		}
    }
}
