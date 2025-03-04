using System.Collections.Generic;
using UnityEngine;

public class IlyaScript2 : MonoBehaviour
{
    private List<IlyaScript> ilyaScripts = new List<IlyaScript>();

    private void Start()
    {
        ilyaScripts.AddRange(FindObjectsOfType<IlyaScript>());
    }
    [ContextMenu("Activate All Use")]
    public void UseForAll()
    {
        foreach (var ilyaScript in ilyaScripts)
        {
            ilyaScript.Use();
        }
    }
}
