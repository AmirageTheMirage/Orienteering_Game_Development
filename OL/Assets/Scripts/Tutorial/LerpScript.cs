using System.Collections;
using UnityEngine;

public class LerpScript : MonoBehaviour
{
    public GameObject Cam;
    public GameObject LerpParent;
    public float LerpSpeed = 1f;
    public float RotationSpeed = 1f;
    public float DistanceToTarget; 
    public TutorialHandler TutorialHandlerScript;
    private GameObject Target;
    private GameObject LookAt;
    private Vector3 CamPos;
    private Vector3 TargetPos;
    private bool DoLerp = false;
    private float OriginalDistanceToTarget;
    private Vector3 LookAtPos;
    private bool UpdatedCameraPosition = false;
    private Vector3 UpdatedCamPos;
    private int LerpInt = 0;
    //private 

    private void Start()
    {
       // LerpTo(1);
        
    }

    private void Update()
    {
        if (DoLerp)
        {
            //Move Cycle
            DistanceToTarget = Vector3.Distance(Target.transform.position, Cam.transform.position); //Calc ArrivingDistance
            float LerpProgress = Mathf.Clamp01(LerpSpeed * Time.deltaTime); //Lerp Progress 
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, TargetPos, LerpProgress);



            //Rotation Cycle
            if (OriginalDistanceToTarget / 2 < DistanceToTarget)
            {
                Quaternion TargetRotation = Quaternion.LookRotation(TargetPos - CamPos); //Get Diff between the Rotations so I can Lerp
                Cam.transform.rotation = Quaternion.Lerp(Cam.transform.rotation, TargetRotation, RotationSpeed * Time.deltaTime);
            } else
            {
                if (UpdatedCameraPosition == false)
                {
                    UpdatedCamPos = Cam.transform.position;
                }
                Debug.Log("Phase2");
                Quaternion TargetRotation = Quaternion.LookRotation(LookAtPos - UpdatedCamPos); 
                Cam.transform.rotation = Quaternion.Lerp(Cam.transform.rotation, TargetRotation, RotationSpeed * Time.deltaTime);

            }
            

            //Stop the Cycle
            if (DistanceToTarget < 0.1f)
            {
                DoLerp = false;
                TutorialHandlerScript.Tutorial(LerpInt);
            }
        }


    }

    public void LerpTo(int LerpChildNumber)
    {
        //LerpInt++; //Might want to remove this one later
        //LerpChildNumber = LerpInt;
        if (!DoLerp)
        {
            //Debug.Log("TryingLerp");
            UpdatedCameraPosition = false;
            DoLerp = true;
            CamPos = Cam.transform.position;
            GameObject ParentLerper = LerpParent.transform.Find(LerpChildNumber.ToString()).gameObject;
           // Debug.Log("Found ParentLerper");
            Target = ParentLerper.transform.Find("Target").gameObject;
            LookAt = ParentLerper.transform.Find("LookAt").gameObject;
            //LookAt 

            TargetPos = Target.transform.position;
            LookAtPos = LookAt.transform.position;
            OriginalDistanceToTarget = Vector3.Distance(Target.transform.position, Cam.transform.position);
        }
    }
}
