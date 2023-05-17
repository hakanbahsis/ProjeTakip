using ProjeTakip.Models.ProjeTakip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjeTakip.Models.Personel
{
    public class PersonelBilgileri
    {
        public PersonelBilgileri()
        {
            this.PersonelProjeleris = new HashSet<PersonelProjeleri>();
        }
        [Key]
        public int PersonelBilgileriId { get; set; }
        [DisplayName("E-POSTA")]
        public string Eposta { get; set; }
        [DisplayName("Şifre")]
        [StringLength(25,ErrorMessage ="Maximum uzunluk 25 karakterden fazla olamaz!")]
        public string Sifre { get; set; }
        [DisplayName("Yetki")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz!")]
        public string Yetki { get; set; }
        [DisplayName("Ad Soyad")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz!")]
        public string AdSoyad { get; set; }
        [DisplayName("TC Kimlik No")]
        [StringLength(11, ErrorMessage = "Maximum uzunluk 11 karakterden fazla olamaz!")]
        public string TCNO { get; set; }
        [DisplayName("Departman")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz!")]
        public string Departman { get; set; }
        [DisplayName("Görevi")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz!")]
        public string Gorevi { get; set; }
        [DisplayName("Açıklama")]
        [StringLength(50, ErrorMessage = "Maximum uzunluk 50 karakterden fazla olamaz!")]
        public string PozisyonAciklama { get; set; }
        [DisplayName("Telefon Numarası")]
        [StringLength(11, ErrorMessage = "Maximum uzunluk 11 karakterden fazla olamaz!")]
        public string TelNo { get; set; }
        [DisplayName("Adres")]
        [StringLength(250, ErrorMessage = "Maximum uzunluk 250 karakterden fazla olamaz!")]
        public string Adres { get; set; }
        [DisplayName("Medeni Hal")]
        [StringLength(5, ErrorMessage = "Maximum uzunluk 5 karakterden fazla olamaz!")]
        public string MedeniHal { get; set; }
        [DisplayName("Doğum Tarihi")]
        public DateTime? DogumTarihi { get; set; }
        [DisplayName("İşe Giriş Tarihi")]
        public DateTime? IseGirisTarihi { get; set; }
        public virtual ICollection<PersonelProjeleri> PersonelProjeleris { get; set; }

    }
}