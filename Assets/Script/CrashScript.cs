using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashScript : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 50;
    public float sidewaysForce = 1;
    public Animator animator; // Referência ao componente Animator
    private bool isGrounded; // Variável para verificar se o personagem está no chão

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // Obtendo a referência ao componente Animator
        animator.SetBool("IsRunning", true); // Inicia a animação de corrida
    }

    void Update()
    {
        // Verifica se a tecla de espaço foi pressionada e se o personagem está no chão
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

    void Jump()
    {
        // Aplica uma força vertical para fazer o personagem pular
        rb.velocity = new Vector3(rb.velocity.x, 5f, rb.velocity.z);
        animator.SetTrigger("Jumping"); // Aciona a animação de pulo
    }

    // Detecta quando o personagem entra em contato com o chão
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Detecta quando o personagem sai do contato com o chão
   
    
}
