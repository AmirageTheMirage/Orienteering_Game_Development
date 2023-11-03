using UnityEngine;
using UnityEngine.UI;

public class OutOfBounds : MonoBehaviour
{
    public GameObject OutOfBoundsText;
    public GameObject Player;
    public PauseMenuScript PauseScript; 
    void Start()
    {
        OutOfBoundsText.SetActive(false);
    }
    void Update()
    {
        Vector3 playerPosition = Player.transform.position; //Show Text if Out of Bounds

        if (playerPosition.z > 770 || playerPosition.z < 225 || playerPosition.x > 770 || playerPosition.x < 225 )
        {
            if (PauseScript.EscapeMenu == false)
            {
                OutOfBoundsText.SetActive(true);
            } else
            {
                OutOfBoundsText.SetActive(false);
            }
        }
        else
        {
            OutOfBoundsText.SetActive(false);
        }
    }
}
