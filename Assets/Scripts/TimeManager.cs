using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    float startTimer = 0;
    float gameTimer = 0f;

    bool startBool = false;

    public GameObject startTimerText;
    public Text gameTimerText;

    //public TimeManager instance;
    //// インスタンス化
    //void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(this.gameObject);
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TimeStart");
        gameTimer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        startTimerText.GetComponent<Text>().text = startTimer.ToString();
        gameTimerText.text = "Timer: " + gameTimer.ToString();
        if (startBool)
        {
            gameTimer -= Time.deltaTime;
        }
        if(gameTimer <= 0)
        {
            FadeManager.fadeInstance.FadeStart(2, "GameOver");
        }
    }

    private IEnumerator TimeStart()
    {
        startTimer = 3f;

        while (startTimer <= 0)
        {
            startTimer -= Time.deltaTime;
            if (startTimer <= 0)
            {
                startBool = true;
                startTimer = 0;
                startTimerText.SetActive(false);
                yield return null;
            }
        }
    } 
}

