using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    static Image Barre; //image static pour agir dessus
    static Text Txt;
    public float max{get; set;}
    private float Valeur;

    public float valeur{
        get { return Valeur;}
        set {
            Valeur = Mathf.Clamp(value, 0, max);
            if (Barre!=null)
            {
                Barre.fillAmount = (1/max)*Valeur;
                Txt.text = Barre.fillAmount * 100 + "%";
            }
        }
    }

    void Start(){
        Barre = GetComponent<Image>();
        Txt = transform.Find("PourcentageVie").GetComponent<Text>();
        Txt.text = Barre.fillAmount * 100 + "%";
    }
}
