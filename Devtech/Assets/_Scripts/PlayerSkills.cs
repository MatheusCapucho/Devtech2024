using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    [SerializeField]
    [SerializeReference]
    private List<BaseSkill> _skillList = new();

    private void Update()
    {
        if (InputManager2.Skill1)
        {
            ActivateSkill(0);
        }
        else if (InputManager2.Skill2)
        {
            ActivateSkill(1);
        }
        else if (InputManager2.Skill3)
        {
            ActivateSkill(2);
        }
    }

    private void ActivateSkill(int index)
    {
        _skillList[index].Activate();
    }
}