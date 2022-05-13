namespace Sorter.Infrastructure
{
    public interface IFileHandler
    {
        void Write(object data);

        T Read<T>();
    }
}
