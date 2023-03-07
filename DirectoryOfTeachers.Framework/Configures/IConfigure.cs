namespace DirectoryOfTeachers.Framework.Configures
{
    public interface IConfigure<T>
    {
        void Configure(T configureData);
    }
}
