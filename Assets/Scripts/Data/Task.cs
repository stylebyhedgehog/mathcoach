using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    [JsonProperty("number")]
    public int number;
    [JsonProperty("statement")]
    public string statement;
    [JsonProperty("solution")]
    public string solution;


    public Task(int number, string statement, string solution)
    {
        this.number = number;
        this.statement = statement;
        this.solution = solution;
 
    }
}
