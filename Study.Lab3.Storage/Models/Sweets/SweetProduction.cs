using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Storage.Models.Sweets;

/// <summary>
/// Конфеты
/// </summary>
public class SweetProduction
{
    /// <summary>
    /// Идентификатор конфеты
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid ID { get; set; }
    
    /// <summary>
    /// Идентификатор конфеты
    /// </summary>
    [ForeignKey(nameof(Sweet))]
    public Guid SweetID { get; set; }

    /// <summary>
    /// Идентификатор фабрики
    /// </summary>
    [ForeignKey(nameof(SweetFactory))]
    public Guid SweetFactoryID { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public virtual Sweet Sweet { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public virtual SweetFactory SweetFactory { get; set; }
}
