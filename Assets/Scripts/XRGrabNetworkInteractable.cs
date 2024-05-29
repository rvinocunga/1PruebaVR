using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class XRGrabNetworkInteractable : XRGrabInteractable
{
    private PhotonView photonView;

    // Awake se llama cuando la instancia del script se carga
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }


    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        photonView.RequestOwnership();
        base.OnSelectExiting(args);
    }
}
