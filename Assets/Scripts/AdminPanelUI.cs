using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminPanelUI : MonoBehaviour
{
    [SerializeField] private InputField blockNumber;
    [SerializeField] private InputField blockDescription;
    [SerializeField] private InputField blockTheory;

    [SerializeField] private Button openAddTasksPanel;

    [SerializeField] private Text tasksAmount;

    [SerializeField] private Button backToMenuBtn;
    [SerializeField] private Button saveBlock;

    [SerializeField] private GameObject addTaskPanel;
    void Start()
    {
        addListeners();
        TempBlock.taskAdded += incresaeTasksAmount;
    }

    private void addListeners()
    {
        openAddTasksPanel.onClick.AddListener(() => onAddTaskButtonClicked());
        saveBlock.onClick.AddListener(() => onBlockSave());
        backToMenuBtn.onClick.AddListener(() => gameObject.SetActive(false));
    }

    private void onAddTaskButtonClicked()
    {
        TempBlock.Instance.setBlockData(int.Parse(blockNumber.text), blockDescription.text, blockTheory.text);
        addTaskPanel.SetActive(true);
    }

    private void onBlockSave()
    {
        TempBlock.Instance.setBlockData(int.Parse(blockNumber.text), blockDescription.text, blockTheory.text);
        TempBlock.Instance.saveBlock();
        blockNumber.text = "";
        blockDescription.text = "";
        blockTheory.text = "";
        gameObject.SetActive(false);

    }

    private void incresaeTasksAmount(int amount)
    {
        tasksAmount.text = "Количество задач: " + amount.ToString();
    }

}
