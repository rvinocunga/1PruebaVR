using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public GameObject bloodParticles;
    public AudioClip hitSound;

    AudioSource audioSource;

    void Awake (){
        audioSource = GetComponent<AudioSource> ();
    }

    void OnEnable() {
        //Health.OnDamaged += HandleOnDamaged;
    }

    void OnDisabled () {
        //Health.OnDamaged -= HandleOnDamaged;
    }

    void HandleOnDamaged (GameObject go) {
        GameObject.Instantiate(bloodParticles, go.transform.position, Quaternion.identity);
        audioSource.PlayOneShot (hitSound);
    }
}
