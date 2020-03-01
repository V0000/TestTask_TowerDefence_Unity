using UnityEngine;
using System.Collections;
using Utilities;

namespace Cameras
{
	/// <summary>
    /// Class controls camera movements
    /// </summary>
    public class CameraControl : MonoBehaviour
    {
        [Header("Speed Settings")]
        public float moveSpeed = 10;
        public float rotationSpeed = 1;
        public float heightSpeed = 5;
        public float glideSpeed = 3;

        [Header("Camera Settings")]
        public float cameraAngle = 60;
        public float maxHeight = 40;
        public float minHeight = 5;
		[Tooltip("If we need use border of screen for moving of camera")]
        public bool useEdgeBorderForMove = false;
        [Tooltip("Distance from screen edge. Used for mouse movement")]
        public float screenEdgeBorderThickness = 20;

        [Header("Input Settings")]
		[Tooltip("This key will used for left rotation of camera")]
        public KeyCode rotationLeft = KeyCode.Q;
		[Tooltip("This key will used for right rotation of camera")]
        public KeyCode rotationRight = KeyCode.E;



        private float cameraRotation;
        private float targetCamRotation;
        private float height;
        private float targetHeight;
        private Vector3 targetDirection;
        private Camera cachedCamera;
        public GameObject trackingObject;

        void Awake()
        {
            ObjectRegistry.mainCamera = gameObject;
        }
        void Start()
        {
			//initialize start position of camera
            cameraRotation = transform.rotation.y;
            targetCamRotation = cameraRotation;
            height = transform.position.y;
            targetHeight = height;
			//cache the camera for easy access
            cachedCamera = GetComponent<UnityEngine.Camera>();
        }

        void Update()
        {
            RecalculatePosition();
            RecalculateRotation();
            RecalculateHeight();
            MoveCameraTo(targetDirection);
        }
		/// <summary>
		/// Calculation of x&z positions
		/// </summary>
        void RecalculatePosition()
        {
            // Tracking?
            if (trackingObject != null)
            {
                targetDirection = (trackingObject.transform.position - cachedCamera.transform.position).normalized;
                targetDirection.z = 0;


                //if (false)//trackingObject.CharacterController.IsTarget())
                //{
                //StopTracking();
                //}
            }
            else
            {
                targetDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

                if (useEdgeBorderForMove)
                {
                    MoveUsingEdgeOfScreen();
                }

            }

        }
		/// <summary>
		/// Calculation of rotation camera
		/// </summary>
        void RecalculateRotation()
        {
            if (Input.GetKey(rotationRight)) targetCamRotation -= rotationSpeed;
            else if (Input.GetKey(rotationLeft)) targetCamRotation += rotationSpeed;
            cameraRotation = Mathf.Lerp(cameraRotation, targetCamRotation, glideSpeed * Time.deltaTime);
        }
		
		/// <summary>
		/// Calculation of y position
		/// </summary>
        void RecalculateHeight()
        {
            targetHeight -= Input.GetAxis("Mouse ScrollWheel") * heightSpeed;
            targetHeight = Mathf.Clamp(targetHeight, minHeight, maxHeight);
            height = Mathf.Lerp(height, targetHeight, glideSpeed * Time.deltaTime);
        }
		
		/// <summary>
		/// Move camera to calculated coorditates
		/// </summary>
        void MoveCameraTo(Vector3 position)
        {
            transform.Translate(position * moveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
            transform.rotation = Quaternion.Euler(cameraAngle, cameraRotation, 0);
        }

        void StopTracking()
        {
            trackingObject = null;
        }

		/// <summary>
		/// Move camera using borders
		/// </summary>
        void MoveUsingEdgeOfScreen()
        {
            if (Input.mousePosition.x <= screenEdgeBorderThickness)
            {
                targetDirection += Vector3.left;
            }
            if (Input.mousePosition.x >= Screen.width - screenEdgeBorderThickness)
            {
                targetDirection += Vector3.right;
            }
            if (Input.mousePosition.y <= screenEdgeBorderThickness)
            {
                targetDirection -= Vector3.forward;
            }
            if (Input.mousePosition.y >= Screen.height - screenEdgeBorderThickness)
            {
                targetDirection += Vector3.forward;
            }
        }
    }
}