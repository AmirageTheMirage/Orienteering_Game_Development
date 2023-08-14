using UnityEngine;

public class TouchingThorns : MonoBehaviour
{
    public bool IsTouchingThorns = false;
    private float RayDistance = 10f;
    public GameObject ThornRaycaster;
    public AchievementHandler AchievementScript;

    private void Update()
    {
        Ray ray = new Ray(ThornRaycaster.transform.position, Vector3.down);

        IsTouchingThorns = Physics.Raycast(ray, RayDistance, LayerMask.GetMask("Thorn")); //I glaubes s isch Thorn odr Thorns, auso faus ds ned geit...
        if (IsTouchingThorns)
        {
            AchievementScript.UnlockAchievement(12);
        }

        
    }
}
