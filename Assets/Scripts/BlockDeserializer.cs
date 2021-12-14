using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDeserializer : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        if (objectType == typeof(Block))
        {
            return true;
        }

        return false;
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        /* reader.Read(); //start array
                        //reader.Read(); //start object
         JObject obj = (JObject)serializer.Deserialize(reader);

         //{"page":1,"pages":1,"per_page":"50","total":35}
         var model = new Block();
         Debug.Log(obj);
         model.Description = (string)(((JValue)obj["description"]).Value);
         model.Id = Convert.ToInt32(((JValue)obj["id"]).Value);
         Debug.Log(model.Id);
         model.Theory = ((string)((JValue)obj["theory"]).Value);

         reader.Read(); //end object

         model.Tasks = serializer.Deserialize<List<Task>>(reader);

         reader.Read(); //end array

         return model;*/
        throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
