using System.ComponentModel.DataAnnotations;

public class AnimalUpdateDto
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

    public string Category { get; set; }

    [Required]
    public string NameMom { get; set; }

    [Required]
    public string DadAnimal { get; set; }
    [Required]
    public string MomAnimal { get; set; }
    public DateTime CreatedDt { get; set; } = DateTime.UtcNow;
}
