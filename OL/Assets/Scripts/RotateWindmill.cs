using UnityEngine;

public class RotateWindmill : MonoBehaviour
{
    public float rotationSpeed = 5f;
    private Transform centerPoint;

    void Start()
    {
        // Create an empty GameObject as the center point
        centerPoint = new GameObject().transform;
        centerPoint.position = transform.position;
        transform.SetParent(centerPoint);
    }

    void Update()
    {
        // Rotate the center point by rotationSpeed degrees on the y-axis multiplied by the time since the last frame
        centerPoint.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnDestroy()
    {
        // Destroy the center point GameObject when the script is disabled or the object is destroyed
        if (centerPoint != null)
        {
            Destroy(centerPoint.gameObject);
        }
    }
}
