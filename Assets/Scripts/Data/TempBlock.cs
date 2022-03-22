using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBlock : MonoBehaviour
{
    public static TempBlock Instance;
    public static Action<int> taskAdded;


    private void Awake()
    {
        Instance = this;
        newBlock = new Block();
        newBlock.Tasks = new Dictionary<string, Task>();
    }

    private Block newBlock;
    

    public void addTask(int number, string statement, string solution)
    {
        Task newTask = new Task(number, statement, solution);
        newBlock.Tasks.Add("task" + number.ToString(), newTask);

        taskAdded?.Invoke(newBlock.Tasks.Count);
    }

    public void setBlockData(int id, string description, string theory)
    {

        newBlock.Id = id;
        newBlock.Description = description;
        newBlock.Theory = theory;
    }
   
    public void saveBlock()
    {
        BlockRepository.Instance.addNewBlock(newBlock);
        newBlock = new Block();
        newBlock.Tasks = new Dictionary<string, Task>();
    }
}
