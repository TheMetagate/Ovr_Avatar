using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveController : MonoBehaviour
{
    [SerializeField] private GameObject _avatar;

    public void ChangeIsActive()
    {
        _avatar.SetActive(!_avatar.activeInHierarchy);
    }
}
