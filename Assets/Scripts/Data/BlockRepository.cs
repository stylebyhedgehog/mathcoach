
using UnityEngine;
using Firebase.Database;
using UnityEngine.Events;
using Newtonsoft.Json;

public class BlockRepository : MonoBehaviour
{
    public static BlockRepository Instance;
    private DatabaseReference reference;
    private UnityAction<Block> addAction;
    private void Awake()
    {   if (Instance == null)
        {
            reference = FirebaseDatabase.DefaultInstance.GetReference("blocks");
            Instance = this;
         
        }
    }
  

    public void addNewBlock(Block blockData)
    {
        string blockName ="block" + blockData.Id.ToString();
        reference.Child(blockName).Child("description").SetValueAsync(blockData.Description);
        reference.Child(blockName).Child("id").SetValueAsync(blockData.Id);
        reference.Child(blockName).Child("theory").SetValueAsync(blockData.Theory);

        foreach (var task in blockData.Tasks)
        {
            reference.Child(blockName).Child("tasks").Child(task.Key).Child("number").SetValueAsync(task.Value.number);
            reference.Child(blockName).Child("tasks").Child(task.Key).Child("solution").SetValueAsync(task.Value.solution);
            reference.Child(blockName).Child("tasks").Child(task.Key).Child("statement").SetValueAsync(task.Value.statement);
        }
    }

    public void getAllBlocks(UnityAction<Block> onSuccessAction)
    {
        reference.ChildAdded += HandleBlockChanged;
        addAction = onSuccessAction;
    }


    private void HandleBlockChanged(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        else
        {
            DataSnapshot snapshot = args.Snapshot;
            var json = snapshot.GetRawJsonValue();
            Block block = JsonConvert.DeserializeObject<Block>(json);
            addAction.Invoke(block);

        }
    }

  

   
}
