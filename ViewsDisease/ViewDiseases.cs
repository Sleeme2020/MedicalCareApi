namespace ViewsDisease
{
    public class ViewDiseases
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public ViewDiseasesType DiseasesType { get; set; }
        public string DiscriptorDoctor { get; set; }
    }

    public class ViewDiseasesType
    {
        public int CodeType { get; set; }
        public string CodeName { get; set; }
    }


}
