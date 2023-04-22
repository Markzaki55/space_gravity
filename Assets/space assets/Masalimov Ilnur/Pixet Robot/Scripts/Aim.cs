using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{

    [SerializeField] Transform _arm;
    float _offset = -90;
    Character character;

    #region
    void Start()
    {
        character = GetComponent<Character>();
    }
    #endregion
    void Update()
    {
        var inverse = 0.0f;
        if (!character.m_facingRight)
        {
            inverse = 180.0f;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 perendicular = _arm.position + mousePos;
        Quaternion val = Quaternion.LookRotation(Vector3.forward, perendicular);
        val *= Quaternion.Euler(0, 0, _offset - inverse);
        _arm.rotation = val;

        // Limits the viewing angle
        var angle = ModularClamp(_arm.rotation.eulerAngles.z, -60f, 60f);
        _arm.rotation = Quaternion.Euler(0, 0, angle);
    }

    static public float ModularClamp(float val, float min, float max, float rangemin = -180f, float rangemax = 180f)
    {
        var modulus = Mathf.Abs(rangemax - rangemin);
        if ((val %= modulus) < 0f) val += modulus;
        return Mathf.Clamp(val + Mathf.Min(rangemin, rangemax), min, max);
    }
}
