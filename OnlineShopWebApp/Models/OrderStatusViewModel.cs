using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public enum OrderStatusViewModel
    {
        [Display(Name = "Створено")]
        Created,

        [Display(Name = "Оброблено")]
        Processed,

        [Display(Name = "В дорозі")]
        Delivering,

        [Display(Name = "Доставлено")]
        Delivered,

        [Display(Name = "Скасовано")]
        Canceled
    }
}
