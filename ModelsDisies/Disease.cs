using Infrastruct;

namespace ModelsDisease
{
    public class Disease:IUpdate<Disease>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }

        public string DiscriptionDoctor { get; set; }

        public DiseaseType DiseaseType { get; set; }

        private void Update(Disease entity)
        {
            Name = entity.Name;
            Description = entity.Description;
            DiseaseType = entity.DiseaseType;
            DiscriptionDoctor = entity.DiscriptionDoctor;
        }

        Disease IUpdate<Disease>.Update(Disease? entity)
        {
           if(entity is not null) 
           {
                Update(entity);
           }
           return this;
        }
    }
}
