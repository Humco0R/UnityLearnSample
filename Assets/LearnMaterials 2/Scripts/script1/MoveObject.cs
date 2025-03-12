using UnityEngine;

public class MoveObject : IlyaScript
{
    public Vector3 targetPosition = new Vector3(3, 0, 0);  // ÖÅËÜ
    private float speed = 1.0f;  // Ñêîðîñòü ïåðåìåùåíèÿ
    private Vector3 startPosition;
    private bool isMoving = false;
    private float startTime;

    public override void Use()
    {
        startPosition = transform.position;  // ÍÀ× ÏÎÇÈÖÈß
        startTime = Time.time;  
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / Vector3.Distance(startPosition, targetPosition);
            transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);

            if (fractionOfJourney >= 1.0f)
            {
                isMoving = false;
            }
        }
    }
}
