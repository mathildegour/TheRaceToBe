using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {

	[SerializeField]
    int speed=4;
    [SerializeField]
    int coef_rot = 60;

    void Update () {
        transform.Translate( Vector3.forward* Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * coef_rot * Time.deltaTime);
    }
}
