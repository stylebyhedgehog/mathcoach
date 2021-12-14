
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using System;
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
