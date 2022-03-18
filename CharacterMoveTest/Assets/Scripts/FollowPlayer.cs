using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform playerTransform;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
}
