using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTMP : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(StartDestroyTimer()); 
    }

    private void Update()
    {
        transform.Translate(Vector3.up * 3 * Time.deltaTime);
    }


    private IEnumerator StartDestroyTimer()
    {
        yield return new WaitForSeconds(1.5f);

        gameObject.SetActive(false);
    }
}
