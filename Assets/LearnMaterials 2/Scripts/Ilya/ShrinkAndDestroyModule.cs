using System.Collections;
using UnityEngine;

public class ShrinkAndDestroyModule : IlyaScript
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float shrinkSpeed = 2f;

    [SerializeField]
    private float targetShrinkScale = 0.1f; 

    public override void Use()
    {
        StartCoroutine(ShrinkAndDestroyChildren());
    }

    private IEnumerator ShrinkAndDestroyChildren()
    {
        foreach (Transform child in target)
        {
            Vector3 originalScale = child.localScale;
            Vector3 targetScale = originalScale * targetShrinkScale; 

            float t = 0;

            while (t < 1)
            {
                t += Time.deltaTime * shrinkSpeed;
                child.localScale = Vector3.Lerp(originalScale, targetScale, t);
                yield return null;
            }

            Destroy(child.gameObject);
        }
    }
}
