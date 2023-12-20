using System;
using UnityEngine;

public class Skins : MonoBehaviour
{

    public ScriptableClothes _scriptableClothes;
    private PlayerMovement _plaverMov;
    private Animator _anim;

    void Start()
    {
        _plaverMov= gameObject.GetComponentInParent<PlayerMovement>();
        _anim = GetComponent<Animator>();

    }

    private void Update()
    {
        AnimatorMovement();
    }

    private void AnimatorMovement()
    {
        if (_scriptableClothes == null) { return; }
        _anim.SetFloat("Horizontal", _plaverMov.Movement.x);
        _anim.SetFloat("Vertical", _plaverMov.Movement.y);
        _anim.SetFloat("Speed", _plaverMov.Movement.sqrMagnitude);
        

    }

    public void ChangeClothes()
    {

        _anim.runtimeAnimatorController = _scriptableClothes.animator;
        //_sprite.sprite = _scriptableClothes.ItemImage;
    }
    public void UnEquipClothes()
    {
        if( _scriptableClothes == null ) { return; }
        _scriptableClothes.isEquipped = false;
        _scriptableClothes = null;
        _anim.runtimeAnimatorController = null;
    }


}



