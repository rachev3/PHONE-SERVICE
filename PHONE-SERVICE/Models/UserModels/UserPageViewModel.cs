namespace PHONE_SERVICE.Models.UserModels
{
    public class UserPageViewModel
    {
        public UserPageViewModel()
        {
            Users = new List<UserViewModel>();    
        }
        public UserPageViewModel(List<UserViewModel> users)
        {
            Users = users;
        }

        public List<UserViewModel> Users { get; set; }   
    }
}
