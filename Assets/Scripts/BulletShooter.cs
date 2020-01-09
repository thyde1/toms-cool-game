using UnityEngine;
using System.Collections;

public class BulletShooter : MonoBehaviour
{
    public GameObject Bullet;
    public float ReloadSpeed = 0.1f;

    private float nextShotDelay = 0;

    // Update is called once per frame
    void Update()
    {
        this.nextShotDelay -= Time.deltaTime;
        if (Input.GetMouseButton(0) && this.nextShotDelay <= 0)
        {
            Instantiate(this.Bullet, this.transform.position, this.transform.rotation);
            this.nextShotDelay = this.ReloadSpeed;
        }
    }
}
