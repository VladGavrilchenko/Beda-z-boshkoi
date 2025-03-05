using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeMagnitude = 0f;
    public bool isShaking { get; private set; } = false;
    private int shakeRequests = 0;
    private Vector3 originalPosition;
    private float currentShakeDuration = 0f;

    private void Update()
    {
        if (shakeRequests > 0 && currentShakeDuration > 0)
        {
            currentShakeDuration -= Time.deltaTime;
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;
            transform.localPosition = originalPosition + new Vector3(x, y, 0);
        }
        else if (shakeRequests > 0 && currentShakeDuration <= 0)
        {
            shakeRequests = 0;
            transform.localPosition = originalPosition;
            isShaking = false;
        }
    }

    public void StartShake()
    {
        if (shakeRequests == 0)
        {
            originalPosition = transform.localPosition;
        }

        shakeRequests++;
        isShaking = true;
        currentShakeDuration = shakeDuration;
    }

    private void OnDisable()
    {
        shakeRequests = 0;
        currentShakeDuration = 0;
        transform.localPosition = originalPosition;
        isShaking = false;
    }
}
