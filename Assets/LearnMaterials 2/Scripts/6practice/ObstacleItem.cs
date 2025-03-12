using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    [Range(0f, 1f)]
    public float currentValue = 1f; // "Здоровье" препятствия
    public UnityEvent onDestroyObstacle;
    private Renderer obstacleRenderer;

    private void Start()
    {
        obstacleRenderer = GetComponent<Renderer>();
        UpdateColor();
    }

    [ContextMenu("Apply Damage")]
    public void ApplyDamageTest()
    {
        GetDamage(0.2f); // Наносит 20% урона
    }

    public void GetDamage(float value)
    {
        currentValue = Mathf.Clamp01(currentValue - value);
        UpdateColor();

        if (currentValue <= 0)
        {
            onDestroyObstacle?.Invoke();
            Destroy(gameObject);
        }
    }

    private void UpdateColor()
    {
        if (obstacleRenderer != null)
        {
            Color newColor = Color.Lerp(Color.red, Color.white, currentValue);
            obstacleRenderer.material.color = newColor;
        }
    }
}
