using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

namespace Domain.Entities
{
    public class GameStatus
    {
        public BigInteger Coin;
        public int TapPerCoin = 1;
        public int SecondPerCoin = 0;
    }
}
