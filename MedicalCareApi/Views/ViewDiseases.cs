namespace MedicalCareApi.Views
{
    public class ViewDiseases
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CodeType { get; set; }
        public string CodeName { get; set; }
        public string DiscriptorDoctor { get; set; }
    }
}
