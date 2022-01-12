using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSky : MonoBehaviour
{
        
        public Material spaceSky;
        //in the editor this is what you would set as the object you wan't to change
        
        void Update()
        {
            if(lastRotation.nbrKm >= (Constants.l2+2)){
            RenderSettings.skybox= spaceSky;
            DynamicGI.UpdateEnvironment();
            }

        }
        

}
