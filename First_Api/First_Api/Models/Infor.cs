using System;
using System.Collections.Generic;

namespace First_Api.Models
{
    public partial class Infor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public static implicit operator string(Infor v)
        {
            throw new NotImplementedException();
        }
    }
}
