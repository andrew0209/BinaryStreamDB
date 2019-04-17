namespace Stream.models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Number { get; set; }
        public int OwnerId { get; set; }

        public Car()
        {
            Id = 0;
            Brand = "";
            Model = "";
            Number = 0;
            OwnerId = 0;
        }
        public Car(int id, string b, string m, int n, int Oid)
        {
            Id = 0;
            Brand = b;
            Model = m;
            Number = n;
            OwnerId = Oid;
        }
    }
}
