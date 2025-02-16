﻿using Data;
using Interfaces;
using Player;
using UnityEngine;

namespace Objects
{
	public class Item: MonoBehaviour, ICollisionTarget
	{
		[SerializeField] private SpriteRenderer spriteRenderer;
		public ItemData ItemData => data;
		private ItemData data;

		private bool isActivated;

		public void OnCollision(GameObject other)
		{
			if(isActivated)
				return;
			
			var playerInventory = other.GetComponent<PlayerInventory>();
			if (playerInventory == null)
				return;
			
			playerInventory.AddItems(data);
			isActivated = true;
			Destroy(gameObject);
		}

		public Item SetData(ItemData itemData)
		{
			data = itemData;
			spriteRenderer.sprite = itemData.Sprite;
			return this;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			if (ReferenceEquals(obj, null)) return false;
			if (obj.GetType() != typeof(Item)) return false;

			var other = (Item) obj;
			return Equals(other);
		}

		public bool Equals(Item other)
		{
			return data.Equals(other.data);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = 397 ^ data.GetHashCode();
				return hashCode;
			}
		}
	}
}