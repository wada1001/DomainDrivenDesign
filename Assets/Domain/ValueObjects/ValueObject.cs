using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Domain.ValueObjects
{
	public abstract class ValueObject<T>
	{
		protected T value;

		protected ValueObject(T value) => this.value = value;

		public abstract override bool Equals(object obj);
		public override int GetHashCode() => base.GetHashCode();
	}
}
