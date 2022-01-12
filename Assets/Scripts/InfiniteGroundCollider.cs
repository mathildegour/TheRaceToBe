using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class InfiniteGroundCollider : MonoBehaviour
{
  //  public Transform[] PathSpawnPoints;
    public GameObject[] TypeOfPath ;
    public GameObject straightPath ;
    public GameObject rightPath ;
    public GameObject leftPath ;
    public GameObject straightPath2 ;
    public GameObject rightPath2 ;
    public GameObject leftPath2 ;
    public Transform SpawnPoint ;
    public Quaternion rotation ;
    
    void OnTriggerEnter(Collider hit){
        //player has hit the collider
        if (hit.gameObject.tag == Constants.PlayerTag)
        {
          
            Constants.POnP =true ;
            //find whether the next path will be straight, left or right
            int randomPath = Random.Range(0,3);
            initiateTypeOfPath();
            
                //instantiate the path, on the set rotation
               // lRot lastR = lastRotation.r;
                int rEnY= 0 ;
                if (randomPath==0 || randomPath==2) rEnY=180 ;
        
                
                Vector3 position = SpawnPoint.position ;
                
                //Debug.Log("rotation type of path" + TypeOfPath[randomPath].transform.rotation);
                rotation = TypeOfPath[randomPath].transform.rotation ;
                rotation= Quaternion.Euler(0,rEnY,0);
                //Debug.Log("la rotation en y : " + rotation.eulerAngles);
                rotation = chooseRot(rotation);
                Instantiate(TypeOfPath[randomPath],position, rotation);

                //Debug.Log("la rotation choisie : " + rotation);
                 rememberRot(randomPath);
                 lastRotation.nbrKm ++ ;
                 if (lastRotation.nbrKm >= Constants.l2){
                     Constants.Level2=true ;
                 }
                        
            // Vitesse augmentee
            GameObject.Find("KartClassic_Player").GetComponent<ArcadeKart>().IncreaseSpeed();
            
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        Constants.POnP =false ;
        this.GetComponent<BoxCollider>().enabled = false ;
    }

    public Quaternion chooseRot(Quaternion rot){
        int nR = Mathf.Abs(lastRotation.nbrRotation) %4;
       // Debug.Log("nbr abs rotation : " + nR);
       // Debug.Log("rotation départ : " + rot.eulerAngles);
        if(lastRotation.nbrRotation>0){
            switch (nR)
            {
                case 1:
                rot *= Quaternion.Euler(0,90,0);
                //Debug.Log("1");
                break;
                case 2:
                rot *= Quaternion.Euler(0,180,0);
                //Debug.Log("2");
                break;
                case 3 :
                rot *= Quaternion.Euler(0,270,0);
                //Debug.Log("3");
                break;
                default:
                //Debug.Log("0 or default");
                break;
            }
        }
        else {
            switch (nR)
            {
                case 1:
                rot *= Quaternion.Euler(0,-90,0);
                //Debug.Log("1");
                break;
                case 2:
                rot *= Quaternion.Euler(0,-180,0);
                //Debug.Log("2");
                break;
                case 3 :
                rot *= Quaternion.Euler(0,-270,0);
                //Debug.Log("3");
                break;
                default:
                //Debug.Log("0 or default");
                break;
            }
        }
        //Debug.Log("rotation fin : " + rot.eulerAngles);
        return rot ;
        
    }
    
    void rememberRot(int randomPath){
        if (randomPath==1) {
            lastRotation.nbrRotation++;
        }
        else if (randomPath==2 ) {
           lastRotation.nbrRotation--;
        }
        //Debug.Log("nbr rotation : " + lastRotation.nbrRotation);
    }
    
    void initiateTypeOfPath (){
        TypeOfPath = new GameObject[3];
        if (Constants.Level2){
            TypeOfPath[0]= straightPath2;
            TypeOfPath[1]= rightPath2;
            TypeOfPath[2]= leftPath2;
        }
        else{
            TypeOfPath[0]= straightPath;
            TypeOfPath[1]= rightPath;
            TypeOfPath[2]= leftPath;
        }

       
    }

    
}

