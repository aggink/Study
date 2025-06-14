using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Storage.Models.Shelter;

public class Adoption
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnAdoption { get; set; }

    [ForeignKey(nameof(Cat))]
    public Guid IsnCat { get; set; }

    [ForeignKey(nameof(MiniPig))]
    public Guid IsnMiniPig { get; set; }

    [Required]
    [ForeignKey(nameof(Customer))]
    public Guid IsnCustomer { get; set; }

    [Required]
    [Range(ModelConstants.Adoption.PriceMin, ModelConstants.Adoption.PriceMax)]
    public int Price { get; set; }


    [Required]
    public DateTime AdoptionDate { get; set; }

    [Required]
    [MaxLength(ModelConstants.Adoption.Status)]
    public string Status { get; set; }

    /// <summary>
    /// Клиент
    /// </summary> 
    public virtual Customer Customer { get; set; }

    /// <summary>
    /// Кот
    /// </summary>
    public virtual Cat Cat { get; set; }

    /// <summary>
    /// Мини пиг
    /// </summary>
    public virtual MiniPig MiniPig { get; set; }
}