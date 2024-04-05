using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Sniper : Gun
{
    [SerializeField] GameObject sniperBlast; //to get particle effect
    [SerializeField] CinemachineVirtualCamera zoomCam;
    public override bool AttemptFire()
    {
        if (!base.AttemptFire())
            return false;

        var b = Instantiate(bulletPrefab, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        b.GetComponent<Projectile>().Initialize(20, 150, 1.5f, 20, null); // version without special effect

        Instantiate(sniperBlast, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);

        AudioSource gunShot = gameObject.AddComponent<AudioSource>(); //to get audio clip
        gunShot.PlayOneShot((AudioClip)Resources.Load("Gun Shot")); //Plays audio clip

        anim.SetTrigger("shoot");
        elapsed = 0;
        ammo -= 1;

        zoomCam.m_Lens.FieldOfView = 60;
        return true;
    }

    public override bool AttemptAltFire()
    {
        if (!base.AttemptAltFire())
        {
            return false;
        }

        zoomCam.m_Lens.FieldOfView = 15;
        return true;
    }
    // example function, make hit enemy fly upward
    void DoThing(HitData data)
    {
        Vector3 impactLocation = data.location;

        var colliders = Physics.OverlapSphere(impactLocation, 1);
        foreach (var c in colliders)
        {
            if (c.GetComponent<Rigidbody>())
            {
                c.GetComponent<Rigidbody>().AddForce(Vector3.up * 20, ForceMode.Impulse);
            }
        }
    }
}
