using System.Collections;
using UnityEngine;

public class LerpScript : MonoBehaviour
{
    public GameObject Cam;
    public GameObject LerpParent;
    public float LerpSpeed = 1f;
    public float LastLerpSpeed = 0.2f;
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
    private AudioHandler AudioScript;

    //private 

    private void Start()
    {
        AudioScript = GameObject.Find("FullAudioHandler").GetComponent<AudioHandler>();
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
            if (OriginalDistanceToTarget / 2 < DistanceToTarget && LerpInt != 9)
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
            
            if (DistanceToTarget < (OriginalDistanceToTarget / 1.5) && LerpInt == 9)
                
            {
                TutorialHandlerScript.StartLogo();
            }
            //Stop the Cycle
            if (DistanceToTarget < 0.1f)
            {
                
                DoLerp = false;
                
                if (LerpInt != 9)
                {
                    TutorialHandlerScript.Tutorial(LerpInt);
                    //Debug.Log("LerpedIn");
                }
                if (LerpInt == 8)
                {
                    LerpSpeed = LastLerpSpeed;
                }
                int RandomNumber = Random.Range(0, 2);
                if (RandomNumber == 1)
                {
                    AudioScript.PlaySound("OpenMap");
                } else
                {
                    AudioScript.PlaySound("CloseMap");
                }
            }
        }


    }

    public void LerpTo(int LerpChildNumber)
    {
        //LerpInt++; //Might want to remove this one later
        //LerpChildNumber = LerpInt;
        LerpInt = LerpChildNumber;
        AudioScript.PlaySound("Select1");
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
