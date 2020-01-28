using UnityEngine;
using System.Collections;
using Utilities;

namespace Buildings
{
    public class FountainController : MonoBehaviour
    {


        void Awake()
        {
            ObjectRegistry.fountain = gameObject;
        }


        void Update()
        {

        }
    }
}