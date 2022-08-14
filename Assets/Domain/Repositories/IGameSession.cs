using System.Collections;
using System.Collections.Generic;
using Domain.Entities;
using UnityEngine;

namespace Domain.Repositories
{
    public interface IGameSession
    {
        void AddCoin(int coin);
        int GetCurrentCoin();
        GameStatus GetGameStatus();
        void SetGameStatus(GameStatus gameStatus);
    }
}
