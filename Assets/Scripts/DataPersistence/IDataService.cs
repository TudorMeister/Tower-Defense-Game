public interface IDataService
{
    bool SaveData<T>(string FilePath, T Data, bool Encrypt);

    T LoadData<T>(string FilePath, bool Encrypt);
}
