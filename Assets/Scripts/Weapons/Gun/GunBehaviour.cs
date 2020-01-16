using UnityEngine;
using System.Collections;

public class GunBehaviour : MonoBehaviour, WeaponBehaviour
{
    public GameObject Bullet;
    public AudioClip FiringSound;
    public float ReloadSpeed = 0.1f;

    private float nextShotDelay = 0;
    private Transform pivot;
    private PlayerController player;

    public KeyCode HotKey => KeyCode.Alpha2;

    private void Start()
    {
        this.pivot = this.GetComponentInParent<AimPivot>().transform;
        this.player = this.GetComponentInParent<PlayerController>();
    }

    public void Fire()
    {
        if (this.nextShotDelay <= 0)
        {
            AudioSource.PlayClipAtPoint(this.FiringSound, this.transform.position);
            Instantiate(this.Bullet, this.transform.position, this.transform.rotation);
            this.nextShotDelay = this.ReloadSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.nextShotDelay -= Time.deltaTime;
        this.pivot.localRotation = Quaternion.Euler(this.player.GetCameraAngle(), 0, 0);
    }
}
