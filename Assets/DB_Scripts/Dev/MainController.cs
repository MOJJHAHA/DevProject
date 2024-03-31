using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private static MainController _instance;
    public static MainController Instance
    {
        get => _instance;
    }
    CommonObject lastHitObject;

    private void Awake()
    {
        _instance = this;
    }

    bool _isHit;
    public bool isHit
    {
        get => _isHit;
        set => _isHit = value;
    }
    public void SetHit(bool _isHit, CommonObject _hit = null)
    {
        isHit = _isHit;
        if (_hit == null) return;
        OnRecover(_hit);
    }
    public bool IsHitObject()
    {
        return isHit;
    }

    public void OnRecover(CommonObject _nowHitObject)
    {
        if (lastHitObject == null)
        {
            lastHitObject = _nowHitObject;
            return;
        }
        if (_nowHitObject == lastHitObject) return;
        lastHitObject.Recover();
        lastHitObject = _nowHitObject;
    }
}
