using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    private void OnTriggerEnter(Collider other)
    {
        SoundManager.Instance.PlaySound(_clip);
    }
}
