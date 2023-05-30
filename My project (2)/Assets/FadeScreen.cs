using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{   
    public bool fadeOnStart = true;  
    public float fadeDuration = 2 ;
    public Color fadeColor;
    private Renderer rend;
    // Start is called before the first frame update
    
    public void ChangeColor(float a, float b, float c)
    {
        fadeColor = new Color(a,b,c,1);
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        if(fadeOnStart){
            ChangeColor(0f,0f,0f);
            FadeIn();
        }
    }

    public void FadeIn(){
        Fade(1,0);
    }

    public void FadeOut(){
        Fade(0,1);
    }
    // Update is called once per frame
    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn,alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn,float alphaOut){
        
        float timer = 0;

        while(timer<= fadeDuration){
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn,alphaOut,timer/fadeDuration);
            rend.material.SetColor("_Color",newColor);

            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        rend.material.SetColor("_Color",newColor2);


    }
}
