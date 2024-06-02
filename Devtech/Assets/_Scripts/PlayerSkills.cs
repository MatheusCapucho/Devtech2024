using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    [SerializeField]
    [SerializeReference]
    private List<BaseSkill> _skillList = new();

    private ArrayList _newSkillInfo = new ArrayList(2);

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
        if (_skillList[index] != null)
            _skillList[index].Activate();
    }

    public void ChangeSkill(Component sender, object data)
    {
        if (data is ArrayList)
        {
            _newSkillInfo = (ArrayList)data;
            BaseSkill _newSkill = (BaseSkill)_newSkillInfo[0];
            int _newSkillIndex = (int)_newSkillInfo[1];

            _skillList[_newSkillIndex] = _newSkill;
        }
    }
}