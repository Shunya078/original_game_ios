using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public bool brokenBool = false;
    Button buttonA; 
    // Start is called before the first frame update
    void Start()
    {
        buttonA = GameObject.Find("Canvas/A_Button").GetComponent<Button>();
        buttonA.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //    if (brokenBool)
        //    {
        //Destroy(gameObject);
        //    }
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Broken")
        {
            buttonA.enabled = true;
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if (brokenBool)
        {
            if(col.gameObject.tag == "Broken")
            Destroy(col.gameObject);
            buttonA.enabled = false;
        }
    }
}
