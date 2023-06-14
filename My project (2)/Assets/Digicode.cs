using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Digicode : Receiver 
{
    [SerializeField] private List<Sender> digicodeInOrder = new List<Sender>();
    private int correctInput;
    private bool isInput;
    private bool frontMontant;
    [SerializeField] private float timeActivated;

    // Start is called before the first frame update
    void Start()
    {
        correctInput = 0;
    }

    // Update is called once per frame
    void Update()
    {
        isInput = false;
        foreach(Sender sender in digicodeInOrder) { if(sender.output) isInput = true; }
        Debug.Log(isInput);

        if(isInput && !frontMontant) 
        {
            if (digicodeInOrder[correctInput].output)
            {
                correctInput++;
            }
            else { correctInput = 0; }
        }
        frontMontant = isInput;

        if (correctInput == digicodeInOrder.Count)
        {
            StartCoroutine(Output());
        }
    }

    private IEnumerator Output()
    {
        output = true;
        yield return new WaitForSeconds(timeActivated);
        output = false;
        correctInput = 0;
    }
}
