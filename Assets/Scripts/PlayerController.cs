using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI level2Text;

    private Rigidbody rb;
    private float count;
    
    HealthBar BarreDeVie = new HealthBar();

    

    void Start(){
        rb = GetComponent<Rigidbody>();
        count = 0;
        //level2Text.text="test";
        level2Text.enabled =false;
        
        SetCountText();

        //initialise la barre de vie
        BarreDeVie.max=100;
        BarreDeVie.valeur=100;
    }

    void SetCountText(){
        countText.text = "Score : " + (count + lastRotation.nbrKm).ToString();

    }

    void SetDeadText(){
        endText.text="Perdu !!!";
    }
    
    void verifyL2(){
        if (lastRotation.nbrKm==Constants.l2+1){
            level2Text.enabled =true;
        }
        else if (lastRotation.nbrKm==(Constants.l2 + 4)){
            level2Text.enabled =false;
        }
        
    }
    
    void Update(){
        SetCountText();
        verifyL2();
    }

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        //Fall handler
        if(rb.position.y < -10)
        {
            SetDeadText();
            transform.parent.gameObject.AddComponent<GameOverScript>();
        }
    }

    void OnDestroy()
    {
        // Game Over.
        // Ajouter un nouveau script au parent
        // Car cet objet va être détruit sous peu
        //transform.parent.gameObject.AddComponent<GameOverScript>();
        Destroy(GameObject.Find("Timer"));
    }


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count += 0.5f;
            BarreDeVie.valeur += 10; //régénère de la vie
            SetCountText();

        }
    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Obstacle")){
            BarreDeVie.valeur -= 10; //enlève de la vie
            if (BarreDeVie.valeur==0){
                SetDeadText();
                //Head : Destroy(this);
                transform.parent.gameObject.AddComponent<GameOverScript>();
            }
        }
    }

}
