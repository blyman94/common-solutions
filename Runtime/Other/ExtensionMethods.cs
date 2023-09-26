using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blyman94.CommonSolutions
{
    public static class ExtensionMethods
    {
        #region CanvasGroup Methods
        public static IEnumerator FadeIn(this CanvasGroup canvasGroup,
            float fadeDuration)
        {
            yield return canvasGroup.FadeIn(fadeDuration, 1.0f, 
                canvasGroup.blocksRaycasts, canvasGroup.interactable);
        }
        public static IEnumerator FadeIn(this CanvasGroup canvasGroup,
            float fadeDuration, float maxAlpha)
        {
            yield return canvasGroup.FadeIn(fadeDuration, maxAlpha, 
                canvasGroup.blocksRaycasts, canvasGroup.interactable);
        }
        public static IEnumerator FadeIn(this CanvasGroup canvasGroup,
            float fadeDuration, float maxAlpha, bool blocksRaycastsIn, 
            bool interactableIn)
        {
            if (maxAlpha <= 0.0f)
            {
                maxAlpha = 0.001f;
            }

            float elapsedTime = (canvasGroup.alpha / maxAlpha) * fadeDuration;
            while (elapsedTime < fadeDuration)
            {
                canvasGroup.alpha = Mathf.Lerp(0.0f,
                    maxAlpha, elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            canvasGroup.alpha = maxAlpha;
            canvasGroup.blocksRaycasts = blocksRaycastsIn;
            canvasGroup.interactable = interactableIn;
        }
        public static IEnumerator FadeOut(this CanvasGroup canvasGroup,
            float fadeDuration)
        {
            yield return canvasGroup.FadeOut(fadeDuration,
                canvasGroup.blocksRaycasts, canvasGroup.interactable);
        }
        public static IEnumerator FadeOut(this CanvasGroup canvasGroup,
            float fadeDuration, bool blocksRaycastsOut, bool interactableOut)
        {
            float elapsedTime = (1 - canvasGroup.alpha) * fadeDuration;
            while (elapsedTime < fadeDuration)
            {
                canvasGroup.alpha = Mathf.Lerp(1.0f,
                    0.0f, elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            canvasGroup.alpha = 0.0f;
            canvasGroup.blocksRaycasts = blocksRaycastsOut;
            canvasGroup.interactable = interactableOut;
        }
        #endregion
    }
}
