using UnityEngine;

public class InteractiveRaycast : MonoBehaviour
{
    public GameObject prefab;  // Префаб куба с компонентом InteractiveBox
    private InteractiveBox currentInteractiveBox;  // Текущий объект с InteractiveBox, с которым работаем

    void Update()
    {
        // Проверка, что был сделан клик мышью
        if (Input.GetMouseButtonDown(0))  // Левый клик
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // Луч из камеры на место клика

            if (Physics.Raycast(ray, out hit))
            {
                // Левый клик по объекту с тегом InteractivePlane
                if (hit.collider.CompareTag("InteractivePlane"))
                {
                    // Создаем экземпляр prefab в точке попадания луча, с учётом нормали
                    Vector3 spawnPosition = hit.point + hit.normal * 0.5f;  // Немного поднимем объект над поверхностью
                    Instantiate(prefab, spawnPosition, Quaternion.LookRotation(hit.normal));
                }
                // Левый клик по объекту с компонентом InteractiveBox
                else if (hit.collider.GetComponent<InteractiveBox>() != null)
                {
                    InteractiveBox clickedBox = hit.collider.GetComponent<InteractiveBox>();

                    // Если ещё не сохранен объект с InteractiveBox
                    if (currentInteractiveBox == null)
                    {
                        currentInteractiveBox = clickedBox;
                    }
                    else
                    {
                        // Если объект уже сохранён, то добавляем его как next
                        currentInteractiveBox.AddNext(clickedBox);
                        currentInteractiveBox = null;  // После связывания сбрасываем переменную
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1))  // Правый клик
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // Проверяем, если это объект с компонентом InteractiveBox
                InteractiveBox boxToDelete = hit.collider.GetComponent<InteractiveBox>();
                if (boxToDelete != null)
                {
                    // Удаляем объект
                    Destroy(boxToDelete.gameObject);
                }
            }
        }
    }
}
