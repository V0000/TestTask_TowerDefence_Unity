using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cameras
{
    public class CameraRig : MonoBehaviour
    {

        /// <summary>
        /// True maximum zoom level
        /// </summary>
        public float maxZoom = 40;

        /// <summary>
        /// True minimum zoom level
        /// </summary>
        public float minZoom = 15;

        /// <summary>
        /// Target position of the camera
        /// </summary>
        public Vector3 cameraPosition;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            RecalculatingBoundingRect();
        }

        void RecalculatingBoundingRect()
        {
            transform.position = cameraPosition;
            
        }
    }
}

