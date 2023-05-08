using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerNetwork : NetworkBehaviour
{
    private void Update()
    {
        if (!IsOwner) return;

        if (!NetworkManager.Singleton.IsServer)
        {
            // si no es servidor le decimos que actualice el servidor
            SubmitPositionRequestServerRpc(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));

        }
        else
        {
            //si es servidor lo actualizamo
            SubmitPositionRequestClientRPC(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        }

    }


    [ServerRpc]
    void SubmitPositionRequestServerRpc(Vector3 move)
    {
        //actualizamos el servidor
        transform.position += move * 6f * Time.deltaTime;
        //le decimos que actualice el cliente
        SubmitPositionRequestClientRPC(move);

    }
    [ClientRpc]
    void SubmitPositionRequestClientRPC(Vector3 move)
    {
        //actualizamos el cliente
        transform.position += move * 6f * Time.deltaTime;
    }

}
