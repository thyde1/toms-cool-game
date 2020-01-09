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

        this.characterController.Move(this.transform.InverseTransformPoint(Vector3.MoveTowards(this.transform.position, target.transform.position, Time.deltaTime * this.MoveSpeed)));
    }
}
