using UnityEngine;
using System.Collections;

public class BulletShooter : MonoBehaviour
{
    public GameObject Bullet;
    public AudioClip FiringSound;
    public float ReloadSpeed = 0.1f;

    private float nextShotDelay = 0;

    // Update is called once per frame
    void Update()
    {
        this.nextShotDelay -= Time.deltaTime;
        if (Input.GetMouseButton(0) && this.nextShotDelay <= 0)
        {
            AudioSource.PlayClipAtPoint(this.FiringSound, this.transform.position);
            Instantiate(this.Bullet, this.transform.position, this.transform.rotation);
            this.nextShotDelay = this.ReloadSpeed;
        }
    }
}
