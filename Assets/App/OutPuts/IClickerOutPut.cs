using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Numerics;

namespace App.OutPuts
{
    public interface IClickerOutPut : IOutPut
    {
        IObservable<Unit> GetClickerObservable();
    }

    public interface IIncrimentOutPut : IOutPut
    {
        void SetCurrentCoin(BigInteger value);
    }

    public interface INavigatorOutPut : IOutPut
    {
        // TODO 一つずつはよくないが、一旦
        IObservable<Unit> GetClickerObservable();
        IObservable<Unit> GetItemObservable();
    }
}
