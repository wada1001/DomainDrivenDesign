using System.Collections;
using System.Collections.Generic;
using App.EntryPoints;
using App.OutPuts;
using UnityEngine;
using UniRx;
using Domain.Repositories;

namespace App.Presenters
{
    public class ClickerPresenter : State
    {
        // TODO 階層が違う。UseCaseへ
        readonly IGameSession gameSession;
        readonly IClickerOutPut outPut;
        
        public ClickerPresenter(IClickerOutPut outPut, IGameSession gameSession)
        {
            this.outPut = outPut;
            this.gameSession = gameSession;
        }

        public override string GetKey() => "clicker";

        public override void OnEnter()
        {
            outPut.Initialize();
            outPut.GetClickerObservable().Subscribe(_ => OnClicker());
            outPut.GetToItemObservable().Subscribe(_ => Transition("item"));
        }

        public override void OnExit()
        {
            outPut.Terminate();
        }

        public override void OnUpdate()
        {
            // TODO 計算用のUsecaseを通す
            if (frames % 50 == 0) gameSession.AddCoin(gameSession.GetGameStatus().SecondPerCoin);

            if (frames % 3 == 0) outPut.SetCurrentCoin(gameSession.GetCurrentCoin());
        }

        public void OnClicker()
        {
            // TODO 計算用のUsecaseを通す
            gameSession.AddCoin(gameSession.GetGameStatus().TapPerCoin);
        }
    }
}
