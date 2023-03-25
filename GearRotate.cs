using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotate : MonoBehaviour
{
    private WaitForSeconds rotatePause = new WaitForSeconds(0.8f);
    private float rotationAmount = 30.0f;
    private float nudgeAmount = 3.0f;
    private float rotationSpeed = 35.0f;
    private float degreesLeft;
    private float thisRotation;
    void Start()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            degreesLeft = nudgeAmount;
            while (degreesLeft > 0)
            {
                thisRotation = Mathf.Min(Time.deltaTime * rotationSpeed, degreesLeft);
                transform.Rotate(new Vector3(-thisRotation, 0, 0));
                degreesLeft -= thisRotation;
                yield return null;
            }

            degreesLeft = rotationAmount + (2 * nudgeAmount);
            while (degreesLeft > 0)
            {
                thisRotation = Mathf.Min(Time.deltaTime * rotationSpeed, degreesLeft);
                transform.Rotate(new Vector3(thisRotation, 0, 0));
                degreesLeft -= thisRotation;
                yield return null;
            }

            degreesLeft = nudgeAmount;
            while (degreesLeft > 0)
            {
                thisRotation = Mathf.Min(Time.deltaTime * rotationSpeed, degreesLeft);
                transform.Rotate(new Vector3(-thisRotation, 0, 0));
                degreesLeft -= thisRotation;
                yield return null;
            }

            yield return rotatePause;
        }
    }
}
