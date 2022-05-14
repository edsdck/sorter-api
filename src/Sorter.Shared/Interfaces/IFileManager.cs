namespace Sorter.Shared.Interfaces
{
    public interface IFileManager
    {
        void Write(object data);

        T Read<T>();
    }
}
