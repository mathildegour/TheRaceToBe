// CAMERA PLAYER VIEW (SWITCH CAM FIRST PERSON TO THIRD PERSON)
// http://www.upln.fr
//////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class PlayerCamView : MonoBehaviour {

    [Header("Camera")]
    public Camera CameraFPS;
    public AudioClip changeSound;
    public KeyCode KeySwitch=KeyCode.V;
    AudioSource audios;
    bool viewFPS = false;
    public int CameraDepth = 2;
    Vector3 posCamFps;
    Quaternion rotCamFps;
    [Header("Smooth Follow TPS")]
    public Transform player;
    public float distance = 15;
    public float height = 5;
    public float heightDamping = 3;
    public float rotationDamping = 3;
    Text txt; 

    void Awake () {      
        audios = GetComponent<AudioSource>();       
        CameraFPS.depth = CameraDepth;
        posCamFps = CameraFPS.transform.localPosition;
        rotCamFps = CameraFPS.transform.localRotation;  
    }
    
   void Update() {        

        if (Input.GetKeyDown(KeySwitch))
        {           
            viewFPS = !viewFPS;
            //audios.PlayOneShot(changeSound);

            if (viewFPS)
            {              
                CameraFPS.transform.localPosition = posCamFps;
                CameraFPS.transform.localRotation = rotCamFps;
            }
            else
            {
                posCamFps = CameraFPS.transform.localPosition;
                rotCamFps = CameraFPS.transform.localRotation;
            }
        }

        if (!viewFPS)
        {
            float wantedRotationAngle = transform.eulerAngles.y;
            float wantedHeight = transform.position.y + height;
            float currentRotationAngle = CameraFPS.transform.eulerAngles.y;
            float currentHeight = CameraFPS.transform.position.y;
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
            Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
            Vector3 pos = player.position;
            pos -= currentRotation * Vector3.forward * distance;
            pos.y = currentHeight;
            CameraFPS.transform.position = pos;
            CameraFPS.transform.LookAt(player);
        }        
    }  
} 
        
   





