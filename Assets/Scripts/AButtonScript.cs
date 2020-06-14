using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButtonFolder
{
    public class AButtonScript : MonoBehaviour
    {
        bool isPress = false;

        float pressedTime = 0f;

        GameObject player;
        PlayerScript playerScript;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.Find("Player");
            playerScript = player.GetComponent<PlayerScript>();
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(pressedTime);
            if (isPress)
            {
                pressedTime += Time.deltaTime;
                if (pressedTime > 3f)
                {
                    playerScript.brokenBool = true;
                }
            }
        }
        public void AButtonDown()
        {
            isPress = true;
        }
        public void AButtonUp()
        {
            isPress = false;
            pressedTime = 0f;
        }
    }
}
