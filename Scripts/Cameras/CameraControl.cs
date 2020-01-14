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
	private Camera cachedCamera;
    public GameObject trackingObject;

    void Start()
    {
        cameraRotation = transform.rotation.y;
        targetCamRotation = cameraRotation;
        height = transform.position.y;
        targetHeight = height;
		cachedCamera = GetComponent<UnityEngine.Camera>();
    }

    void Update()
    {
		RecalculatePosition();
		RecalculateRotation();
		RecalculateHeight();
		MoveCameraTo(targetDirection); 
    }

    void RecalculatePosition()
    {
		        // Tracking?
        if (trackingObject != null)
        {
			targetDirection = (trackingObject.transform.position - cachedCamera.transform.position).normalize();
			targetDirection.z = 0;
            

            if (false)//trackingObject.CharacterController.IsTarget())
            {
                StopTracking();
            }
        }
        else
        {
            targetDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0); 


                //разобрать всю эту хрень
               
                        if (20 > Input.mousePosition.x){
                                transform.position -= new Vector3(CameraSpeed,0,0);
                        }
                        if ((Screen.width-10)<Input.mousePosition.x){
                               
                                transform.position += new Vector3(CameraSpeed,0,0);
                        }
                        if (20 > Input.mousePosition.y){
                                transform.position -= new Vector3(0,0,CameraSpeed);
                        }
                        if ((Screen.height-10)<Input.mousePosition.y){
                                transform.position += new Vector3(0,0,CameraSpeed);
                        }			
        }
        
    }
	
	    void RecalculateRotation()
    {
        if (Input.GetKey(rotationRight)) targetCamRotation -= rotationSpeed;
        else if (Input.GetKey(rotationLeft)) targetCamRotation += rotationSpeed;
        cameraRotation = Mathf.Lerp(cameraRotation, targetCamRotation, glideSpeed * Time.deltaTime);

    }
	    void RecalculateHeight()
    {
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