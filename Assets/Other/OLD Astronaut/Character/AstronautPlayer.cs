using UnityEngine;
using System.Collections;

namespace AstronautPlayer
{

    public class AstronautPlayer : MonoBehaviour
    {

        private Animator anim;
        private CharacterController controller;
        float ver;
        public float speed = 600.0f;
        public float turnSpeed = 400.0f;
        private Vector3 moveDirection = Vector3.zero;
        public float gravity = 20.0f;
        public float jump = 10;
        bool isjump;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            anim = gameObject.GetComponentInChildren<Animator>();
        }

        void FixedUpdate()
        {

            if (controller.isGrounded)
            {
                moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
                if (Input.GetKey(KeyCode.Space))
                {
                    anim.SetBool("IsJump", true);
                    moveDirection.y += Mathf.Sqrt(jump * gravity);
                }

            }
        }
        void Update()
        {
            ver = Input.GetAxis("Vertical");
            if (ver != 0)
            {
                
                anim.SetBool("Run", true);
                anim.SetBool("IsJump", false);
            }
            else
            {
                anim.SetBool("Run", false);
            }
            if (controller.isGrounded && moveDirection.y < 0)   
            {
                anim.SetBool("IsJump", false);
                moveDirection.y = 0f;
            }

            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
            controller.Move(moveDirection * Time.deltaTime);
            moveDirection.y -= gravity * Time.deltaTime;
        }
    }


}
