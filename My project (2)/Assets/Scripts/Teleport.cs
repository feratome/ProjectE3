using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Vector3 move;
    [SerializeField] private GameObject perso;
	[SerializeField] private FadeScreen fs;
    [SerializeField] private bool IsUnderworld;

	float currentTime = 0f;
    float startingTime = 9.9999f;


    [SerializeField] CanvasGroup myUIGroupPanel;
    [SerializeField] CanvasGroup myUIGroup;
    [SerializeField] Slider UISlider;
    [SerializeField] CanvasGroup sliderCanvasGroup;

    public static float InExpo(float t) => (float)Math.Pow(2, 10 * (t - 1)); //Fonction d'animation pour le UI

    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
	{

		if (other.CompareTag("Player"))
		{

			perso.transform.position = perso.transform.position + move;
			fs.ChangeColor(40f,155f,0);
			fs.FadeIn();

            IsUnderworld = !IsUnderworld;
            currentTime = startingTime;
            
            
			
		}
    }
    private void Update(){
        if(IsUnderworld==false){
            // Desactiver le timer
            Debug.Log("desac timer");
            sliderCanvasGroup.alpha = 0;
            myUIGroup.alpha = 0;
            currentTime = 10f;

        }else{
            Debug.Log("est autre monde");
            //verifier si le tiemer se fini
            if(currentTime <= 0f){
            Debug.Log("perso est mort");
            //countDownText.text = "";
            sliderCanvasGroup.alpha = 0;
            myUIGroup.alpha = 0;
			// Le joueur meurt
			perso.transform.position = new Vector3(48.6100006f,5.23999977f,120.900002f);
			fs.ChangeColor(40f,155f,0);
			fs.FadeIn();
            IsUnderworld =!IsUnderworld;

            }else{
            Debug.Log("hi");
            sliderCanvasGroup.alpha = 1;
            myUIGroup.alpha = 1;
            
            currentTime -= 1* Time.deltaTime;

            // control du fading de l'ui
            myUIGroupPanel.alpha = InExpo((startingTime - currentTime)/startingTime);

            UISlider.value = currentTime/startingTime;

            }
        }
	}
}
