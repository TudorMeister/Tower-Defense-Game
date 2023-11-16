public interface IDataService
{
    bool SaveData<T>(string Path, T Data, bool Encrypt);

    T LoadData<T>(string Path, bool Encrypt);
}
