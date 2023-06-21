using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToGame : MonoBehaviour
{
    private ButtonSender scriptA;

    private void Start()
    {
        // Assign the reference to the ButtonSender script
        scriptA = FindObjectOfType<ButtonSender>();
    }

    // Start is called before the first frame update
    void Update(){
        if(scriptA.Returnoutput()==true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
