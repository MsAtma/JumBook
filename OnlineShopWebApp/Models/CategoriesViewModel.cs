using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public enum CategoriesViewModel
    {
        [Display(Name = "Біографія")]
        Biography,

        [Display(Name = "Детектив")]
        Detective,

        [Display(Name = "Класика")]
        Classic,

        [Display(Name = "Романтика")]
        Romance,

        [Display(Name = "Трилери та жахи")]
        ThrillerAndHorror,

        [Display(Name = "Наукова фантастика")]
        ScienceFiction,

        [Display(Name = "Фентезі")]
        Fantasy
    }
}
