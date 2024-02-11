namespace DisiesHistory
{
    public class HistoryDisies
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid DisiesID { get; set; }
        public Guid DisiesTypeID { get; set; }
        public Guid DoctorId { get; set; }
        public string Discription { get; set; }

    }



    class Model
    {
        public Guid Id { get; set; }
        public string IdBook { get; set; }
        public double Price { get; set; }
        public double Percent { get; set; }
        public int days { get; set; }
    }

}
