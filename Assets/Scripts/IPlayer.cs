using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public interface IPlayer
{
    bool MainAttack();
    bool SecondaryAttack();
    bool TertiaryAttack();
    
}

public interface INPCPlayer
{
    
}
public class Quest
{
    
}


public class SkillNodeAttribute
{
}

public class SkillNode
{
}

public struct NPCRelation
{
    public bool HaveMet { get; set;}
    public Dictionary<int, Quest> QuestList;

}
public class Player : IPlayer
{

    public string Name { get; set; }
    public Dictionary<string,List<string>> Characteristics { get; set; }
    public Dictionary<string, int> Inventory { get; set; }
    public Dictionary<string, int> Stats { get; set;}
    public Dictionary<string, int> Abilities { get; set; }
    public Dictionary<SkillNode, List<SkillNodeAttribute>> SkillTree;
    public Dictionary<string, NPCRelation> NPCRelations;
    
    public bool MainAttack()
    {
        throw new System.NotImplementedException();
    }

    public bool SecondaryAttack()
    {
        throw new System.NotImplementedException();
    }

    public bool TertiaryAttack()
    {
        throw new System.NotImplementedException();
    }
}