using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class Block 
{
    public int Id{ get; set; }
    public string Description{ get; set; }
    public string Theory{ get; set; }

    public Dictionary<string,Task> Tasks { get; set; }

    public Block(int id, string description, string theory, Dictionary<string, Task> tasks)
    {
        Id = id;
        Description = description;
        Theory = theory;
        Tasks = tasks;
    }
}
