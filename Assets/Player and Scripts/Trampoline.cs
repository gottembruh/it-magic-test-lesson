using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 jump = new Vector3(0, jumpForce, 0);
            rigidbody.AddForce(jump, ForceMode.Impulse);
        }
    }
}
