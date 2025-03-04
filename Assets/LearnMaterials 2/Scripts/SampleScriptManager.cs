using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScriptManager : MonoBehaviour
{

    private List<SampleScript> sampleScripts = new List<SampleScript>();

    void Start()
    {
        sampleScripts.AddRange(FindObjectsOfType<SampleScript>());
    }

    [ContextMenu("Активировать скрипт")]
    public void UseForAll()
    {
        foreach (var sampleScript in sampleScripts)
        {
            sampleScript.Use();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
