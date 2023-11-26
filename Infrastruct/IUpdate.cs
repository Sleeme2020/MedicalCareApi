namespace Infrastruct
{
    public interface IUpdate<E>
    {
        E Update(E? entity);
    }
}
