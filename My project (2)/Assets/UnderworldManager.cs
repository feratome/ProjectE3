using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.XR.Interaction.Toolkit;

public class UnderworldManager : MonoBehaviour
{
    [SerializeField] private Vector3 respawnpoint;
	[SerializeField] private FadeScreen fs;
    [SerializeField] private bool IsUnderworld;
    [SerializeField] private XRBaseInteractor[] hands = new XRBaseInteractor[2];
    [SerializeField] private Light playerLight; 

	private float currentTime = 0f;
    [SerializeField] private float startingTime = 20f;


    [SerializeField] CanvasGroup myUIGroupPanel;
    [SerializeField] CanvasGroup myUIGroup;
    [SerializeField] Slider UISlider;
    [SerializeField] CanvasGroup sliderCanvasGroup;

    public static float InExpo(float t) => (float)Math.Pow(2, 10 * (t - 1)); //Fonction d'animation pour le UI

    private void Start()
    {
        ToOverworld();
        foreach(XRBaseInteractor interactor in hands) interactor.enabled = false;
        transform.position = respawnpoint;
        foreach(XRBaseInteractor interactor in hands) interactor.enabled = true;
    }


    private void OnTriggerEnter(Collider other)
	{

		if (other.CompareTag("Teleporter"))
		{
            Teleport tp = other.GetComponent<Teleport>();
            if(tp != null)
            {
                Vector3 move = tp.getMove();
                transform.position += move;
            }
            
            fs.ChangeColor(40f,155f,0);
			fs.FadeIn();

            if(IsUnderworld)
            {
                ToOverworld();
            }
            else
            {
                ToUnderworld();
            }
		}
    }

    private void ToUnderworld()
    {
        playerLight.enabled = true;
        currentTime = startingTime;
        IsUnderworld = true;
        sliderCanvasGroup.alpha = 1;
        myUIGroup.alpha = 1;
    }

    private void ToOverworld()
    {
        playerLight.enabled = false;
        IsUnderworld = false;
        sliderCanvasGroup.alpha = 0;
        myUIGroup.alpha = 0;
    }

    private void Update()
    {
        if(IsUnderworld)
        {
            currentTime -= 1* Time.deltaTime;
            myUIGroupPanel.alpha = InExpo((startingTime - currentTime)/startingTime);
            UISlider.value = currentTime/startingTime;

            if(currentTime <= 0f) Start();
        }
    }
}
