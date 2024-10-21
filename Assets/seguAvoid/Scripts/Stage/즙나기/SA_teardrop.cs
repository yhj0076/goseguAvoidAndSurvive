﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_teardrop : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SA_HealthController player = collision.GetComponent<SA_HealthController>();

            if (player != null)
            {
                player.Damaged(damage);
            }
        }
    }
}
