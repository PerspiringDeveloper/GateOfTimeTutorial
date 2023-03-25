using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    public GameObject[] Gears;
    private Renderer gearRenderer;
    private float fadeValue;
    private WaitForSeconds spawnPause = new WaitForSeconds(0.4f);

    void Start()
    {
        for ( int i = 0; i < Gears.Length; i++ )
        {
            fadeValue = Mathf.Pow((11 - i) / 9.0f, 2);

            gearRenderer = Gears[i].GetComponent<Renderer>();
            gearRenderer.material.SetFloat("_Fade", fadeValue);
            gearRenderer.enabled = false;
        }
        StartCoroutine(SpawnGears());
    }

    IEnumerator SpawnGears()
    {
        for (int i = Gears.Length-1; i >= 0; i--)
        {
            yield return spawnPause;
            Gears[i].GetComponent<Renderer>().enabled = true;
        }
    }

}
