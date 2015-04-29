using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField]
    private Image colorOverlay = null;
    [SerializeField]
    private float roomFadeTime = 0.5f;

    private Action callback;
    private float startTime;
    private float startValue;
    private float targetValue;
    private bool fading;

    void Update()
    {
        if (fading)
        {
            float fraction = (Time.time - startTime) / roomFadeTime;

            float alpha = Mathf.Lerp(startValue, targetValue, fraction);
            Color newColor = new Color(0, 0, 0, alpha);
            colorOverlay.color = newColor;

            if (alpha >= 1)
            {
                fading = false;
                callback();
            }
            else if (alpha <= 0)
            {
                fading = false;
                colorOverlay.gameObject.SetActive(false);
                callback();
            }
        }
    }

    public void FadeInOverlay(Action callback)
    {
        startValue = 0;
        targetValue = 1;
        SetValues(callback);
    }
    public void FadeOutOverlay(Action callback)
    {
        startValue = 1;
        targetValue = 0;
        SetValues(callback);
    }

    private void SetValues(Action callback)
    {
        this.callback = callback;
        colorOverlay.gameObject.SetActive(true);
        startTime = Time.time;
        fading = true;
    }
}