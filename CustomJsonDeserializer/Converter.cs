using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace CustomJsonDeserializer
{
  public abstract class JsonCreationConverter<T> : JsonConverter
  {
    protected abstract T Create(Type objectType, JObject jObject);
    public override bool CanWrite => false;

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      throw new NotImplementedException();
    }

    public override bool CanConvert(Type objectType)
    {
      return typeof(T).IsAssignableFrom(objectType);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      JObject jObject = JObject.Load(reader);
      T target = Create(objectType, jObject);
      serializer.Populate(jObject.CreateReader(), target);
      return target;
    }
  }

  public class PersonConverter : JsonCreationConverter<Person>
  {
    protected override Person Create(Type objectType, JObject jObject)
    {
      if (jObject.Value<string>("classType") == typeof(Employee).FullName)
      {
        return new Employee();
      }
      else if (jObject.Value<string>("classType") == typeof(President).FullName)
      {
        return new President();
      }

      throw new Exception("PersonConverter->jObject is not a Person subclass!");
    } 
  }
}
