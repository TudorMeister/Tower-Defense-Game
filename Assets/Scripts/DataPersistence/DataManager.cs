using System.Collections;
using System.Collections.Generic;

public class DataManager
{
    private static DataManager _instance;

    public static DataManager Instance
    {
        get
        {
            _instance ??= new DataManager();
            return _instance;
        }
    }

    private IDataService _dataService = new JsonDataService();

    private DataManager()
    {

    }
}
