using System.Collections.Generic;

namespace GameInventory
{
    /// <summary>
    /// Abstract base class for data access.
    /// </summary>
    public abstract class DAL
    {
        public abstract List<GameTitle> LoadData(string filename);
        public abstract void SaveData(string filename, List<GameTitle> games);
    }
}
