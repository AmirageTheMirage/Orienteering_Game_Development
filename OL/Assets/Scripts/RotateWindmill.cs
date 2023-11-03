using UnityEngine;

public class RotateWindmill : MonoBehaviour
{
    public float rotationSpeed = 5f;
    private Transform centerPoint;

    void Start()
    {
        
        centerPoint = new GameObject().transform;
        centerPoint.position = transform.position;
        transform.SetParent(centerPoint);
    }

    void Update()
    {
        // Make the centerPoint Rotate
        centerPoint.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnDestroy()
    {
        
        if (centerPoint != null)
        {
            Destroy(centerPoint.gameObject);
        }
    }
}
