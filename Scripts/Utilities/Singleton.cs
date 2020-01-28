using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    /// <summary>
    /// Singleton class
    /// </summary>
    /// <typeparam name="T">Type of the singleton</typeparam>
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        /// <summary>
        /// The static reference to the instance
        /// </summary>
        public static T Instance { get; protected set; }

        public static bool InstanceExists
        {
            get { return Instance != null; }
        }
        /// <summary>
        /// Associate singleton with instance
        /// </summary>
        protected virtual void Awake()
        {
            if (InstanceExists)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = (T)this;
            }
        }
        /// <summary>
        /// Clear singleton associations
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}

