using ProjeTakip.Models.Personel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjeTakip.Models.ProjeTakip
{
    public class PersonelProjeleri
    {
        public PersonelProjeleri()
        {
            this.PersonelBilgileris = new HashSet<PersonelBilgileri>();
        }
        [Key]
        public int PersonelProjeId { get; set; }
        [DisplayName("Proje Başlık")]
        [StringLength(100, ErrorMessage = "Maximum uzunluk 100 karakterden fazla olamaz!")]
        public string ProjeBaslik { get; set; }
        [DisplayName("Proje Açıklama")]
        [StringLength(250, ErrorMessage = "Maximum uzunluk 250 karakterden fazla olamaz!")]
        public string ProjeAciklama { get; set; }
        [DisplayName("Oluşturma Tarihi")]
        public DateTime OlusturmaTarihi { get; set; }
        [DisplayName("Öncelik Durumu")]
        public string OncelikDurumu { get; set; }
        [DisplayName("Tamamlanma Oranı")]
        public int TamamlanmaOrani { get; set; }
        [DisplayName("Tamamlanma Tarihi")]
        public DateTime? TamamlanmaTarihi { get; set; }
        [DisplayName("Tamamlanma Durumu")]
        public bool TamamlanmaDurumu { get; set; }

        public virtual ICollection<PersonelBilgileri> PersonelBilgileris { get; set; }
    }
}