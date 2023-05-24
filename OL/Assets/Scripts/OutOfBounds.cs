using UnityEngine;
using UnityEngine.UI;

public class OutOfBounds : MonoBehaviour
{
    public GameObject OutOfBoundsText;
    public GameObject Player;
    void Start()
    {
        OutOfBoundsText.SetActive(false);
    }
    void Update()
    {
        Vector3 playerPosition = Player.transform.position;

        if (playerPosition.z > 770 || playerPosition.z < 225 || playerPosition.x > 770 || playerPosition.x < 225)
        {
            OutOfBoundsText.SetActive(true);
        }
        else
        {
            OutOfBoundsText.SetActive(false);
        }
    }
}
