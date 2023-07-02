using UnityEngine;

public class Compass : MonoBehaviour
{
    public GameObject PlayerPosts;
    public GameObject PlayerOrienteering;
    public RectTransform NadelTransform;
    public float RotationSpeed = 2f; //Stops Lag I think?????
    private int Mode;

    private Quaternion targetRotation;

    void Start()
    {
        
        NadelTransform = GetComponent<RectTransform>();
        Mode = PlayerPrefs.GetInt("ModeDropdown_Setting");

    }

    void Update()
    {
        float playerRotationY;
        if (Mode == 0)
        {
            playerRotationY = PlayerPosts.transform.rotation.eulerAngles.y;
        } else
        {
            playerRotationY = PlayerOrienteering.transform.rotation.eulerAngles.y;
        }

       
        targetRotation = Quaternion.Euler(0f, 0f, playerRotationY);
        NadelTransform.rotation = Quaternion.Lerp(NadelTransform.rotation, targetRotation, RotationSpeed * Time.deltaTime); //YEEEEEA SMOOTH ROTATION!!!
    }
}