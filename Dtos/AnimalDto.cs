using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

//public enum AnimalGenus
//{
//    Macho,
//    Femea,
//    Outro,
//    NA
//}

//public enum Category
//{
//    Ovelha,
//    Borrego,
//    Cordeiro,
//    Carneiro,
//    Rufiao
//}

//public enum AnimalBreed
//{
//    [Display(Name = "Santa Inês")]
//    SantaInes,

//    [Display(Name = "Morada Nova 2")]
//    MoradaNova2,

//    [Display(Name = "Suffolk")]
//    Suffolk,

//    [Display(Name = "Bergamácia")]
//    Bergamacia,

//    [Display(Name = "Hampshire Down")]
//    HampshireDown,

//    [Display(Name = "Poll Dorset")]
//    PollDorset,

//    [Display(Name = "Dorper")]
//    Dorper,

//    [Display(Name = "White Dorper")]
//    WhiteDorper
//}

//public enum NurseryStatus
//{
//    [Display(Name = "Saudável")]
//    Saudavel = 1,

//    [Display(Name = "Doente")]
//    Doente = 2
//}


public class AnimalDto
{
    [Required]
    public string AnimalGenus { get; set; }

    [Required]
    public string DateBirth { get; set; }

    [Required]
    public int Weight { get; set; }

    [Required]
    public string Dentition { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public string NameDad { get; set; }
    [Required]
    public string Category { get; set; }

    [Required]
    public string NameMom { get; set; }

    [Required]
    public string DadAnimal { get; set; }
    [Required]
    public string MomAnimal { get; set; }
    [Required]
    public string CreatedBy { get; set; }
    public string EarringId { get; set; }
}


