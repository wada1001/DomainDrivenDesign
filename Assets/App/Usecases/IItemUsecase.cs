using System.Collections;
using System.Collections.Generic;
using Domain.Entities;
using UnityEngine;

namespace App
{
    public interface IItemUsecase
    {
        bool Buy(int itemId);
        List<Item> GetItems();
    }
}
