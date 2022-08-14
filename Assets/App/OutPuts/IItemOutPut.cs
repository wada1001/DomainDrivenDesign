using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Entities;
using UniRx;
using UnityEngine;

namespace App.OutPuts
{
    public interface IItemOutPut : IOutPut
    {
        void SetItems(List<Item> items);
        IObservable<Unit> GetBackObservable();
        IObservable<int> GetBuyItemObservable();
    }
}
