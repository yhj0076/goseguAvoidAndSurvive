using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_sky_Big : MonoBehaviour
{
    float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.localPosition = new Vector2(transform.localPosition.x,14.73f-13.6f*Mathf.Sin(time));
        if(time >= Mathf.PI)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        time = 0;
    }

    private void OnDisable()
    {
        transform.localPosition = new Vector2(transform.localPosition.x,14.73f);
    }
}
