using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSensor : MonoBehaviour
{


    [SerializeField] PostAssign IHave; //Old Unused Script
    public bool touching = false;
    public int numberofendposten = 0;
    public int MyNameAsInt = 0;

    void Start()
    {
        MyNameAsInt = int.Parse(gameObject.name);
        
    }


   

    void OnCollisionEnter(Collision collision)
    {

        numberofendposten = IHave.endposten;
        
        
        if (MyNameAsInt == numberofendposten)
        {
            touching = true;
            Debug.Log(MyNameAsInt);
            Debug.Log("Ich bin der Endposten");
            Debug.Log("Jetzt wird das Spiel neu gestartet... (Feature Einbauen!!!) ;P");

        }
        


    }
















        /* public bool touching = false;
        public PostAssign MyScript;
        void Start() {
            MyScript = GameObject.Find("Posten").GetComponent<PostAssign>();
            Debug.Log(PostAssign.endposten);

        }
        //public int endpost = TouchSensor.script.endposten;
        // Start is called before the first frame update


        } */


    }
