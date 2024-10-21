using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_creamBread : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;
    public float changeSpeed;
    float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime*changeSpeed;
        transform.localScale = new Vector2(0.75f - (Mathf.Sin(time) * 0.25f), 1 + (Mathf.Sin(time) * 0.5f)); //1~0.5 0.5~1.5
    }

    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        time = 0;
        rigid.AddForce(Vector2.left * speed,ForceMode2D.Impulse);
    }

    private void OnDisable()
    {
        transform.localPosition = new Vector2(15, -10);
        rigid.velocity = Vector2.zero;
    }
}
