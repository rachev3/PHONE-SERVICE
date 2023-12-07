namespace PHONE_SERVICE.Models.PhoneModelModels
{
    public class PhoneModelPageViewModel
    {
        public PhoneModelPageViewModel(List<PhoneModelViewModel> phoneModels)
        {
            PhoneModels = phoneModels;
        }
        public List<PhoneModelViewModel> PhoneModels { get; set; }
    }
}
