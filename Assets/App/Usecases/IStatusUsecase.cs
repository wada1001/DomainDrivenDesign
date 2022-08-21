using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace App
{
    public interface IStatusUsecase
    {
        void AddSingle();
        void UpdateSingle();
        BigInteger GetTotalCoin();
    }
}
