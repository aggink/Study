using Study.Lab3.Storage.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Storage.Models.PoliceDepartament;

//Стажер
public class Intern
{
    //Идентификатор стажера
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnIntern {  get; set; }
    //Имя
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]
    public string Name { get; set; }
    //Фамилия 
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]
    public string SurName { get; set; }
    //Уровень подготовки
    [Required, MaxLength(ModelConstants.PoliceDepartamentConstants.Title)]
    public string SkillLevel { get; set; }
}
