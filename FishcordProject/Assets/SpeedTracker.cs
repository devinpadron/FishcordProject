using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTracker : MonoBehaviour
{
    public Rigidbody player; 
    public GunMechanic gun;
    public Text speedText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        int bulletsLeft = gun.getBulletsLeft();

        string text = bulletsLeft.ToString() + '/' + gun.magazineSize.ToString();

        speedText.text = text;
    }
}
