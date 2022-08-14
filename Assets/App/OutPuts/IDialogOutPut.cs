using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace App.OutPuts
{
    public interface IDialogOutPut
    {
        void SetDescription(string description);
        void Close();
        IObservable<Unit> GetPositiveObservable();
        IObservable<Unit> GetNegativeObservable();
    }
}