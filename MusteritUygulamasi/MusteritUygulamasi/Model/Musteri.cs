using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteritUygulamasi.Model
{
    public class Musteri
    {
        [Key]
        public int MusteriId { get; set; }
        public string MusteriAdi { get; set; } = string.Empty;
        public string MusteriSoyadi { get; set; } = string.Empty;
        public string MusteriTel { get; set; } = string.Empty;
        public string MusteriEposta { get; set; } = string.Empty;


    }
}
