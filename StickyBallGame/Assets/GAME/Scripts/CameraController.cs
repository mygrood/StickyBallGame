using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private float smoothSpeed = 5f;

    private Camera cam;
    private float minY;

    private void Awake()
    {
        cam = Camera.main;
        minY = cam.transform.position.y;
    }

    private void Start()
    {
        AdjustCameraSize();
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        float camHalfHeight = cam.orthographicSize;
        float playerY = player.position.y;
        float cameraY = cam.transform.position.y;

        float middleY = cameraY;

        if (playerY > middleY) 
        {
            float targetY = playerY; 
            float newY = Mathf.Lerp(cameraY, targetY, smoothSpeed * Time.deltaTime);
            cam.transform.position = new Vector3(cam.transform.position.x, Mathf.Max(newY, minY), cam.transform.position.z);
        }
    }
    
    void AdjustCameraSize()
    {
        float screenRatio = (float)Screen.width / Screen.height;
        float backgroundWidth = background.bounds.size.x;

        cam.orthographicSize = backgroundWidth / (2f * screenRatio);
    }
}