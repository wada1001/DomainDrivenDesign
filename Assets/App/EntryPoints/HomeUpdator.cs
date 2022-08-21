using System.Collections;
using System.Collections.Generic;
using App.OutPuts;
using UnityEngine;
using VContainer.Unity;
using UniRx;

namespace App.EntryPoints
{
    public class HomeUpdator : IFixedTickable, IInitializable
    {
		readonly StateMachine stateMachine;
		readonly IIncrimentOutPut incOutPut;
		readonly INavigatorOutPut naviOutPut;
		readonly IStatusUsecase usecase;

		int frames;

		public HomeUpdator(
			StateMachine stateMachine,
			IIncrimentOutPut incOutPut,
			INavigatorOutPut naviOutPut,
			IStatusUsecase usecase)
		{
			this.stateMachine = stateMachine;
			this.incOutPut = incOutPut;
			this.naviOutPut = naviOutPut;
			this.usecase = usecase;
		}

		public void FixedTick()
		{
			frames++;
			
			if (frames % 3 == 0) incOutPut.SetCurrentCoin(usecase.GetTotalCoin());
		}

		public void Initialize()
		{
			incOutPut.Initialize();
			naviOutPut.Initialize();

			naviOutPut.GetClickerObservable().Subscribe(_ => stateMachine.Transition("clicker"));
			naviOutPut.GetItemObservable().Subscribe(_ => stateMachine.Transition("item"));
		}
    }
}
