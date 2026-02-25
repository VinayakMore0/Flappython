using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GravityFlipper : MonoBehaviour
{
    [Header("Flip Timing")]
    public float minInterval = 3f;
    public float maxInterval = 7f;

    [Header("Warning UI")]
    public Image flashOverlay;
    public Image arrowImage;
    public TextMeshProUGUI arrowText;

    private float defaultGravityY = -9.81f;

    void Start()
    {
        Physics2D.gravity = new Vector2(0, defaultGravityY);
        if (flashOverlay) flashOverlay.gameObject.SetActive(false);
        if (arrowImage) arrowImage.gameObject.SetActive(false);
        if (arrowText) arrowText.gameObject.SetActive(false);
        StartCoroutine(FlipGravityRoutine());
    }

    IEnumerator FlipGravityRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime - 1f);

            bool nextGravityIsDown = Physics2D.gravity.y > 0;
            StartCoroutine(ShowWarning(nextGravityIsDown));

            yield return new WaitForSeconds(1f);

            Physics2D.gravity = new Vector2(0, -Physics2D.gravity.y);
        }
    }

    IEnumerator ShowWarning(bool gravityGoingDown)
    {
        // --- Setup text and image together ---
        if (arrowText)
        {
            arrowText.text = gravityGoingDown ? "GRAVITY FLIPPING!" : "GRAVITY FLIPPING!";
            arrowText.gameObject.SetActive(true);
            arrowText.transform.localScale = Vector3.one;
        }

        if (arrowImage)
        {
            arrowImage.gameObject.SetActive(true);
            Color c = arrowImage.color;
            arrowImage.color = new Color(c.r, c.g, c.b, 1f);
        }

        // --- Phase 1 (0 to 0.4s): Arrow rotates + text bounces ---
        float targetZ = gravityGoingDown ? 180f : 0f;
        float startZ = arrowImage ? arrowImage.transform.eulerAngles.z : 0f;
        float elapsed = 0f;

        while (elapsed < 0.4f)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / 0.4f;

            // Smooth arrow rotation
            if (arrowImage)
            {
                float angle = Mathf.LerpAngle(startZ, targetZ, t);
                arrowImage.transform.rotation = Quaternion.Euler(0, 0, angle);
            }

            // Text bounces in scale
            if (arrowText)
            {
                float scale = 1f + Mathf.Sin(t * Mathf.PI) * 0.25f;
                arrowText.transform.localScale = Vector3.one * scale;
            }

            yield return null;
        }

        if (arrowImage)
            arrowImage.transform.rotation = Quaternion.Euler(0, 0, targetZ);
        if (arrowText)
            arrowText.transform.localScale = Vector3.one;

        // --- Phase 2 (0.4s to 0.7s): Flash overlay pulse ---
        if (flashOverlay)
        {
            flashOverlay.gameObject.SetActive(true);
            Color flashColor = new Color(1f, 0.3f, 0f);
            elapsed = 0f;
            while (elapsed < 0.6f)
            {
                elapsed += Time.deltaTime;
                float alpha = Mathf.Sin((elapsed / 0.6f) * Mathf.PI) * 0.35f;
                flashOverlay.color = new Color(flashColor.r, flashColor.g, flashColor.b, alpha);
                yield return null;
            }
            flashOverlay.color = new Color(flashColor.r, flashColor.g, flashColor.b, 0f);
            flashOverlay.gameObject.SetActive(false);
        }

        // --- Phase 3: Hold for a moment then fade both out together ---
        yield return new WaitForSeconds(0.2f);

        elapsed = 0f;
        while (elapsed < 0.3f)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / 0.3f);

            if (arrowImage)
            {
                Color c = arrowImage.color;
                arrowImage.color = new Color(c.r, c.g, c.b, alpha);
            }

            if (arrowText)
            {
                arrowText.alpha = alpha;
            }

            yield return null;
        }

        // Reset everything
        if (arrowImage)
        {
            Color c = arrowImage.color;
            arrowImage.color = new Color(c.r, c.g, c.b, 1f);
            arrowImage.gameObject.SetActive(false);
        }
        if (arrowText)
        {
            arrowText.alpha = 1f;
            arrowText.transform.localScale = Vector3.one;
            arrowText.gameObject.SetActive(false);
        }
    }

    void OnDestroy()
    {
        Physics2D.gravity = new Vector2(0, defaultGravityY);
    }
}