using AutoMapper;
using WebApplicationIso.Models;
using WebApplicationIso.ViewModels;

namespace WebApplicationIso.Mapping
{
    public class ViewModelMapping : Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();  //Dönüştürme İşlemi Yapıldı.
            CreateMap<Customer, CustomerViewModel>().ReverseMap();  //Dönüştürme İşlemi Yapıldı.
            CreateMap<Customer, CustomerViewModelForAdd>().ReverseMap();  //Dönüştürme İşlemi Yapıldı.
            CreateMap<Customer, SelectCustomerViewModel>().ReverseMap();  //Dönüştürme İşlemi Yapıldı.
        }
    }
}
