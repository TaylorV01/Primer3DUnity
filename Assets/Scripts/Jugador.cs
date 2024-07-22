using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

public class Jugador : MonoBehaviourPunCallbacks
{
    public float velocidadMov = 5.0f;
    public float velocidadRot = 200.0f;
    private Animator animator;
    private Rigidbody rb;
    private bool isGrounded = true;
    private float previousY;
    public float x, y;
    [SerializeField] private CinemachineVirtualCamera vc;
    [SerializeField] private AudioListener listener;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        if (animator == null)
        {
            Debug.LogError("Animator component is missing on the player object.");
        }

        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing on the player object.");
        }

        previousY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            listener.enabled = true;
            vc.Priority = 1;
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            transform.Rotate(0, x * Time.deltaTime * velocidadRot, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocidadMov);

            animator.SetFloat("ValX", x);
            animator.SetFloat("ValY", y);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(Vector3.up * 350, ForceMode.Impulse);
                isGrounded = false;
                animator.SetBool("IsGrounded", false);
                animator.SetBool("IsJumping", true);
                StartCoroutine(ResetJumpingBool());
            }

            if (!isGrounded && rb.velocity.y < 0)
            {
                animator.SetBool("IsFalling", true);
            }
            else
            {
                animator.SetBool("IsFalling", false);
            }
        }
        else
        {
            vc.Priority = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsGrounded", true);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("IsGrounded", false);
        }
    }

    private IEnumerator ResetJumpingBool()
    {
        yield return new WaitForSeconds(0.52f);
        animator.SetBool("IsJumping", false);
    }
}
