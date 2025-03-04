using UnityEngine;

public class RotateObject : IlyaScript
{
    [SerializeField]
    private float rotationSpeed = 10f;  

    [SerializeField]
    private Vector3 rotationAngle = new Vector3(90f, 0f, 0f); 

    private bool isRotating = false;
    private float totalRotationTime;
    private Vector3 startRotation;
    private Vector3 targetRotation;

    private void Start()
    {
        startRotation = transform.eulerAngles;
        targetRotation = startRotation + rotationAngle;
    }

    public override void Use()
    {
        if (!isRotating)
        {
            isRotating = true;
            totalRotationTime = Vector3.Distance(startRotation, targetRotation) / rotationSpeed;
            StartCoroutine(RotateCoroutine());
        }
    }

    private System.Collections.IEnumerator RotateCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < totalRotationTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / totalRotationTime;
            transform.eulerAngles = Vector3.Lerp(startRotation, targetRotation, t);
            yield return null;
        }
        transform.eulerAngles = targetRotation;
        isRotating = false;
    }
}
