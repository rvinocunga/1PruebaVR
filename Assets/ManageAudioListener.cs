using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 

public class ManageAudioListener : MonoBehaviourPunCallbacks
{
    void Start()
    {
        if (photonView.IsMine)
        {
            // Este es el jugador local, activar el AudioListener
            GetComponent<AudioListener>().enabled = true;
        }
        else
        {
            // Este no es el jugador local, desactivar el AudioListener
            GetComponent<AudioListener>().enabled = false;
        }
    }
}


