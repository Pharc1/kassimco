using System;
namespace API_Kassim_Co.Models
{
    public class Continent
    {
        public int Id { get; set; } 

        public string Nom { get; set; } 

        public List<Pays> paysList { get; set; }



    }


}