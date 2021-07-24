using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Knight_Pratice.Models
{
    public class Data
    {
        [Key]
        public int Data_Id { get; set; }
        public string Data_Input { get; set; }
        public string Data_Result { get; set; }
    }
}
