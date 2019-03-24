using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterIconSwitcher : MonoBehaviour 
{
    private Animator monsterIconAnimator;
    private int currentIconIndex;

    private void Awake()
    {
        monsterIconAnimator = GetComponent<Animator>();
        currentIconIndex = -1;
    }

    public void SwitchIcons(int index)
    {
        if(currentIconIndex == index)
        {
            return;
        }

        currentIconIndex = index;
        var bodyType = (BodyType)index;
        var animatorName = "Ground";
        switch(bodyType)
        {
            case BodyType.BIPEDAL:
                animatorName = "Ground";
                break;
            case BodyType.FLYING:
                animatorName = "Flying";
                break;
            case BodyType.WATER:
                animatorName = "Water";
                break;
            case BodyType.FAIRY:
                animatorName = "Fairy";
                break;
            case BodyType.GRASS:
                animatorName = "Grass";
                break;
            case BodyType.BUG:
                animatorName = "Bug";
                break;
            case BodyType.DRAGON:
                animatorName = "Dragon";
                break;
            case BodyType.QUADRUPED:
                animatorName = "Normal";
                break;
            default:
                break;
        }

        monsterIconAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load(animatorName);
    }
}
