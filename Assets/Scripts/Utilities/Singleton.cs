﻿using System;
using UnityEngine;

namespace Utilities
{
	public abstract class Singleton<T> : MonoBehaviour where T: Component
	{
		public static T Instance { get; protected set; }

		[SerializeField] private bool dontDestroyOnLoad;
		
		protected virtual void Awake()
		{
			if (Instance != null)
			{
				Debug.LogWarning($"Instance of {GetType()} already exists! Destroying {name}.");
				Destroy(this);
			}

			Instance = this as T;
			if(dontDestroyOnLoad)
				DontDestroyOnLoad(this);
		}

		protected void OnDestroy()
		{
			if (Instance == this)
				Instance = null;
		}

		private void Reset()
		{
			name = GetType().Name;
		}
	}
}