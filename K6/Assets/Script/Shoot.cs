using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    
    public GameObject projectile;
    public Transform launchOffset;
    public int delay = 2;

    void Start() {
        StartCoroutine(ShootCoroutine());
    }

    IEnumerator ShootCoroutine() {
        while (true) {
            Instantiate(this.projectile, this.launchOffset.position, transform.rotation);
            yield return new WaitForSeconds(this.delay);
        }
    }

}
