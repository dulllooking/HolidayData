using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayData_ClassDB
{
    public class HolidayInfo
    {
        [Key]
        [Display(Name = "編號")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "日期")]
        public DateTime? Date { get; set; }

        [MaxLength(50)]
        [Display(Name = "節日名稱")]
        public string Name { get; set; }

        [Display(Name = "是否放假")]
        public bool? IsHoliday { get; set; }

        [MaxLength(50)]
        [Display(Name = "放假類別")]
        public string HolidayCatalog { get; set; }

        [MaxLength(100)]
        [Display(Name = "備註")]
        public string Description { get; set; }
    }
}
