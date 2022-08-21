using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Domain.Repositories;
using UnityEngine;

namespace App.Usecases
{
	public class StatusUsecase : IStatusUsecase
	{
		readonly IGameSession gameSession;

		public StatusUsecase(IGameSession gameSession)
		{
			this.gameSession = gameSession;
		}

		public void AddSingle()
		{
			var coin = gameSession.GetGameStatus().TapPerCoin;
			gameSession.AddCoin(coin);
		}

		public void UpdateSingle()
		{
			var coin = gameSession.GetGameStatus().SecondPerCoin;
			gameSession.AddCoin(coin);
		}

		public BigInteger GetTotalCoin()
		{
			return gameSession.GetCurrentCoin();
		}
	}
}

