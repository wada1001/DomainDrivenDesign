using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace App.OutPuts
{
    public interface IClickerOutPut : IOutPut
    {
        IObservable<Unit> GetClickerObservable();
        IObservable<Unit> GetToItemObservable();
        void SetCurrentCoin(int value);
    }
}
