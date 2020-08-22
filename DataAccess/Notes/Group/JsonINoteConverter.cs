using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Notes.Group
{
    public class JsonINoteConverter : JsonConverter<INote>
    {
        public override bool CanRead => true;
        public override bool CanWrite => false;

        public override INote ReadJson(JsonReader reader, Type objectType, INote existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var typeName = jsonObject[nameof(INote.Type)].Value<string>();

            var assembly = Assembly.GetExecutingAssembly();
            var typeToCreate = assembly.GetTypes().Single(t => t.Name == typeName);

            var note = Activator.CreateInstance(typeToCreate) as INote;

            serializer.Populate(jsonObject.CreateReader(), note);

            return note;
        }

        public override void WriteJson(JsonWriter writer, INote value, JsonSerializer serializer)
        {
            throw new NotSupportedException("Writing is not supported. Use default serialization instead");
        }
    }
}