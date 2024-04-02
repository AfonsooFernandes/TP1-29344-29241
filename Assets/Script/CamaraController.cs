using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    private void Update()
    {
        //Debug.Log(playerTransform.position);

        transform.position = playerTransform.position + offset;
    }
}
