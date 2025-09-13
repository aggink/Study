using Study.Lab3.Storage.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Storage.Models.PoliceDepartament;

//Офицер
public class Officer
{
    //Идентификатор офицера
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnOfficer {  get; set; }
    //Имя
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]
    public string Name { get; set; }
    //Фамилия
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]
    public string SurName { get; set; }
    //Должность
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]
    public string Rank { get; set; }
}
