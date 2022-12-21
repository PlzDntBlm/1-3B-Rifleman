using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameManager gameManager;
    public GUIManager guiManager;
    public LayerMask layerMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObject = collision.gameObject;
        if ((layerMask & 1 << collisionObject.layer) != 1 << collisionObject.layer)
        {
            return;
        }

        Effects collisionEffects = collisionObject.GetComponent<Effects>();
        if (collisionEffects == null)
        {
            return;
        }

        int newHearts = Mathf.Min(guiManager.heartsLeft + collisionEffects.healthEffect, guiManager.maxHearts);
        if (newHearts <= 0)
        {
            Death();
            return;
        }

        guiManager.heartsLeft = newHearts;
        guiManager.updateGUI();
    }
    private void Death()
    {
        gameManager.Die();
        guiManager.heartsLeft = guiManager.maxHearts;
        guiManager.updateGUI();
    }
}
