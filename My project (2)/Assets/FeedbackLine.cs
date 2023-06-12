using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FeedbackLine : MonoBehaviour
{
    [SerializeField] private Receiver input;
    [SerializeField] private List<LineRenderer> lines;

    private Color currentColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(input != null) 
        {
            if(input.output)
            {
                currentColor = new Color(0f, 255f, 0f);
            }
            else 
            {
                currentColor = new Color(255f, 0f, 0f);
            }
        }

        foreach (LineRenderer line in lines)
        {
            line.startColor = currentColor;
            line.endColor = currentColor;
        }
    }
}
