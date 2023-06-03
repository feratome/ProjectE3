using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Receiver : MonoBehaviour
{
    [SerializeField] private List<Sender> senders = new List<Sender>();
    [SerializeField] private int enablingCount;
    private int currentCount;

    public bool output;

    // Start is called before the first frame update
    void Start()
    {
        currentCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentCount = 0;

        foreach (Sender sender in senders) if(sender.output) currentCount++;

        output = (currentCount >= enablingCount);
    }
}
