namespace Sorter.Infrastructure
{
    public interface IFileManager
    {
        void Write(object data);

        T Read<T>();
    }
}
