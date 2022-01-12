using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGismoz : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnDrawGizmosSelected()
        {
        Gizmos.color = Color.green;
        Gizmos.DrawIcon(transform.position, "camera-512.png");
    }
}
