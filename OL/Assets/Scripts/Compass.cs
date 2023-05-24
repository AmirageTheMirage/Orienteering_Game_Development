using UnityEngine;

public class Compass : MonoBehaviour
{
    public GameObject Player;
    public RectTransform NadelTransform;
    public float RotationSpeed = 2f; //Stops Lag I think?????

    private Quaternion targetRotation;

    void Start()
    {
        
        NadelTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
       
        float playerRotationY = Player.transform.rotation.eulerAngles.y;

       
        targetRotation = Quaternion.Euler(0f, 0f, playerRotationY);
        NadelTransform.rotation = Quaternion.Lerp(NadelTransform.rotation, targetRotation, RotationSpeed * Time.deltaTime); //YEEEEEA SMOOTH ROTATION!!!
    }
}