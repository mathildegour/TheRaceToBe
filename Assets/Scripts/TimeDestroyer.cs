using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroyer : MonoBehaviour
{
    private bool test ;
    //private bool notClone ;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", LifeTime);    }

    void DestroyObject()
    {
        
       // string[ ] firstInstance = new string[] {"MT_Road_02", "MT_TurnLeft","Left2","Road2","Right","Right2"} ;
     /*   for (int i=0; i<firstInstance.Length; i++){
            if (Equals(gameObject.ToString(), firstInstance[i])) notClone=true ;
            Debug.Log(gameObject.ToString());
            Debug.Log(firstInstance[i]);
      
        } */
        //test = gameObject.tag == "Platforme" | Constants.POnP ;
        if (gameObject.GetInstanceID()<0 | gameObject.tag == "Platforme" ){
            if (GameManager.Instance.GameState != GameState.Dead)
            //Debug.Log(gameObject.ToString());
            //Debug.Log(gameObject.GetInstanceID());
            Destroy(gameObject);
        }
        
    
    }

        public float LifeTime = 15f;
}
