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

        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Role { get; set; }
    }
}
