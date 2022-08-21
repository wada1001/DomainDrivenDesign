using System.Collections;
using System.Collections.Generic;
using App.EntryPoints;
using App.OutPuts;
using UnityEngine;
using UniRx;
using Domain.Repositories;
using App.Usecases;

namespace App.Presenters
{
    public class ClickerPresenter : State
    {
        // TODO 階層が違う。UseCaseへ
        readonly IClickerOutPut outPut;
        readonly IStatusUsecase usecase;

        public ClickerPresenter(IClickerOutPut outPut, IStatusUsecase usecase)
        {
            this.outPut = outPut;
            this.usecase = usecase;
        }

        public override string GetKey() => "clicker";

        public override void OnEnter()
        {
            outPut.Initialize();
            outPut.GetClickerObservable().Subscribe(_ => OnClicker());
        }

        public override void OnExit()
        {
            outPut.Terminate();
        }

        public override void OnUpdate()
        {
            // todo nothing to do ?
        }

        public void OnClicker()
        {
            usecase.AddSingle();
        }
    }
}
