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

    // Verifica se a tecla de espaço foi pressionada para acionar o pulo
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
        // Aplica uma força vertical para fazer o personagem pular
        verticalSpeed = jumpForce;
        // Define a animação de "Jumping" como verdadeira
        animator.SetBool("Jumping", true);

        // Move o personagem um pouco para frente durante o pulo
        character.Move(transform.forward * 2f * velocidade * Time.deltaTime);
    }
    else
    {
        // Define a animação de "Jumping" como falsa
        animator.SetBool("Jumping", false);
    }
}void FixedUpdate()
{
    // Define a direção de movimento com base nas teclas pressionadas
    Vector3 moveDirection = Vector3.zero;

    if (Input.GetKey(KeyCode.A))
    {
        moveDirection += Vector3.left;
    }
    if (Input.GetKey(KeyCode.D))
    {
        moveDirection += Vector3.right;
    }
    if (Input.GetKey(KeyCode.W))
    {
        moveDirection += Vector3.forward;
    }
    if (Input.GetKey(KeyCode.S))
    {
        moveDirection += Vector3.back;
    }

    // Normaliza a direção de movimento para evitar movimento mais rápido na diagonal
    if (moveDirection != Vector3.zero)
    {
        moveDirection.Normalize();
    }

    // Calcula a rotação do personagem para olhar na direção do movimento
    if (moveDirection != Vector3.zero)
    {
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.fixedDeltaTime * 100f);
    }

    // Move o personagem na direção dos inputs
    character.Move(moveDirection * velocidade * Time.fixedDeltaTime);

    // Define a animação de "Running" com base na magnitude da direção de movimento
    animator.SetBool("Running", moveDirection.magnitude > 0);

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
        animator.SetBool("Jumping", true);

        // Move o personagem um pouco para frente durante o pulo
        character.Move(transform.forward * 2f * velocidade * Time.fixedDeltaTime);
    }
    else
    {
        // Define a animação de "Jumping" como falsa
        animator.SetBool("Jumping", false);
    }

    // Aplica a velocidade vertical ao movimento
    character.Move(Vector3.up * verticalSpeed * Time.fixedDeltaTime);
}


}
