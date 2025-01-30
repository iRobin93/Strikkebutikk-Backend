namespace StrikkebutikkBackend.Model;
using AutoMapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        // Define the mapping from ProductBase to ProductWithForeignKey
        CreateMap<ProductBase, ProductWithForeignKey>()
            .ForMember(dest => dest.pattern, opt => opt.Ignore()); // Ignore 'pattern' since it might not be directly available
    }
}