using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddTaskUI : MonoBehaviour
{
    [SerializeField] private InputField taskNumber;
    [SerializeField] private InputField taskStatement;
    [SerializeField] private InputField taskSolution;

    [SerializeField] private Button addTask;

    [SerializeField] private Button backToBlockBtn;


    void Start()
    {
        addListeners();
    }

    private void addListeners()
    {
        addTask.onClick.AddListener(() => onTaskSave());
        backToBlockBtn.onClick.AddListener(() => gameObject.SetActive(false));
    }

   

    private void onTaskSave()
    {
        TempBlock.Instance.addTask(int.Parse(taskNumber.text), taskStatement.text, taskSolution.text);
        taskNumber.text = "";
        taskStatement.text = "";
        taskSolution.text = "";

        gameObject.SetActive(false);

    }

   
}
