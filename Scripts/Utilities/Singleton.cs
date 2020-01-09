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
        public static T instance { get; protected set; }

        public static bool instanceExists
        {
            get { return instance != null; }
        }
        /// <summary>
        /// Associate singleton with instance
        /// </summary>
        protected virtual void Awake()
        {
            if (instanceExists)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = (T) this;
            }
        }
        /// <summary>
        /// Clear singleton associations
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }
    }
}

