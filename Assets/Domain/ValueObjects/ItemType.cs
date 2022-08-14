using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Domain.ValueObjects
{
	public class ItemType : ValueObject<int>
	{
		public const int TAP_UP = 1;
		public const int AUTO_TAP = 2;

		// TODO Validation
		public ItemType(int value) : base(value) { }

		public override bool Equals(object obj)
		{
			if (!(obj is ItemType itemType)) return false;

			return itemType.value == this.value;
		}

		public override int GetHashCode() => base.GetHashCode();

		public bool IsTapUp() => value == TAP_UP;
		public bool IsAutoTap() => value == AUTO_TAP;
	}
}
