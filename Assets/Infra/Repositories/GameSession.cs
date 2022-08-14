using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Domain.Repositories;
using Domain.Entities;

namespace Infra.Repositories
{
	public class GameSession : IGameSession
	{
		// ゲーム中に高速に処理されるべきことは基本的にIOしない
		// 保存->メモリに載せるを繰り返して、ゲーム中は常にメモリの方を読む
		// 中断を食らった時に復帰できれば良い
		GameStatus gameStatus = new GameStatus();

		public void AddCoin(int coin)
		{
			gameStatus.Coin += coin;
		}

		public int GetCurrentCoin()
		{
			return gameStatus.Coin;
		}

		public GameStatus GetGameStatus()
		{
			return gameStatus;
		}

		/// <summary>
		/// TODO 必ずゲーム起動時に計算後の物をセットする
		/// </summary>
		/// <param name="gameStatus"></param>
		public void SetGameStatus(GameStatus gameStatus)
		{
			this.gameStatus = gameStatus;
		}
	}
}
