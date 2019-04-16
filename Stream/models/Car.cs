namespace Stream.models
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Number { get; set; }
        public int OwnerId { get; set; }

        public Car()
        {
            Brand = "";
            Model = "";
            Number = 0;
            OwnerId = 0;
        }
        public Car(string b, string m, int n, int id)
        {
            Brand = b;
            Model = m;
            Number = n;
            OwnerId = id;
        }
    }
}
