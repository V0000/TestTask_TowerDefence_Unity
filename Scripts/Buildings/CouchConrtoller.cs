using UnityEngine;
using System.Collections;
using Utilities;

namespace Buildings
{
    public class CouchConrtoller : MonoBehaviour
    {

        // Use this for initialization
        void Awake()
        {
            ObjectRegistry.couch = gameObject;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
