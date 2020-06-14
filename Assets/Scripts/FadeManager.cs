using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    private static Canvas fadeCanvas;
    private static Image fadeImage;

    public static bool isFadeIn = false;
    public static bool isFadeOut = false;

    public static FadeManager fadeInstance;

    private void Awake()
    {
        if (fadeInstance == null)
        {
            fadeInstance = this;
            DontDestroyOnLoad(this.gameObject);
            Init();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    static void Init()
    {
        GameObject FadeCanvasObject = new GameObject("FadeCanvas");
        fadeCanvas = FadeCanvasObject.AddComponent<Canvas>();
        FadeCanvasObject.AddComponent<GraphicRaycaster>();
        fadeCanvas.renderMode = RenderMode.ScreenSpaceOverlay;

        fadeCanvas.sortingOrder = 100;

        fadeImage = new GameObject("FadeImage").AddComponent<Image>();
        fadeImage.transform.SetParent(fadeCanvas.transform, false);
        fadeImage.rectTransform.anchoredPosition = Vector3.zero;

        //Camera camera = Camera.main.GetComponent<Camera>();
        fadeImage.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);

        fadeCanvas.enabled = false;
        DontDestroyOnLoad(fadeCanvas.gameObject);
    }

    public void Fade(float interval)
    {
        if (fadeCanvas == null)
        {
            Init();
        }
        StartCoroutine(FadeNoChange(interval));
    }

    public void FadeSceneLoad(float interval, string sceneName)
    {
        if (fadeCanvas == null)
        {
            Init();
        }
        StartCoroutine(FadeSceneAdd(interval, sceneName));
    }


    public void FadeSceneUnLoadWin(float interval, string sceneName)
    {
        if (fadeCanvas == null)
        {
            Init();
        }
        StartCoroutine(FadeSceneRemoveWin(interval, sceneName));
    }

    public void FadeSceneUnLoadLose(float interval, string sceneName)
    {
        if (fadeCanvas == null)
        {
            Init();
        }
        StartCoroutine(FadeSceneRemoveLose(interval, sceneName));
    }

    private IEnumerator FadeNoChange(float interval)
    {
        float time = 0f;
        fadeCanvas.enabled = true;

        while (time <= interval)
        {
            float fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            fadeImage.color = new Color(0f, 0f, 0f, fadeAlpha);
            time += Time.deltaTime;
            yield return null;
        }

        time = 0f;

        while (time <= interval)
        {
            float fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
            fadeImage.color = new Color(0f, 0f, 0f, fadeAlpha);
            time += Time.deltaTime;
            yield return null;
        }

        fadeCanvas.enabled = false;

    }

    private IEnumerator FadeSceneAdd(float interval, string sceneName)
    {
        float time = 0f;
        fadeCanvas.enabled = true;

        while (time <= interval)
        {
            float fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            fadeImage.color = new Color(0f, 0f, 0f, fadeAlpha);
            time += Time.deltaTime;
            yield return null;
        }

        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        time = 0f;

        while (time <= interval)
        {
            float fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
            fadeImage.color = new Color(0f, 0f, 0f, fadeAlpha);
            time += Time.deltaTime;
            yield return null;
        }

        fadeCanvas.enabled = false;
    }

    private IEnumerator FadeSceneRemoveWin(float interval, string sceneName)
    {
        float time = 0f;
        fadeCanvas.enabled = true;

        while (time <= interval)
        {
            float fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            fadeImage.color = new Color(0f, 0f, 0f, fadeAlpha);
            time += Time.deltaTime;
            yield return null;
        }

        yield return SceneManager.UnloadSceneAsync(sceneName);
        time = 0f;

        while (time <= interval)
        {
            float fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
            fadeImage.color = new Color(0f, 0f, 0f, fadeAlpha);
            time += Time.deltaTime;
            yield return null;
        }

        fadeCanvas.enabled = false;
    }

    private IEnumerator FadeSceneRemoveLose(float interval, string sceneName)
    {
        float time = 0f;
        fadeCanvas.enabled = true;

        while (time <= interval)
        {
            float fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            fadeImage.color = new Color(255f, 255f, 255f, fadeAlpha);
            time += Time.deltaTime;
            yield return null;
        }

        yield return SceneManager.UnloadSceneAsync(sceneName);
        time = 0f;

        while (time <= interval)
        {
            float fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
            fadeImage.color = new Color(255f, 255f, 255f, fadeAlpha);
            time += Time.deltaTime;
            yield return null;
        }

        fadeCanvas.enabled = false;
    }

    //タイトル時のみ使用
    public void FadeStart(float interval, string sceneName)
    {
        if (fadeCanvas == null)
        {
            Init();
        }
        StartCoroutine(FadeStartScene(interval, sceneName));
    }

    private IEnumerator FadeStartScene(float interval, string sceneName)
    {
        float time = 0f;
        fadeCanvas.enabled = true;

        while (time <= interval)
        {
            float fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            fadeImage.color = new Color(0f, 0f, 0f, fadeAlpha);
            time += Time.deltaTime;
            yield return null;
        }

        yield return SceneManager.LoadSceneAsync(sceneName);
        time = 0f;

        while (time <= interval)
        {
            float fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
            fadeImage.color = new Color(0f, 0f, 0f, fadeAlpha);
            time += Time.deltaTime;
            yield return null;
        }

        fadeCanvas.enabled = false;
    }
}