using System.Collections;
using System.Collections.Generic;
using App.EntryPoints;
using App.OutPuts;
using App.Usecases;
using UnityEngine;
using UniRx;

namespace App.Presenters
{
    public class ItemPresenter : State
    {
        readonly IItemOutPut itemOutPut;
        readonly IDialogOutPut dialogOutPut;
        readonly IItemUsecase itemUsecase;

        public ItemPresenter(
            IItemOutPut itemOutPut,
            IDialogOutPut dialogOutPut,
            IItemUsecase itemUsecase
        ) {
            this.itemOutPut = itemOutPut;
            this.dialogOutPut = dialogOutPut;
            this.itemUsecase = itemUsecase;
        }

        public override string GetKey() => "item";

        public override void OnEnter()
        {
            itemOutPut.Initialize();
            itemOutPut.GetBuyItemObservable().Subscribe(x => Buy(x));
            var items = itemUsecase.GetItems();
            itemOutPut.SetItems(items);
        }

        public override void OnExit()
        {
            itemOutPut.Terminate();
        }

        public override void OnUpdate()
        {
            
        }

        public void Buy(int itemId)
		{
            var res = itemUsecase.Buy(itemId);

            if (!res) return;

            var items = itemUsecase.GetItems();
            itemOutPut.SetItems(items);
        }
    }
}
