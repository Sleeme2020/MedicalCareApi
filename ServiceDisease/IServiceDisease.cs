using ModelsDisease;

namespace ServiceDiseases
{
    public interface IServiceDisease
    {
        Disease? AddDisease(Disease disease);
        IEnumerable<Disease> getDisease();
        Disease getDisease(Guid Id);
        Disease? UpdDisease(Disease disease);
    }
}