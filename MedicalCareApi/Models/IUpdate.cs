namespace MedicalCareApi.Models
{
    public interface IUpdate<E>
    {
        E Update(E? entity);
    }
}
