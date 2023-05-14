namespace Do_an_co_so.Models
{
    public class CartItem
    {
        public int MaHH { set; get; }
        public string TenHH { set; get; }
        public string Hinh { set; get; }
        public double DonGia { set; get; }
        public int SoLuong { set; get;}
        public double ThanhTien => SoLuong * DonGia;
        
    }
}
