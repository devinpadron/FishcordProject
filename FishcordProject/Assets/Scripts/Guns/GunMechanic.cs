using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;

public class GunMechanic : MonoBehaviour
{
    [Header("Gun Stats")]
    public int damage;
    public float timeBetweenShots, spread, spreadMovementMult, range, reloadTime, weaponCooldown;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    bool shooting, readyToShoot, reloading;

    [Header("Effects")]
    public GameObject muzzleFlash;
    //public GameObject bulletHole;
    public Shaker myShaker;
    public ShakePreset ShakePreset;
    public AudioSource Gunshot;

    [Header("Needed Functions")]
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    public Rigidbody player;

    private void Update()
    {
        MyInput();
    }

    private void Start()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    public int getBulletsLeft()
    {
        return bulletsLeft;
    }

    private void MyInput()
    {
        if (allowButtonHold)
            shooting = Input.GetKey(KeyCode.Mouse0);
        else
            shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
            Reload();

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        reloading = false;
        bulletsLeft = magazineSize;
    }

    private void Shoot()
    {
        readyToShoot = false;
        float calcSpread = spread;
        // Increase Spread when Moving
        if (player.velocity.magnitude > 0)
            calcSpread = spread * spreadMovementMult;

        // Spread
        float x = Random.Range(-calcSpread, calcSpread);
        float y = Random.Range(-calcSpread, calcSpread);

        // Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        // Raycast
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);
            
            // if (rayHit.collider.CompareTag("Enemy"))
            //     rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);
        }

        // Shake Camera
        if (myShaker != null || ShakePreset != null)
            myShaker.Shake(ShakePreset);

        // Effects
        //Instantiate(bulletHole, rayHit.point, Quaternion.FromToRotation(Vector3.forward, rayHit.normal));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        
        if (Gunshot != null)
            Gunshot.Play();

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", weaponCooldown);
        
        if(bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }
}
