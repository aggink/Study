using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Study.Lab3.Storage.Constants;

namespace Lab3.Storage.Models.HospitalStore;

public class Order
{
    /// <summary>
    /// ����
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnOrder { get; set; }

    /// <summary>
    /// ID ��������
    /// </summary>
    [Required]
    public Guid IsnPatient { get; set; }

    /// <summary>
    /// ID ������
    /// </summary>
    [Required]
    public Guid IsnProduct { get; set; }

    /// <summary>
    /// ���������� ������
    /// </summary>
    [Required, Range(ModelConstants.Order.QuantityMin, ModelConstants.Order.QuantityMax)]
    public int Quantity { get; set; }     
}