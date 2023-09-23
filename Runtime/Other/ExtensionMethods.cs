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
            float elapsedTime = canvasGroup.alpha * fadeDuration;
            while (elapsedTime < fadeDuration)
            {
                canvasGroup.alpha = Mathf.Lerp(0.0f,
                    1.0f, elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            canvasGroup.alpha = 1.0f;
        }
        public static IEnumerator FadeIn(this CanvasGroup canvasGroup,
            float fadeDuration, bool blocksRaycastsIn, bool interactableIn)
        {
            float elapsedTime = canvasGroup.alpha * fadeDuration;
            while (elapsedTime < fadeDuration)
            {
                canvasGroup.alpha = Mathf.Lerp(0.0f,
                    1.0f, elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            canvasGroup.alpha = 1.0f;
            canvasGroup.blocksRaycasts = blocksRaycastsIn;
            canvasGroup.interactable = interactableIn;
        }
        public static IEnumerator FadeOut(this CanvasGroup canvasGroup,
            float fadeDuration)
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
