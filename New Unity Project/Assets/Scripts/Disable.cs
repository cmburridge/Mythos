using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DisableThis());
    }

    private IEnumerator DisableThis()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }
}
