using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    private InteractiveBox next;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>(); // Добавляем LineRenderer
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Для линии без текстуры
        lineRenderer.startColor = Color.green;
        lineRenderer.endColor = Color.green;
    }

    public void AddNext(InteractiveBox box)
    {
        next = box;
    }

    private void Update()
    {
        if (next != null)
        {
            // Отображаем линию между объектами в игровом режиме
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, next.transform.position);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, (next.transform.position - transform.position).normalized, out hit, Vector3.Distance(transform.position, next.transform.position)))
            {
                ObstacleItem obstacle = hit.collider.GetComponent<ObstacleItem>();
                if (obstacle != null)
                {
                    obstacle.GetDamage(Time.deltaTime);
                }
            }
        }
    }
}
