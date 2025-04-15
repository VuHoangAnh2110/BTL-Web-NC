using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Web_NC.Models
{
    public class TruyCapInfo
    {
        public string? MaCongViec { get; set; }
        public DateTime TimeTruyCap { get; set; }
    }
}