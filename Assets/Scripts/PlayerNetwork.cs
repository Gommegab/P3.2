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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0,1,0));
        }
        this.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * 6f * Time.deltaTime;

    }


    [ServerRpc]
    void SubmitPositionRequestServerRpc(Vector3 move)
    {
        //actualizamos el servidor
        transform.position += move * 6f * Time.deltaTime;
        //le decimos que actualice el cliente
        // SubmitPositionRequestClientRPC(move);

    }
    [ClientRpc]
    void SubmitPositionRequestClientRPC(Vector3 move)
    {
        //actualizamos el cliente
        transform.position += move * 6f * Time.deltaTime;
    }

}
