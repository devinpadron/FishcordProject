using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAI : MonoBehaviour
{

    [Header("Stats")]
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int dmg)
    {
        //Take dmg
        health -= dmg;
        if (health <= 0)
        {
            print("FUCKING DEAD!!!!!!!!!!");
            Destroy(this.gameObject);
        }
    }
}
