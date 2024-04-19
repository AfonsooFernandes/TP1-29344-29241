using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private Vector3 inputs;
    private float velocidade = 10f;
    private float jumpForce = 7.5f;
    private float gravity = 9.81f;
    private float verticalSpeed = 0f;
    private bool isGrounded; // Variável para verificar se o personagem está no chão

    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtém as entradas do jogador
        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        // Verifica se o personagem está se movendo
        if (inputs != Vector3.zero)
        {
            // Calcula a direção de movimento com base nas entradas do jogador
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            // Move o personagem na direção dos inputs
            character.Move(moveDirection * velocidade * Time.fixedDeltaTime);

            // Define a animação de "Running" como verdadeira
            animator.SetBool("Running", true);

            // Calcula a rotação do personagem diretamente
            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.fixedDeltaTime * 100f);
            }
        }
        else
        {
            // Define a animação de "Running" como falsa
            animator.SetBool("Running", false);
        }

        // Verifica se o personagem está no chão
        isGrounded = character.isGrounded;

        // Aplica gravidade
        if (!isGrounded)
        {
            verticalSpeed -= gravity * Time.fixedDeltaTime;
        }
        else
        {
            verticalSpeed = 0f; // Reinicia a velocidade vertical quando o personagem está no chão
        }

        // Verifica se a tecla de espaço foi pressionada para acionar o pulo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Aplica uma força vertical para fazer o personagem pular
            verticalSpeed = jumpForce;
            // Define a animação de "Jumping" como verdadeira
            animator.SetTrigger("Jumping");

            // Move o personagem um pouco para frente durante o pulo
            character.Move(transform.forward * 2f * velocidade * Time.fixedDeltaTime);
        }
        

        // Aplica a velocidade vertical ao movimento
        character.Move(Vector3.up * verticalSpeed * Time.fixedDeltaTime);
    }
}
