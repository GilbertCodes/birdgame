using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerMovement : MonoBehaviour
{
    public PlayerController2D controller;
    public PhotonView view;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        view = GetComponent<PhotonView>();

    }
    void Update()
    {
        if(view.IsMine) 
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
            if (Input.GetButtonDown("Crouch")) 
            {
                crouch = true;
            } else if (Input.GetButtonUp("Crouch")) {
                crouch = false;
            }
        }

    }

    void FixedUpdate()
    {
        if (view.IsMine) {
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }
 
    }
}
