using UnityEngine;

public class TouchingThorns : MonoBehaviour
{
    public bool IsTouchingThorns = false;
    private float RayDistance = 50f;
    public GameObject ThornRaycaster;
    public AchievementHandler AchievementScript;

    private void Update()
    {
        Ray ray = new Ray(ThornRaycaster.transform.position, Vector3.down); //Make Raycast to check for thorns

        IsTouchingThorns = Physics.Raycast(ray, RayDistance, LayerMask.GetMask("Thorn")); //I glaubes s isch Thorn odr Thorns, auso faus ds ned geit...
        if (IsTouchingThorns)
        {
            AchievementScript.UnlockAchievement(12); //The Script handles the rest
        }

        
    }
}
