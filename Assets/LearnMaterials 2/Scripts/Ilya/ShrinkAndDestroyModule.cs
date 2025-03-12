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
        foreach (Transform child in target)
        {
            StartCoroutine(ShrinkObject(child));
        }
    }

    private IEnumerator ShrinkObject(Transform obj)
    {
        Vector3 originalScale = obj.localScale;
        Vector3 targetScale = originalScale * targetShrinkScale;

        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * shrinkSpeed;
            obj.localScale = Vector3.Lerp(originalScale, targetScale, t);
            yield return null;
        }

        Destroy(obj.gameObject);
    }
}
