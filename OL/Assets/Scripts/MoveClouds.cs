using UnityEngine;

public class MoveClouds : MonoBehaviour
{
    public float Size;
    public float Speed;
    private void Start()
    {
        transform.localScale = new Vector3(1000f * Size, 1000f * Size, 1000f * Size);
        transform.eulerAngles = new Vector3(-90f, 0f, 0f);
        //  transform.Rotate(-90f, Vector3.right);
    }

    private void Update()
    {
        MoveObject();

        if (transform.position.z > 2000f)
        {
            Destroy(gameObject);
        }
    }

    private void MoveObject()
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + Speed * Time.deltaTime);
        transform.position = newPosition;
    }
}
