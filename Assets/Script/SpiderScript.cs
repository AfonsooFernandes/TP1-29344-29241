using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    // Variável estática para armazenar o aumento de velocidade
    private static float aumentoDeVelocidade = 0f;

    public float velocidade = 5f; // Velocidade base do movimento
    public float limiteEsquerdo = -20f; // Limite do lado esquerdo
    public float limiteDireito = 20f; // Limite do lado direito
    private bool movendoParaDireita = true; // Flag para direção do movimento

    void Start()
    {
        // Adiciona o aumento de velocidade à velocidade base
        velocidade += aumentoDeVelocidade;
    }
    void Update()
    {

        // Se movendo para a direita e ultrapassou o limite direito
        if (transform.position.x >= limiteDireito && movendoParaDireita)
        {
            movendoParaDireita = false; // Muda a direção
        }
        // Se movendo para a esquerda e ultrapassou o limite esquerdo
        else if (transform.position.x <= limiteEsquerdo && !movendoParaDireita)
        {
            movendoParaDireita = true; // Muda a direção
        }

        // Move o objeto
        if (movendoParaDireita)
        {
            transform.Translate(Vector3.right * velocidade * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * velocidade * Time.deltaTime);
        }
    }



    // Método estático para definir o aumento de velocidade
    public static void SetAumentoDeVelocidade(float aumento)
    {
        aumentoDeVelocidade += aumento;
    }
}



