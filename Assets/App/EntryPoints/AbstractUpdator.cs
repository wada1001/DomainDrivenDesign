using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace App.EntryPoints
{
    public abstract class AbstractUpdator : IFixedTickable, IInitializable
    {
        // TODO まだ未使用。基底に持っていて欲しい機能？
		public abstract void FixedTick();
		public abstract void Initialize();
    }
}
