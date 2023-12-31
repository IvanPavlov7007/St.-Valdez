using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Health))]
public class Hole : MonoBehaviour, Punchable
{
    TextMeshPro textMesh;
    Health _health;
    public Health health { get { if (_health == null) _health = GetComponent<Health>(); return _health; } }
    public float progress { get { return 1f - (float)health.amount / health.maxAmount; } }

    public int hitDamage = 1;

    Bed _bed;
    Bed bed { get { if (_bed == null) _bed = GameManager.Instance.bed; return _bed; } }

    public event System.Action<Hole> onPunched;
    
    public void Punch(Vector3 position, Vector3 direction, float impulse)
    {
        if (bed.isOpen)
        {
            health.Hit(hitDamage);
            if (onPunched != null)
                onPunched(this);
        }
    }

    void Start()
    {
        textMesh = GetComponentInChildren<TextMeshPro>();
        health.onDeath += HideCollider;
    }

    void HideCollider()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (textMesh != null)
            textMesh.text = health.amount.ToString();
    }
}
