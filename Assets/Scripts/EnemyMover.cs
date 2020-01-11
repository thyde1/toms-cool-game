using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour
{
    public float MoveSpeed = 1;
    private GameObject target;
    private CharacterController characterController;

    // Use this for initialization
    void Start()
    {
        this.target = FindObjectOfType<PlayerController>().gameObject;
        this.characterController = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        var this2dPosition = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        var target2dPosition = new Vector3(this.target.transform.position.x, 0, this.target.transform.position.z);
        var vectorTowardsTarget = this.transform.InverseTransformPoint(Vector3.MoveTowards(this2dPosition, target2dPosition, Time.deltaTime * this.MoveSpeed));
        this.characterController.Move(vectorTowardsTarget);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (this.TryGetComponent<ObjectData>(out var objectData) && objectData.DealsDamage && hit.gameObject.TryGetComponent<DamageTaker>(out var damageTaker))
        {
            damageTaker.TakeDamage(this.gameObject);
        }
    }
}
