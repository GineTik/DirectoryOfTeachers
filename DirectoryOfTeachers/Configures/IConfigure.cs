namespace DirectoryOfTeachers.Bot.Configures
{
    public interface IConfigure<T>
    {
        void Configure(T configureData);
    }
}
