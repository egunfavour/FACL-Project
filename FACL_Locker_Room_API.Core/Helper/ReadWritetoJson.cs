using FACL_Locker_Room_API.Core.Interfaces;
using FACL_Locker_Room_API.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACL_Locker_Room_API.Core.Helper
{
    public class ReadWritetoJson : IReadWritetoJson
    {
        public async Task<bool> WriteAllToJson<T>(T model, string jsonFile)
        {
            try
            {
                string jsonText = JsonConvert.SerializeObject(model);
                await File.WriteAllTextAsync(jsonFile, jsonText);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<T>> ReadAllFromJson<T>(string jsonFile)
        {
            var readText = await File.ReadAllTextAsync(jsonFile);
            return JsonConvert.DeserializeObject<List<T>>(readText);
        }
    }
}

