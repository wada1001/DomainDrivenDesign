using System.Collections;
using System.Collections.Generic;
using Domain.Entities;
using UnityEngine;

namespace Domain.Repositories
{
    public interface IItemRepository
    {
        List<Item> GetItems();
        Item FindItem(int itemId);
        void UpsertItem(Item item);
    }
}
