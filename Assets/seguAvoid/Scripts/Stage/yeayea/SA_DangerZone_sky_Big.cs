using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_DangerZone_sky_Big : MonoBehaviour
{
    void Update()
    {
        if (transform.parent.GetChild(6).gameObject.activeSelf == true)
        {
            transform.gameObject.SetActive(false);
        }
    }
}
