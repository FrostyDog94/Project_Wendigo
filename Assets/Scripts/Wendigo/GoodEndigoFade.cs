using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodEndigoFade : MonoBehaviour
{
    public float fadeSpeed = 0.5f;

    private bool isFading = false;

    void Update()
    {
        if (isFading) {
            foreach (Material mat in this.GetComponentsInChildren<Renderer>()[0].materials) {
                Color color = mat.color;
                float newAlpha = color.a - (fadeSpeed * Time.deltaTime);

                Color newColor = new Color(color.r, color.g, color.b, newAlpha);
                mat.color = newColor;

                if (newColor.a < 0) {
                    isFading = false;
                    this.GetComponentsInChildren<Renderer>()[0].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                }
            }
        }
    }

    public void StartFade() 
    {
        isFading = true;
    }
}
