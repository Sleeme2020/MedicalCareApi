using Infrastruct;

namespace HospitalCard
{
    public class HospitalCard:IUpdate<HospitalCard>
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserID { get; set; }   
        public string Discription { get; set; }

        public List<DisiesItem> Disies { get; set; } = new();

        HospitalCard IUpdate<HospitalCard>.Update(HospitalCard? entity)
        {
            throw new NotImplementedException();
        }
    }
}
