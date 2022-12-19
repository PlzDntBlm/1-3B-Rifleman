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
        if ((layerMask & 1 << collisionObject.layer) == 1 << collisionObject.layer)
        {
            if (collisionObject.GetComponent<Effects>() != null)
            {
                Effects collisionEffects = collisionObject.GetComponent<Effects>();

                // heart logic
                if (guiManager.heartsLeft <= guiManager.maxHearts)
                {
                    if (guiManager.heartsLeft + collisionEffects.healthEffect > guiManager.maxHearts)
                    {
                        guiManager.heartsLeft = guiManager.maxHearts;
                    }
                    else
                    {
                        guiManager.heartsLeft += collisionEffects.healthEffect;
                        if(guiManager.heartsLeft <= 0){
                            guiManager.heartsLeft = 0;

                            // death
                            Death();
                        }
                    }
                }
            }
        }
    }
    private void Death(){
        gameManager.Die();
        guiManager.heartsLeft = guiManager.maxHearts;
    }
}
