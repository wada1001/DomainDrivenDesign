using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Domain.Entities
{
    public class GameStatus
    {
        public int Coin;

        // TODO 多倍長整数にする
        public int TapPerCoin = 1;
        public int SecondPerCoin = 0;

    }
}
