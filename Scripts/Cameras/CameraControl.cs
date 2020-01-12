using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    [Header("Speed Settings")]
    public float moveSpeed = 5;
    public float rotationSpeed = 1;
    public float heightSpeed = 5;
    public float glideSpeed = 3;

    [Header("Camera Settings")]
    public float cameraAngle = 60;
    public float maxHeight = 25;
    public float minHeight = 5;

    [Header("Input Settings")]
    public KeyCode rotationLeft = KeyCode.Q;
    public KeyCode rotationRight = KeyCode.E;



    private float cameraRotation;
    private float targetCamRotation;
    private float height;
    private float targetHeight;
    private Vector3 targetDirection;
    public GameObject trackingObject;

    void Start()
    {
        cameraRotation = transform.rotation.y;
        targetCamRotation = cameraRotation;
        height = transform.position.y;
        targetHeight = height;

    }

    void Update()
    {

        // Tracking?
        if (trackingObject != null)
        {
            MoveCameraTo(trackingObject.transform.position);

            if (false)//trackingObject.CharacterController.IsTarget())
            {
                StopTracking();
            }
        }
        else
        {
            Vector3 targetDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            MoveCameraTo(targetDirection);
        }

        RecalculatePosition();

    }

    void RecalculatePosition()
    {
        if (Input.GetKey(rotationRight)) targetCamRotation -= rotationSpeed;
        else if (Input.GetKey(rotationLeft)) targetCamRotation += rotationSpeed;
        cameraRotation = Mathf.Lerp(cameraRotation, targetCamRotation, glideSpeed * Time.deltaTime);

        targetHeight += Input.GetAxis("Mouse ScrollWheel") * heightSpeed;
        targetHeight = Mathf.Clamp(targetHeight, minHeight, maxHeight);
        height = Mathf.Lerp(height, targetHeight, glideSpeed * Time.deltaTime);
    }

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
}