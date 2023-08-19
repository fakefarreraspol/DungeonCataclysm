using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform PlayerPos;
    [SerializeField] private float cameraDistance = -10;
    // Start is called before the first frame update
    private void Start()
    {
        PlayerPos = FindObjectOfType<Character>().transform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = new Vector3(PlayerPos.position.x, PlayerPos.position.y, cameraDistance);
    }
}
