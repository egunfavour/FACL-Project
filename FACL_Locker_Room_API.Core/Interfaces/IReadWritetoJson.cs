namespace FACL_Locker_Room_API.Core.Interfaces
{
    public interface IReadWritetoJson
    {
        Task<List<T>> ReadAllFromJson<T>(string jsonFile);
        Task<bool> WriteAllToJson<T>(T model, string jsonFile);
    }
}