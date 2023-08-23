using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MeleeEnemy
{
    private Color invisible;
    private Color visible;
    protected override void Start()
    {
        invisible = new Color(enSprRenderer.color.r, enSprRenderer.color.g, enSprRenderer.color.b, 0.1f);
        visible = new Color(enSprRenderer.color.r, enSprRenderer.color.g, enSprRenderer.color.b, 255.0f);
        enSprRenderer.color = invisible;
        base.Start();
    }
    protected override void Decide()
    {
        Hide();
        base.Decide();
    }
    private void Hide()
    {
        if (!isAbilityAvailable) return;
        if (enIsAttacking) return;
        
        StartCoroutine(InvisibilityFade());
        Debug.Log("Hola");
        isAbilityAvailable = false;
    }
    private void Reveal()
    {
        enSprRenderer.color = visible;
        StartCoroutine(StartEnemyAbilityCooldown());
    }

    private IEnumerator InvisibilityFade()
    {
        for (float i = 1; i >= 0.1; i -= Time.deltaTime)
        {
            // set color with i as alpha
            enSprRenderer.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}
