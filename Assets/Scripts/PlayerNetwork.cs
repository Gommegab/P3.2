using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;

public class PlayerNetwork : NetworkBehaviour
{

    private void Update()
    {
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.Space)&&CanJump())
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0,300f,0));

        }
        this.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * 6f * Time.deltaTime;

    }

    private bool CanJump() {
        return transform.position.y <= 1f;
    }

}
