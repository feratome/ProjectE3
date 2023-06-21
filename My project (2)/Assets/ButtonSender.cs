using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSender : Sender
{
    [SerializeField] private ParticleSystem particle;

    private void Start()
    {
        particle.Stop();
    }
    public void setOutputTrue()
    {
        particle.Play();
        output = true;
        
    }

    public void setOutputFalse()
    {
        particle.Stop();
        output = false;
    }

    public bool Returnoutput(){
        return output;
    }
}
