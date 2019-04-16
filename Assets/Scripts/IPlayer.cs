using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using UnityEngine;

/*public interface IPlayer
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
    public Vector3 Position { get; set; }
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
}*/
public class TreeGraph
{
    public Dictionary<string,List<string>> graph = new Dictionary<string, List<string>>();
    public Dictionary<string,node> nodeLookup = new Dictionary<string, node>();
    public void BuildEdges(params Tuple<string,string>[] connections)
    {
        foreach (var connection in connections)
        {
            if (!graph.ContainsKey(connection.Item1))
            {
                graph[connection.Item1] = new List<string>();
            }
            if (!nodeLookup.ContainsKey(connection.Item1))
            {
                nodeLookup[connection.Item1] = new node(){id=connection.Item1};
            }                    
            if (!nodeLookup.ContainsKey(connection.Item2))
            {
                nodeLookup[connection.Item2] = new node(){id=connection.Item2};
            }

            if (!nodeLookup[connection.Item2].back_edges.Contains(connection.Item1) &&
                connection.Item2 != connection.Item1)
            {
                nodeLookup[connection.Item2].back_edges.Add(connection.Item1);
                graph[connection.Item1].Add(connection.Item2);
            }
        }
    }
}

public class node
{
        
    public string id;
    public bool unlocked = false;
    public List<string> back_edges = new List<string>();
}