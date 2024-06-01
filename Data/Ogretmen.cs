namespace efcoreApp.Data
{
    public class Ogretmen
    {
        public int OgretmenId { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? AdSoyad
        {
            get
            {
                return this.Ad +" "+this.Soyad;
            }
        }


        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public ICollection<Kurs> Kurslar { get; set; } = new List<Kurs>();


    }
}