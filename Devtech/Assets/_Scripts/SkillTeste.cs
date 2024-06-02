using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillTeste", menuName = "Skills/SkillTeste")]
public class SkillTeste : BaseSkill
{
    public override void Activate()
    {
        Debug.Log("SkillTeste activated");
    }
}