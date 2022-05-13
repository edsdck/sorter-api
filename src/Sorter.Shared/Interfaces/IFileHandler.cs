namespace Sorter.Shared.Interfaces
{
    public interface IFileHandler
    {
        void Write(object data);

        T Read<T>();
    }
}
