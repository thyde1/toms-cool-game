using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour
{
    public float MoveSpeed = 1;
    public GameObject Target { get; set; }
    private CharacterController characterController;

    // Use this for initialization
    void Start()
    {
        this.Target = FindObjectOfType<PlayerController>().gameObject;
        this.characterController = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            return;
        }

        var target2dPosition = new Vector3(this.Target.transform.position.x, 0, this.Target.transform.position.z);
        this.gameObject.transform.LookAt(target2dPosition);
        this.characterController.Move(this.transform.TransformVector(new Vector3(0, 0, Time.deltaTime * this.MoveSpeed)));
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (this.TryGetComponent<ObjectData>(out var objectData) && objectData.DealsDamage && hit.gameObject.TryGetComponent<DamageTaker>(out var damageTaker))
        {
            damageTaker.TakeDamage(this.gameObject, hit.point);
        }
    }
}
