using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace App.EntryPoints
{
	/// <summary>
	/// 時間経過による更新行為を全て担うべき
	/// </summary>
	public class GameUpdator : IFixedTickable, IInitializable
	{
		readonly IStatusUsecase usecase;

		int frames;

		public GameUpdator(IStatusUsecase usecase)
		{
			this.usecase = usecase;
		}

		public void FixedTick()
		{
			frames++;
			if (frames % 50 == 0) usecase.UpdateSingle();
		}

		public void Initialize()
		{
			// データを読み込んでメモリに載せるのはここで

		}
	}
}
