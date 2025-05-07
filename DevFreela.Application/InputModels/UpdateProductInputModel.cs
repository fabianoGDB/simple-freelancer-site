using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.InputModels
{
    public class UpdateProductInputModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descripton { get; set; }
        public decimal TotalCost { get; set; }
    }
}
