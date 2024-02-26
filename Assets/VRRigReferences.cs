using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRigReferences : MonoBehaviour
{
    public static VRRigReferences Singleton; 

    public Transform root;
    public Transform head;
    public Transform rightHand;
    public Transform leftHand;

    public void Awake()
    {
        Singleton = this;
    }


}
