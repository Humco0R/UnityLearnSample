using UnityEngine;

public class CloneObjects : IlyaScript
{
    public GameObject prefab;  // префаб, который будет клонироватьс€
    public int cloneCount = 5;  // кол-во клонов
    public float distanceStep = 2f;  // рассто€ние между клонами

    [ContextMenu("«апустить клонирование")]
    public override void Use()
    {
        if (prefab != null)
        {
            for (int i = 0; i < cloneCount; i++)
            { // вычисление позиции дл€ каждого клона
                Vector3 position = transform.position + transform.right * (i + 1) * distanceStep;
                // создание клона
                Instantiate(prefab, position, transform.rotation);
            }
        }
        else
        {
            Debug.LogWarning("ѕрефаб не задан!");
        }
    }
}